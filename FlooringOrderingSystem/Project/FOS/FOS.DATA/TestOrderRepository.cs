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
            Date = "02022018",
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
            Date = "03032018",
            OrderNumber = 2,
            CustomerName = "Ryan",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
        };

        public List<Order> ListOrders()
        {
            List<Order> orders = new List<Order>();

            orders.Add(_order1);
            orders.Add(_order2);

            return orders;
        }

        public List<Order> DisplayOrders(string date)
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

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order order, string date)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order order, string date)
        {
            throw new NotImplementedException();
        }
    }
}
