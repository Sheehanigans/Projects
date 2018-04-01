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
    public class SalesController : Controller
    {
        ListingManager _listingManager;
        StateManager _stateManager;

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            try
            {
                _listingManager = ListingManagerFactory.Create();
                _stateManager = StateManagerFactory.Create();

                var listingResponse = _listingManager.GetListingById(id);

                if (!listingResponse.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:{listingResponse.Message}");
                }
                else
                {
                    var model = new PurchaseListingVM
                    {
                        ListingToPurchase = listingResponse.Payload,
                        SaleInformationForm = new SaleInformation()
                    };

                    var stateResponse = _stateManager.GetAllStates();

                    model.States = stateResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.StateAbbreviation,
                        Value = m.StateId.ToString()
                    });

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult Purchase(PurchaseListingVM model)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}