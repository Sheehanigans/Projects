using CarDealership.BLL.Factories;
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
            //get managers 
            ListingManager manager = ListingManagerFactory.Create();

            //get response
            TResponse<List<Listing>> response = manager.GetNewListings();

            //validate responses 
            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message: {response.Message}");
            }
            else
            {
                //build vm
                ListingVM model = new ListingVM();
                model.SetListingItems(response.Payload);

                return View(model);
            }
        }

        public ActionResult Used()
        {
            //get managers 
            ListingManager manager = ListingManagerFactory.Create();

            //get response
            TResponse<List<Listing>> response = manager.GetUsedListings();

            //validate responses 
            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message: {response.Message}");
            }
            else
            {
                //build vm
                ListingVM model = new ListingVM();
                model.SetListingItems(response.Payload);

                return View(model);
            }
        }
    }
}