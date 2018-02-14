using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS.Interfaces
{
    public interface IOrderRepository
    {
        Order DisplaySingleOrder(DateTime date, int orderNumber);

        List<Order> DisplayOrders(DateTime date);

        List<Order> ListOrders();

        bool Add(Order order);

        void Edit(Order order, DateTime date);

        void Remove(Order order, DateTime date);
    }
}
