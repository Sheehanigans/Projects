using FOS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataValidations
{
    public class OrderNumberVaidation
    {
        public static int CreateOrderNumber(DateTime date)
        {
            OrderManager manager = OrderManagerFactory.Create();

            List<Order> orders = manager.GetOrderNumber(date).Orders;

            int newOrderNumber = 1;

            if (orders != null)
            {
                newOrderNumber = orders.Count() + 1;

                foreach (var ord in orders)
                {
                    if (ord.OrderNumber <= newOrderNumber)
                    {
                        ord.OrderNumber = newOrderNumber;
                    }
                }
            }

            return newOrderNumber;
        }
    }
}
