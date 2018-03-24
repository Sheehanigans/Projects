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

            //clear all roles from the user
            var dbUser = context.Users.SingleOrDefault(u => u.Id == model.Id);
            dbUser.Roles.Clear();
            context.SaveChanges();

            //get new role from model, remove user from current role, add to new role
            var newRole = roles.Where(r => r.Id == model.Role).Select(r => r.Name).SingleOrDefault();
            UserManager.RemoveFromRole(user.Id, oldRole);
            context.SaveChanges();

            UserManager.AddToRole(user.Id, newRole);

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