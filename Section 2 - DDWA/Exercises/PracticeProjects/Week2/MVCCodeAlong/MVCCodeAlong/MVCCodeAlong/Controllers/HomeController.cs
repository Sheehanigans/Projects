using MVCCodeAlong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeAlong.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Person me = new Person { Name = "Ryan" };
            return View(me);
        }

        public JsonResult AllPeople()
        {
            List<Person> allPeople = new List<Person>
            {
                new Person{Name = "Bob"},
                new Person{Name = "Jim"},
                new Person{Name = "Fred"}
            };
            return Json(allPeople, JsonRequestBehavior.AllowGet);
        }



        //public ActionResult AllPeople(string name)
        //{
        //    List<Person> allPeople = new List<Person>
        //    {
        //        new Person{Name = "Bob"},
        //        new Person{Name = "Jim"},
        //        new Person{Name = "Fred"}
        //    };

        //    Person personToEmphasize = allPeople
        //        .SingleOrDefault(p => p.Name == name);

        //    if(personToEmphasize != null)
        //    {
        //        personToEmphasize.Name = "<h1>" + personToEmphasize.Name + "</h1>";
        //    }

        //    return View(allPeople);
        //}
    }
}