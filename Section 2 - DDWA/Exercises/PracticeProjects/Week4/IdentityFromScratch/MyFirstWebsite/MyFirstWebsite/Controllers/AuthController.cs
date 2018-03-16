using MyFirstWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace MyFirstWebsite.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            else
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                var user = userManager.Find(model.Email, model.Password);

                if(user == null)
                {
                    //ToDo: make a message
                    return View(model);
                }

                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);


                authManager.SignIn(identity);

                if(string.IsNullOrEmpty(model.ReturnUrl))
                {
                    //send them to some default landing page
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(model.ReturnUrl);
            }
        }
    }
}