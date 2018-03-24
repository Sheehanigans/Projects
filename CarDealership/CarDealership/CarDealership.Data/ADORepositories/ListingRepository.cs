using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class ListingRepository : IListingRepository
    {
        public List<Listing> GetAllListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetAllListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetNewListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetNewListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetUsedListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetUsedListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetFeaturedListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetFeaturedListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetSoldListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetSoldListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }
    }
}
