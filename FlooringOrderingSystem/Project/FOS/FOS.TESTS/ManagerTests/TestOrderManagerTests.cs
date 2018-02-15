using FOS.BLL;
using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Responses;
using FOS.TESTS.MockRepos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS
{
    [TestFixture]
    public class TestOrderManagerTests
    {
        [Test]
        public static void CanDisplayTestDataFromOrderRepository()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderGetListResponse response = manager.GetOrderList(new DateTime(2018, 02, 02));

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);
        }

        [TestCase(2020, 09, 09, 5, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        [TestCase(2003, 09, 09, 5, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, false)]
        [TestCase(2003, 09, 09, 5, "ryan", "MY", 6.25, "Wood", 10, 5.15, 4.75, false)]
        [TestCase(2003, 09, 09, 5, "ryan", "MI", 6.25, "METH", 10, 5.15, 4.75, false)]
        public static void CanAddOrder(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
        {
            DateTime date = new DateTime(year, month, day);

            Order order = new Order();

            order.Date = date;
            order.OrderNumber = orderNumber;
            order.CustomerName = customerName;
            order.State = state;
            order.TaxRate = taxRate;
            order.ProductType = productType;
            order.Area = area;
            order.CostPerSquareFoot = costPerSquareFoot;
            order.LaborCostPerSquareFoot = laborCostPerSquareFoot;

            OrderManager manager = OrderManagerFactory.Create();

            OrderAddResponse response = manager.AddOrderToRepository(order);

            Assert.IsTrue(response.Success);
        }

        
        public static void GetSingleOrder(int year, int month, int day, int orderNumber, bool expectedResult)
        {
            var testRepo = new AlwaysReturnsOrder();


        }
    }
}
