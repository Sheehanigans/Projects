using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ListingVM
    {
        public List<Listing> Listings { get; set; }

        public ListingVM()
        {
            Listings = new List<Listing>();
        }

        public void SetListingItems(IEnumerable<Listing> listings)
        {
            foreach (var listing in listings)
            {
                Listings.Add(listing);
            }
        }
    }
}