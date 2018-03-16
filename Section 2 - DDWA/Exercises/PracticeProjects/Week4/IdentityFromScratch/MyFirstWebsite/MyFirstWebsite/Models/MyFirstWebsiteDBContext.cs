using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebsite.Models
{
    public class MyFirstWebsiteDBContext : IdentityDbContext
    {
        public MyFirstWebsiteDBContext() : base("MyFirstWebsite")
        {
        }
    }
}