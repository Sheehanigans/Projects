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
        public static int CreateOrderNumber()
        {
            OrderManager manager = OrderManagerFactory.Create();

            List<Order> ordNums = manager.GetOrderNumber().Orders;

            int largest = ordNums.Count();

            foreach (var ord in ordNums)
            {                
                if(ord.OrderNumber <= largest)
                {
                    ord.OrderNumber = largest;
                }
            }

            return largest + 1;
        }
    }
}
