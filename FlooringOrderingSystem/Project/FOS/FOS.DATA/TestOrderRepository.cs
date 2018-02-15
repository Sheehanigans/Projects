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
        private static List<Order> orders = new List<Order>()
        {
            new Order(new DateTime(2018,02,02),1,"Ryan","OH",6.25M,"Wood",100.00M,5.15M,4.75M),
            new Order(new DateTime(2018,03,03),1,"Adam","MI",6.25M,"Carpet",100.00M,5.15M,4.75M)

        };

        public List<Order> ListOrders()
        {
            return orders;
        }

        public List<Order> DisplayOrders(DateTime date)
        {
            List<Order> ordersForDate = new List<Order>();            

            foreach(Order ord in orders)
            {
                if (ord.Date == date)
                {
                    ordersForDate.Add(ord);
                }
            }

            if(!orders.Any(o => o.Date == date))
            {
                return null;
            }

            return ordersForDate;
        }

        public bool Add(Order order)
        {
            orders.Add(order);

            return true;            
        }

        public Order GetSingleOrder(DateTime date, int orderNumber)
        {
            var order = ListOrders()
                .Where(w => w.Date == date)
                .Where(w => w.OrderNumber == orderNumber)
                .OfType<Order>()
                .First();

            return order;
        }

        public bool Edit(Order order)
        {
            var oldOrder = ListOrders()
                .Where(w => w.OrderNumber == order.OrderNumber)
                .First();

            oldOrder = order;

            var editedOrder = ListOrders()
                .Where(w => w.OrderNumber == order.OrderNumber)
                .First();

            if(editedOrder.OrderNumber == order.OrderNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(Order order, DateTime date)
        {
            throw new NotImplementedException();
        }

    }
}
