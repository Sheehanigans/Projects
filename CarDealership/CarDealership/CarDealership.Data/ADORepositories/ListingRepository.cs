using CarDealership.Data.Settings;
using CarDealership.Models.Enums;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public IEnumerable<Listing> Search (ListingSearchParameters parameters)
        {
            List<Listing> listings = new List<Listing>();

            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                string query =
                    "SELECT TOP 20 	SELECT ListingId, l.ModelId, mo.ModelName, mo.ModelYear, " +
                    "ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, " +
                    "ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, " +
                    "Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, " +
                    "ImageFileUrl, IsFeatured, IsSold, l.DateAdded " +
                    "FROM Listings l " +
                    "inner join Models mo on mo.ModelId = l.ModelId " +
                    "inner join Makes ma on ma.MakeId = mo.MakeId  " +
                    "inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId  " +
                    "inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId  " +
                    "inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId  " +
                    "where  l.Condition = 1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND SalePrice >= @MinPrice";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }
                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND SalePrice <= @MaxPrice";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }
                //min year 
                //max year 

                //lIKE keyword special characters for quicksearch

                //_ for a single character 
                //% for 0 or more unknown characters

                if (!string.IsNullOrEmpty(parameters.QuickSearch))
                {
                    query += "AND ma.MakeName LIKE @QuickSearch OR mo.ModelName LIKE @QuickSearch OR mo.ModelYear LIKE @QuickSearch";
                    cmd.Parameters.AddWithValue("@QuickSearch", parameters.QuickSearch);
                }

                query += "ORDER BY DateAdded DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Listing row = new Listing();

                        row.ListingId = (int)dr["ListingId"];
                        row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.ModelYear = dr["ModelYear"].ToString();
                        row.MakeId = (int)dr["MakeId"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.InteriorColorId = (int)dr["InteriorColorId"];
                        row.InteriorColorName = dr["InteriorColorName"].ToString();
                        row.ExteriorColorId = (int)dr["ExteriorColorId"];
                        row.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        row.Condition = (Condition)dr["Condition"];
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.IsSold = (bool)dr["IsSold"];

                        if (dr["ImageFileUrl"] != DBNull.Value)
                            row.ImageFileUrl = dr["ImageFileUrl"].ToString();

                        listings.Add(row);
                    }
                }
            }

            return listings;
        }
    }
}
