using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Logs;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.OrderServices
{
    public class UpdateOrderService
    (IOrderItemQuery query, IUnitOfWork unitOfWork, IOrderQuery orderQuery, IDishQuery dishQuery, IAppLogger<UpdateOrderService> logger)
    {
        private readonly IOrderItemQuery _query = query;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOrderQuery _orderQuery = orderQuery;
        private readonly IDishQuery _dishQuery = dishQuery;
        private readonly IAppLogger<UpdateOrderService> _logger = logger;
        public async Task<UpdateOrderResponse> UpdateAsync(OrderUpdateRequest request, string orderId)
        {
            if (!long.TryParse(orderId, out var id))
                throw new BusinessRuleException("Formato de ID inválido");
            var order = await _orderQuery.GetOrderAsync(id) ?? throw new KeyNotFoundException("Orden no encontrada");
            if (order.OverallStatus != 1) //en swagger el mensaje de error para este caso dice "No se puede modificar una orden que ya está en preparación", voy a seguir esa lógica
                throw new BusinessRuleException("No se puede modificar una orden que ya está en preparación");
            var itemsRequest = request.Items;
            foreach (var i in itemsRequest)
            {
                var item = order.OrderItems.FirstOrDefault(oi => oi.Dish == i.Id);
                await ProcessItem(i, item, order);
            }
            //recalcular el total
            decimal total = 0;
            foreach (var i in order.OrderItems)
            {
                total += i.DishNav.Price * i.Quantity;
            }
            order.Price = total;
            _unitOfWork.OrderCommand.Update(order);
            await _unitOfWork.Save();
            var response = new UpdateOrderResponse
            {
                OrderNumber = order.OrderId,
                TotalAmount = order.Price,
                UpdateAt = DateTime.UtcNow
            };
            return response;
        }
        private async Task ProcessItem(CreateOrderItemDto dto, OrderItem? item, Order order)
        {
            if (item == null)
            {
                await CreateItem(dto, order);
            }
            else
            {
                UpdateItem(dto, item);
            }
        }
        private async Task CreateItem(CreateOrderItemDto dto, Order order)
        {
            var dish = await _dishQuery.GetByIdAsync(dto.Id);
            if (dish == null || !dish.Available)
            {
                var ex = new BusinessRuleException("El plato especificado no existe o no está disponible");
                _logger.LogError(ex, $"dishId from orderItemRequest: {dto.Id}");
                throw ex;
            }
            var orderItem = new OrderItem
            {
                Order = order.OrderId,
                Dish = dto.Id,
                Notes = dto.Notes,
                Quantity = dto.Quantity,
                Status = 1,
                CreateDate = DateTime.UtcNow
            };
            await _unitOfWork.OrderItemCommand.AddAsync(orderItem);
            _logger.LogInformation
            ($"se creó el OrderItem: id: {orderItem.OrderItemId} \nOrder: {orderItem.Order} \nDishId: {orderItem.Dish} \nQuantity: {orderItem.Quantity} \nStatus = {orderItem.Status} \nCreatedAt: {orderItem.CreateDate}");

        }
        private void UpdateItem(CreateOrderItemDto dto, OrderItem item)
        {
            item.Quantity = dto.Quantity;
            item.Notes = dto.Notes;
            _unitOfWork.OrderItemCommand.Update(item);
        }
    }
}