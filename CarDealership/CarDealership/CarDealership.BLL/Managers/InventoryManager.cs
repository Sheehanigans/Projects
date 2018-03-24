using CarDealership.Data.ADORepositories;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class InventoryManager
    {
        private IListingRepository Repo { get; set; }

        public InventoryManager(IListingRepository listingRepository)
        {
            Repo = listingRepository;
        }

        public ListingGetAllResponse GetAllistings()
        {
            var response = new ListingGetAllResponse();

            response.Listings = Repo.GetAllListings();

            if (!response.Listings.Any())
            {
                response.Success = false;
                response.Message = "Could not load any vehicles";
            }

            return response;
        }

        public ListingFeaturedResponse GetFeaturedListings()
        {
            var response = new ListingFeaturedResponse();

            response.Listings = Repo.GetFeaturedListings();

            if (!response.Listings.Any())
            {
                response.Success = false;
                response.Message = "Could not load any vehicles";
            }

            return response;
        }
    }
}
