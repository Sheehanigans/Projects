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
    public class OrderManagerTests
    {
        [TestCase(2020, 02, 02, true)]
        [TestCase(2050, 02, 02, false)]
        public static void GetOrderListWithOrders(int year, int month, int day, bool expectedValue)
        {
            OrderManager manager = new OrderManager(new AlwaysReturnsOrder());
            DateTime date = new DateTime(year, month, day);

            var test = manager.GetOrderList(date);

            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Orders);
        }

        [TestCase(2020, 02, 02, false)]
        [TestCase(2050, 02, 02, false)]
        public static void GetOrderListWithNull(int year, int month, int day, bool expectedValue)
        {
            OrderManager manager = new OrderManager(new AlwaysReturnsNullOrder());
            DateTime date = new DateTime(year, month, day);

            var test = manager.GetOrderList(date);

            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Orders);
        }

        //[TestCase(2020, 02, 02, 2,true)]
        //[TestCase(2050, 02, 02, 2, false)]
        //public static void GetSingleOrderWithOrder(int year, int month, int day, int orderNumber, bool expectedResult)
        //{
        //    OrderManager manager = new OrderManager(new AlwaysReturnsOrder());

        //    DateTime date = new DateTime(year, month, day);
        //    var test = manager.GetSingleOrder(date, orderNumber);

        //    Assert.IsTrue(test.Success);
        //    Assert.IsNotEmpty(test.Order.CustomerName);
        //}

        [TestCase(2050, 02, 02, 2, false)]
        public static void GetSingleOrderWithNull(int year, int month, int day, int orderNumber, bool expectedResult)
        {
            OrderManager manager = new OrderManager(new AlwaysReturnsNullOrder());

            DateTime date = new DateTime(year, month, day);
            var test = manager.GetSingleOrder(date, orderNumber);

            Assert.IsNull(test.Order);
        }

        [TestCase(2020, 09, 09, 5, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        [TestCase(2003, 09, 09, 5, "ryan", "MI", 6.25, "METH", 10, 5.15, 4.75, false)]
        public static void CanAddOrderWithOrders(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
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

            OrderManager manager = new OrderManager(new AlwaysReturnsOrder());

            var test = manager.AddOrderToRepository(order);

            Assert.IsTrue(test.Success);

        }

        [TestCase(2020, 09, 09, 5, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        [TestCase(2003, 09, 09, 5, "ryan", "MI", 6.25, "METH", 10, 5.15, 4.75, false)]
        public static void CanAddOrderWithNull(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
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

            OrderManager manager = new OrderManager(new AlwaysReturnsNullOrder());

            var test = manager.AddOrderToRepository(order);

            Assert.IsFalse(test.Success);
        }

        //[TestCase(2020, 02, 02, true, 3)]
        //[TestCase(2050, 02, 02, false, 5)]
        //public static void GetOrderNumberWithOrders(int year, int month, int day, bool expectedValue, int expectedOrderNumber)
        //{
        //    DateTime date = new DateTime(year, month, day);

        //    OrderManager manager = new OrderManager(new AlwaysReturnsOrder());

        //    var test = manager.GetOrderNumber(date);

        //    Assert.IsTrue(test.Success);
        //    Assert.AreEqual(expectedOrderNumber, test.Orders.Where(w => w.OrderNumber == expectedOrderNumber + 1));
        //}


        [TestCase(2060, 06, 06, 6, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        public static void AddEditedOrderToRepositoryWithOrders(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
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

            OrderManager manager = new OrderManager(new AlwaysReturnsOrder());

            var test = manager.AddEditedOrderToRepository(order);

            Assert.IsTrue(test.Success);
        }

        [TestCase(2060, 06, 06, 6, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        public static void AddEditedOrderToRepositoryWithNull(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
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

            OrderManager manager = new OrderManager(new AlwaysReturnsNullOrder());

            var test = manager.AddEditedOrderToRepository(order);

            Assert.IsFalse(test.Success);
        }

        [TestCase(2020, 02, 02, 2, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, true)]
        public static void RemoveOrderFromRepositoryWithOrders(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
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

            OrderManager manager = new OrderManager(new AlwaysReturnsOrder());

            var test = manager.RemoveOrder(order);

            Assert.IsTrue(test.Success);
        }

        [TestCase(2020, 02, 02, 2, "ryan", "OH", 6.25, "Wood", 10, 5.15, 4.75, false)]
        public static void RemoveOrderFromRepositoryWithNull(int year, int month, int day, int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
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

            OrderManager manager = new OrderManager(new AlwaysReturnsNullOrder());

            var test = manager.RemoveOrder(order);

            Assert.IsFalse(test.Success);
        }
    }
}
