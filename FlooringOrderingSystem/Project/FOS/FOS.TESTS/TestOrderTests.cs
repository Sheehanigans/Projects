using FOS.BLL;
using FOS.MODELS.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS
{
    [TestFixture]
    public class TestOrderTests
    {
        [Test]
        public static void CanDisplayTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderDisplayResponse response = manager.DisplayOrders("02022018");

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);
        }

    }
}
