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

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDisplayListResponse DisplayOrders(DateTime date)
        {
            OrderDisplayListResponse response = new OrderDisplayListResponse();

            response.Orders = _orderRepository.DisplayOrders(date);

            if (response.Orders == null)
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

        public OrderAddResponse AddOrderToRepository(Order order)
        {
            OrderAddResponse response = new OrderAddResponse();

            response.Success = _orderRepository.Add(order);

            if (!response.Success)
            {
                response.Message = "Add failed";
            }

            return response;
        }

        public OrderDisplaySingleResponse DisplaySingleOrder(DateTime date, int orderNumber)
        {
            OrderDisplaySingleResponse response = new OrderDisplaySingleResponse();

            //put response into a variable and look at the contents 
            //need to get order numbers BY DATE too

            //Order order = GetOrderNumber().Orders.Where(w => w.OrderNumber == orderNumber).Where(w => w.Date == date).First();

            if (DisplayOrders(date).Orders == null)
            {
                response.Message = "Order date does not exist";
                response.Success = false;
            }
            else if (GetOrderNumber().Orders.Where(w => w.OrderNumber == orderNumber).Where(w => w.Date == date).First() == null)
            {
                response.Message = "Order number does not exist";
                response.Success = false;
            }
            else
            {
                response.Order = _orderRepository.DisplaySingleOrder(date, orderNumber);

                if (response.Order == null)
                {
                    response.Success = false;
                    response.Message = "Could not find order";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }
    } 
}
