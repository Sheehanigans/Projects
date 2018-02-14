using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA
{
    public class TestOrderRepository : IOrderRepository
    {
        private static Order _order1 = new Order
        {
            Date = new DateTime(2018,02,02),
            OrderNumber = 1,
            CustomerName = "Ryan",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
        };

        private static Order _order2 = new Order
        {
            Date = new DateTime(2018,03,03),
            OrderNumber = 2,
            CustomerName = "Ryan",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
        };

        //Empty order to save in mem
        private static Order _order3 = new Order();

        public List<Order> ListOrders()
        {
            List<Order> orders = new List<Order>();

            orders.Add(_order1);
            orders.Add(_order2);
            orders.Add(_order3);

            return orders;
        }

        public List<Order> DisplayOrders(DateTime date)
        {
            List<Order> ordersForDate = new List<Order>();

            var allOrders = ListOrders();

            foreach(Order ord in allOrders)
            {
                if (ord.Date == date)
                {
                    ordersForDate.Add(ord);
                }
            }

            if(!allOrders.Any(o => o.Date == date))
            {
                return null;
            }

            return ordersForDate;
        }

        public bool Add(Order order)
        {
            _order3 = order;

            return true;            
        }

        public Order DisplaySingleOrder(DateTime date, int orderNumber)
        {           
            var order = ListOrders()
                .Where(w => w.Date == date)
                .Where(w => w.OrderNumber == orderNumber)
                .OfType<Order>()
                .First();

            return order;
        }

        public void Edit(Order order, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order order, DateTime date)
        {
            throw new NotImplementedException();
        }

    }
}
