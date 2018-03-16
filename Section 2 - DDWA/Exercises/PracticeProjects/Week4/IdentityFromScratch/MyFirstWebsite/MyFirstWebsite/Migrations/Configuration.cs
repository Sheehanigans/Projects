namespace MyFirstWebsite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyFirstWebsite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyFirstWebsite.Models.MyFirstWebsiteDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyFirstWebsiteDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            var userManager = new UserManager<IdentityUser>(
                new UserStore<IdentityUser>(context));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            //check if the user exists
            var user = userManager.FindByName("bob@bob.com");
            
            if(user == null)
            {
                var justCreated = userManager.Create(new IdentityUser("bob@bob.com")
                {
                    UserName = "bob@bob.com",
                    Email = "bob@bob.com"
                }, "123456");

                //we know the user exists but the user object is still null
                user = userManager.FindByName("bob@bob.com");
            }

            //var adminRole = roleManager.FindByName("admin");

            //if(!user.Roles.Any(r => r.RoleId == adminRole.Id))

            if(!userManager.IsInRole(user.Id, "admin"))
            {
                userManager.AddToRole(user.Id, "admin");
            }

        }
    }
}
