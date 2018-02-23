using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> allOrders = null;
            List<Customer> allCustomers = null;

            //total of all orders for each customer 

            allOrders.GroupBy(o => o.OrderCustomer.ID).Select(g => g.Sum(order => order.Total)); 
            //group all the customers into groups, select the particular members of a group and total it 
        }
    }
}
