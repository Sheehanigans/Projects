using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
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

        public OrderNumberResponse GetOrderNumber()
        {
            OrderNumberResponse response = new OrderNumberResponse();

            response.Orders = _orderRepository.ListOrders();

            // hmmm might need to add validation if null, what if there are no orders yet?
            response.Success = true;

            return response;
        }
    }
}
