using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDisplayResponse DisplayOrders (string date)
        {
            OrderDisplayResponse response = new OrderDisplayResponse();

            response.Orders = _orderRepository.DisplayOrders(date);

            if(response.Orders == null)
            {
                response.Success = false;
                response.Message = $"There were no files for {date}.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
