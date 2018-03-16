using RyanSheehanPowerball.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RyanSheehanPowerball.UI.Controllers
{
    public class GameController : Controller
    {
        [HttpPost]
        public ActionResult Add(PickModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}