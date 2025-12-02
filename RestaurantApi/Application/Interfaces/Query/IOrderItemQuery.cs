using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IOrderItemQuery
    {
        Task<bool> OrderItemContainsDishAsync(Dish dish);
        Task<OrderItem?> GetByIdAsync(long id);
    }
}