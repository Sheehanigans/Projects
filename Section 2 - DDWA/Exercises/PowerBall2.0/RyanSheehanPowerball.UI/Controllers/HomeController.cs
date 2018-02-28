﻿using RyanSheehanPowerball.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RyanSheehanPowerball.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPick(PickModel pick)
        {
            if (ModelState.IsValid)
            {
                return View(pick);
            }
            return View("AddPick", pick);
        }

        public ActionResult Play()
        {
            return RedirectToAction("Index");
        }
    }
}