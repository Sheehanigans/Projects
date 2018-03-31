﻿using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}