using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.OrderServices
{
    public class UpdateOrderItemService
    (IUnitOfWork unitOfWork, IOrderItemQuery orderItemQuery, IOrderQuery query, IStatusQuery statusQuery)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOrderItemQuery _orderItemQuery = orderItemQuery;
        private readonly IOrderQuery _query = query;
        private readonly IStatusQuery _statusQuery = statusQuery;
        public async Task<UpdateOrderResponse> UpdateItem(string oId, string oItemId, UpdateOrderItemRequest request)
        {
            if (!long.TryParse(oId, out var orderId))
                throw new BusinessRuleException("Formato de ID inválido");

            if (!long.TryParse(oItemId, out var orderItemId))
                throw new BusinessRuleException("Formato de ID inválido");

            var item = await _orderItemQuery.GetByIdAsync(orderItemId) ?? throw new KeyNotFoundException("OrderItem no encontrado");
            //updating item
            if (!await _statusQuery.ExistsById(request.Status))
                throw new BusinessRuleException("El estado especificado no es válido");
            item.Status = request.Status;
            _unitOfWork.OrderItemCommand.Update(item);

            //updating order
            var order = await _query.GetOrderAsync(orderId) ?? throw new KeyNotFoundException("Order no encontrada");
            UpdatingOrderStatus(order);
            await _unitOfWork.Save();
            var response = new UpdateOrderResponse
            {
                OrderNumber = orderId,
                TotalAmount = order.Price,
                UpdateAt = DateTime.UtcNow
            };
            return response;
        }
        private void UpdatingOrderStatus(Order order)
        {
            var items = order.OrderItems;
            var currentStatus = items.ToList()[0].Status;
            foreach (var i in items)
            {
                if (i.Status != currentStatus)
                {
                    currentStatus = order.OverallStatus;
                    break; //because it only changes state if all items have the same
                }
            }
            order.OverallStatus = currentStatus;
            _unitOfWork.OrderCommand.Update(order);
        }
                
    }
}