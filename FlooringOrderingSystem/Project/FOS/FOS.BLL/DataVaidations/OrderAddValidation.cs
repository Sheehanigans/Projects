using FOS.MODELS;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataVaidations
{
    public class OrderAddValidation
    {
        public static void AddOrder(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderAddResponse response = manager.AddOrderToRepository(order);

            if (!response.Success)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }
        }
    }
}
