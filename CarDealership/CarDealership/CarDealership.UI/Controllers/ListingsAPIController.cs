﻿using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class ListingsAPIController : ApiController
    {
        ListingManager _listingManager;

        [Route("api/listings/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string quickSearch, int minPrice, int maxPrice, string minYear, string maxYear)
        {
            //check model state befor try
            _listingManager = ListingManagerFactory.Create();

            try
            {
                var parameters = new ListingSearchParameters()
                {
                    QuickSearch = quickSearch,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var result = _listingManager.Search(parameters);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}