﻿using CarDealership.Data.ADORepositories;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class ListingManager
    {
        private IListingRepository Repo { get; set; }

        public ListingManager(IListingRepository listingRepository)
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
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<List<Listing>> GetNewListings()
        {
            var response = new TResponse<List<Listing>>
            {
                Payload = Repo.GetNewListings()
            };

            if (!response.Payload.Any())
            {
                response.Success = false;
                response.Message = "Could not load any new vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<List<Listing>> GetUsedListings()
        {
            var response = new TResponse<List<Listing>>
            {
                Payload = Repo.GetUsedListings()
            };

            if (!response.Payload.Any())
            {
                response.Success = false;
                response.Message = "Could not load any used vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
