using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.BLL;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bill(Bill bill)
        {
            if (ModelState.IsValid)
            {
                return View(bill);
            }

            return View("Index", bill);
        }

        public ActionResult Play()
        {
            return RedirectToAction("Index");
        }
    }
}