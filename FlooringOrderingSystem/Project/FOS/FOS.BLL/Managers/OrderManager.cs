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

        public OrderGetListResponse GetOrderList(DateTime date)
        {
            OrderGetListResponse response = new OrderGetListResponse();

            response.Orders = _orderRepository.ListOrdersForDate(date);

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

        //might need to change to only look at a date or make another for order number that 
        //just looks for order numbers for a date...
        public OrderNumberResponse GetOrderNumber(DateTime date)
        {
            OrderNumberResponse response = new OrderNumberResponse();

            response.Orders = _orderRepository.ListOrdersForDate(date);

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

        public OrderGetSingleResponse DisplaySingleOrder(DateTime date, int orderNumber)
        {
            OrderGetSingleResponse response = new OrderGetSingleResponse();

            var orders = GetOrderList(date).Orders;

            if(orders == null)
            {
                response.Message = "Order date does not exist";
                response.Success = false;
            }
            else if (orders.Where(w => w.OrderNumber != orderNumber).Any())
            {
                response.Message = "Order number does not exist";
                response.Success = false;
            }
            else
            {
                response.Order = _orderRepository.GetSingleOrder(date, orderNumber);
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

        public OrderAddEditedResponse AddEditedOrderToRepository(Order order)
        {
            OrderAddEditedResponse response = new OrderAddEditedResponse();

            response.Success = _orderRepository.Edit(order);

            if (!response.Success)
            {
                response.Message = "Edit unsuccessful.";
            }

            return response;
        }

        public OrderRemoveResponse RemoveOrder(Order order)
        {
            OrderRemoveResponse response = new OrderRemoveResponse();

            response.Success = _orderRepository.Remove(order);

            if (!response.Success)
            {
                response.Message = "Remove unsuccessful";
            }

            return response;
        }
    } 
}
