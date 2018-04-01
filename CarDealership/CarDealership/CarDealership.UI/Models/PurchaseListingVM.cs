﻿using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseListingVM
    {
        public Listing ListingToPurchase { get; set; }
        public SaleInformation SaleInformationForm { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}