using FOS.BLL;
using FOS.MODELS;
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
        public static void CanDisplayTestDataFromOrderRepository()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderDisplayListResponse response = manager.DisplayOrders(new DateTime (2018,02,02));

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);
        }

        //[TestCase("04042018", 5, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        //public static void CanAddOrder(string date, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
        //{
        //    Order order = new Order();

        //    order.Date = date;
        //    order.OrderNumber = orderNumber;
        //    order.CustomerName = customerName;
        //    order.State = state;
        //    order.TaxRate = taxRate;
        //    order.ProductType = productType;
        //    order.Area = area;
        //    order.CostPerSquareFoot = costPerSquareFoot;
        //    order.LaborCostPerSquareFoot = laborCostPerSquareFoot;

        //    OrderManager manager = OrderManagerFactory.Create();

        //    OrderAddResponse response = manager.AddOrderToRepository(order);

        //    Assert.IsNotNull(response.NewOrder);
        //    Assert.IsTrue(response.Success);
        //}

    }
}
