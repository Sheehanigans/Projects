﻿using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Responses;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //get managers
            ListingManager listingManager = ListingManagerFactory.Create();
            SpecialManager specialManager = SpecialManagerFactory.Create();

            //get responses 
            ListingFeaturedResponse listingFeaturedResponse = listingManager.GetFeaturedListings();
            SpecialGetAllResponse specialResponse = specialManager.GetAllSpecials();

            //validate responses
            if (!listingFeaturedResponse.Success || !specialResponse.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{listingFeaturedResponse.Message} {specialResponse.Message}");
            }
            else
            {
               //build vm
               HomeVM model = new HomeVM();

                model.SetFeaturedListingItems(listingFeaturedResponse.Listings);
                model.SetSpecialItems(specialResponse.Specials);

                return View(model);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }

        public ActionResult Specials()
        {
            //get manager
            SpecialManager manager = SpecialManagerFactory.Create();

            //get response 
            SpecialGetAllResponse response = manager.GetAllSpecials();

            //validate 
            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message: {response.Message}");
            }
            else
            {
                //create vm
                SpecialsVM model = new SpecialsVM();
                model.SetSpecialItems(response.Specials);

                return View(model);
            }
        }
    }
}