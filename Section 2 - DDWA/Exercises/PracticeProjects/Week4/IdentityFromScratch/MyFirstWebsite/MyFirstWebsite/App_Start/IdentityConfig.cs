using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MyFirstWebsite.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebsite.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new MyFirstWebsiteDBContext());

            app.CreatePerOwinContext<UserManager<IdentityUser>>(
                (options, context) =>
                    new UserManager<IdentityUser>(
                            new UserStore<IdentityUser>(context.Get<MyFirstWebsiteDBContext>()))
                        );

            app.CreatePerOwinContext<RoleManager<IdentityRole>>(
                (options, context) =>
                    new RoleManager<IdentityRole>(
                        new RoleStore<IdentityRole>(context.Get<MyFirstWebsiteDBContext>()))
                        );

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}