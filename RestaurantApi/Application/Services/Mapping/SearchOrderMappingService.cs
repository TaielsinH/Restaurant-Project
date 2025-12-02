using Application.Dtos.Models.SearchOrderResponses;
using Application.Interfaces.Mapping;
using Domain.Entities;

namespace Application.Services.Mapping
{
    public class SearchOrderMappingService : IOrderMappingService
    {
        public OrderResponse MapToDto(Order order)
        {
            return new OrderResponse
            {
                OrderNumber = order.OrderId,
                TotalAmount = order.Price,
                DeliveryTo = order.DeliveryTo,
                Notes = order.Notes,
                Status = MapStatus(order.OverallStatusNav),
                DeliveryType = MapDelivery(order),
                Items = MapItems(order.OrderItems),
                CreatedAt = order.CreateDate,
                UpdatedAt = order.UpdateDate
            };
        }
        public List<OrderResponse> MapToDto(List<Order> orders)
        {
            return orders.Select(MapToDto).ToList();
        }
        private SOStatusResponse MapStatus(Status status)
        {
            return new SOStatusResponse
            {
                Id = status.Id,
                Name = status.Name
            };
        }
        private SODeliveryTypeResponse MapDelivery(Order order)
        {
            return new SODeliveryTypeResponse
            {
                Id = order.DeliveryType,
                Name = order.DeliveryTypeNav.Name
            };
        }
        private SOItemResponse MapItems(OrderItem item)
        {
            return new SOItemResponse
            {
                Id = item.OrderItemId,
                Quantity = item.Quantity,
                Notes = item.Notes,
                Status = MapStatus(item.StatusNav),
                Dish = MapDish(item.DishNav)
            };
        }
        private SODishResponse MapDish(Dish dish)
        {
            return new SODishResponse
            {
                Id = dish.DishId,
                Name = dish.Name,
                Image = dish.ImageUrl
            };
        }
        private List<SOItemResponse> MapItems(ICollection<OrderItem> items)
        {
            return items.Select(MapItems).ToList();
        }
    }
}