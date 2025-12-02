using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Command;
using Application.Interfaces.Logs;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.OrderServices
{
    public class CreateOrderService
    {
        private readonly IDishQuery _dishQuery;
        private readonly IAppLogger<CreateOrderService> _logger;
        private readonly IDeliveryTypeQuery _deliveryQuery;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderService
        (IAppLogger<CreateOrderService> logger,
         IDishQuery dishQuery, IDeliveryTypeQuery deliveryTypeQuery,
         IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _dishQuery = dishQuery;
            _deliveryQuery = deliveryTypeQuery;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateOrderResponse> CreateAsync(CreateOrderRequest request)
        {
            if (!await _deliveryQuery.ExistsByIdAsync(request.Delivery.Id))
            {
                var ex = new BusinessRuleException("tipo de delivery no encontrado");
                _logger.LogError(ex, $"delivery id from request: {request.Delivery.Id}");
                throw ex;
            }
            List<CreateOrderItemDto> listItems = request.Items;
            var order = new Order
            {
                DeliveryType = request.Delivery.Id,
                DeliveryTo = request.Delivery.To,
                OverallStatus = 1, //always initialize in Pending == 1
                Notes = request.Notes,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
            await _unitOfWork.OrderCommand.AddAsync(order);
            await CreateItems(listItems, order);
            _logger.LogInformation($"Created Order: id: {order.OrderId}, CreatedAt: {order.CreateDate}");

            var rowsAffect = await _unitOfWork.Save();
            if (rowsAffect != 0)
                _logger.LogInformation("Saved succesfully from  create");
            
            var response = new CreateOrderResponse
            {
                OrderNumber = order.OrderId,
                TotalAmount = order.Price,
                CreatedAt = order.CreateDate
            };
            return response;
        }
        private async Task CreateItems(List<CreateOrderItemDto> items, Order order)
        {
            decimal total = 0;
            foreach (var i in items)
            {
                var dish = await _dishQuery.GetByIdAsync(i.Id);
                if (dish == null || !dish.Available)
                {
                    var ex = new BusinessRuleException("El plato especificado no existe o no está disponible");
                    _logger.LogError(ex, $"dishId from orderItemRequest: {i.Id}");
                    throw ex;
                }

                total += dish.Price * i.Quantity;
                var orderItem = new OrderItem
                {
                    OrderNav = order, //I set OrderNav because I can't set Order = order.OrderId, orderId is NOT defined in this point
                    Dish = i.Id,
                    Notes = i.Notes,
                    Quantity = i.Quantity,
                    Status = 1, //always initialize in Pending == 1
                    CreateDate = DateTime.UtcNow
                };
                await _unitOfWork.OrderItemCommand.AddAsync(orderItem);
                _logger.LogInformation
                ($"se creó el OrderItem: id: {orderItem.OrderItemId} \nOrder: {orderItem.Order} \nDishId: {orderItem.Dish} \nQuantity: {orderItem.Quantity} \nStatus = {orderItem.Status} \nCreatedAt: {orderItem.CreateDate}");
            }
            order.Price = total;
        }
    }
}