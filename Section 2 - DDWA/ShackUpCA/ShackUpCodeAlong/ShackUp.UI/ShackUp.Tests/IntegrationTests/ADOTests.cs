using NUnit.Framework;
using ShackUp.Data.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShackUp.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {
        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);

            Assert.AreEqual("KY", states[0].StateId);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }

        [Test]
        public void CanLoadBathroomTypes()
        {
            var repo = new BathroomTypesRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(3, types.Count);

            Assert.AreEqual(1, types[0].BathroomTypeId);
            Assert.AreEqual("Indoor", types[0].BathroomTypeName);
        }

        [Test]
        public void CanLoadListing()
        {
            var repo = new ListingsRepositoryADO();
            var listing = repo.GetById(1);

            Assert.IsNotNull(listing);

            //VALUES (1, '00000000-0000-0000-0000-000000000000', 'OH', 3, 'Test Shack 1', 
            //'Cleveland', 120, 400, 0, 1, 'placeholder.png');
            Assert.AreEqual(1, listing.ListingId);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", listing.UserId);
            Assert.AreEqual("OH", listing.StateId);
            Assert.AreEqual(3, listing.BathroomTypeId);
            Assert.AreEqual("Test Shack 1", listing.Nickname);
            Assert.AreEqual("Cleveland", listing.City);
            Assert.AreEqual(120M, listing.Rate);
            Assert.AreEqual(400M, listing.SquareFootage);
            Assert.AreEqual(false, listing.HasElectric);
            Assert.AreEqual(true, listing.HasHeat);
            Assert.AreEqual("placeholder.png", listing.ImageFileName);
        }

        [Test]
        public void NotFoundListingReturnsNull()
        {
            var repo = new ListingsRepositoryADO();
            var listing = repo.GetById(100000);

            Assert.IsNull(listing);
        }
    }
}
