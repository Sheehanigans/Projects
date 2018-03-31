using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        private SpecialManager _specialManager;
        private ListingManager _listingManager;
        private MakeManager _makeManager;
        private ModelManager _modelManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ActionResult Admin()
        {
            //menu 
            return View();
        }

        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            return View();
        }

        public ActionResult EditVehicle()
        {
            return View();
        }

        public ActionResult Specials()
        {
            _specialManager = SpecialManagerFactory.Create();
            var model = new AdminSpecialVM();
            var response = _specialManager.GetAllSpecials();

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }
            else
            {
                model.SetSpecialItems(response.Specials);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Specials(AdminSpecialVM model)
        {
            _specialManager = SpecialManagerFactory.Create();

            if (ModelState.IsValid)
            {
                try
                {
                    var response = _specialManager.SaveSpecial(model.Special);

                    if (!response.Success)
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var response = _specialManager.GetAllSpecials();
                model.SetSpecialItems(response.Specials);

                return View(model);
            }

            return RedirectToAction("Specials");
        }

        public ActionResult DeleteSpecial(int id)
        {
            _specialManager = SpecialManagerFactory.Create();

            var response = _specialManager.DeleteSpecial(id);

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }

            return RedirectToAction("Specials");
        }

        public ActionResult Models()
        {
            _modelManager = ModelManagerFactory.Create();
            _makeManager = MakeManagerFactory.Create();

            var model = new ModelsVM();
            var modelResponse = _modelManager.GetAllModels();
            var makeResponse = _makeManager.GetAllMakes();

            if (!modelResponse.Success || !makeResponse.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{modelResponse.Message} {makeResponse.Message}");
            }
            else
            {
                model.SetModelItems(modelResponse.Payload);

                model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                });

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Models(ModelsVM model)
        {
            _modelManager = ModelManagerFactory.Create();
            _makeManager = MakeManagerFactory.Create();

            if (ModelState.IsValid)
            {
                model.NewModel.DateAdded = DateTime.Now;
                model.NewModel.UserName = User.Identity.Name;
                
                //model.NewModel.Make = _makeManager.GetMake(model.NewModel.Make)
                


                //save 
                var response = _modelManager.SaveModel(model.NewModel);

                //throw error for non success
                if (!response.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                }

                return RedirectToAction("Models");
            }
            else
            {
                var makeResponse = _makeManager.GetAllMakes();
                model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                });

                return View(model);
            }

        }



        public ActionResult Makes()
        {
            _makeManager = MakeManagerFactory.Create();
            var model = new MakesVM();
            var response = _makeManager.GetAllMakes();

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }
            else
            {
                model.SetMakeItems(response.Payload);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Makes(MakesVM model)
        {
            _makeManager = MakeManagerFactory.Create();

            if (ModelState.IsValid)
            {
                try
                {

                    model.NewMake.DateAdded = DateTime.Now;
                    model.NewMake.UserName = User.Identity.Name;

                    var response = _makeManager.SaveMake(model.NewMake);

                    if (!response.Success)
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                    }

                    return RedirectToAction("Makes");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Users()
        {
            var users = UserManager.Users.ToList();
            var model = users.Select(s => new UserVM
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                UserName = s.UserName,
                Role = UserManager.GetRoles(s.Id).FirstOrDefault()
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var context = new CarDealershipDbContext();
            var roles = context.Roles;
            var model = new RegisterViewModel();

            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            //get the database context
            var context = new CarDealershipDbContext();

            if (ModelState.IsValid)
            {
                //get the user
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName};
                var result = await UserManager.CreateAsync(user, model.Password);

                //successfully got user
                if (result.Succeeded)
                {
                    //create a new role manager 
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    var role = roleManager.FindById(model.Role);
                    UserManager.AddToRole(user.Id, role.Name);

                    return RedirectToAction("Users", "Admin");
                }
                AddErrors(result);
            }

            var roles = context.Roles;

            //populate roles in model
            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var context = new CarDealershipDbContext();
            var roles = context.Roles.ToList();
            var editedUser = UserManager.FindById(id);
            var model = new RegisterViewModel();

            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            model.Id = editedUser.Id;
            model.FirstName = editedUser.FirstName;
            model.LastName = editedUser.LastName;
            model.Email = editedUser.Email;

            foreach (var role in editedUser.Roles)
            {
                model.Role = role.RoleId;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult EditUser(RegisterViewModel model)
        {
            //get user, roles
            var context = new CarDealershipDbContext();
            var roles = context.Roles;
            var user = UserManager.FindById(model.Id);

            //get the current role in the db
            var oldRole = user.Roles.SingleOrDefault().RoleId;

            if (!string.IsNullOrEmpty(model.EditedPassword))
            {
                user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.EditedPassword);
            }

            //edit user
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;

            if(!user.Roles.Any(r => r.RoleId == model.Role))
            {
                //clear all roles from the user
                var dbUser = context.Users.SingleOrDefault(u => u.Id == model.Id);
                dbUser.Roles.Clear();
                context.SaveChanges();

                //get new role from model, remove user from current role, add to new role
                var newRole = roles.Where(r => r.Id == model.Role).Select(r => r.Name).SingleOrDefault();
                UserManager.RemoveFromRole(user.Id, oldRole);
                UserManager.AddToRole(user.Id, newRole);
            }

            UserManager.Update(user);

            return RedirectToAction("Users", "Admin");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}