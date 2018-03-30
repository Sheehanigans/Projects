using CarDealership.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Listing
    {
        public int ListingId { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public int BodyStyleId { get; set; }
        public string BodyStyleName { get; set; }
        public int InteriorColorId { get; set; }
        public string InteriorColorName { get; set; }
        public int ExteriorColorId { get; set; }
        public string ExteriorColorName { get; set; }
        public Condition Condition { get; set; }
        public Transmission Transmission { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string VehicleDescription { get; set; }
        public string ImageFileUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
    }
}