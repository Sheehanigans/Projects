using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class ListingSearchParameters
    {
        public string QuickSearch { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string MinYear { get; set; }
        public string MaxYear { get; set; }
    }
}
