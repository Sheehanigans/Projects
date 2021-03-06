﻿using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddListingVM
    {
        public Listing Listing { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> InteriorColors { get; set; }
        public IEnumerable<SelectListItem> ExteriorColors { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }

        [Required(ErrorMessage = "Please upload a picture")]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}