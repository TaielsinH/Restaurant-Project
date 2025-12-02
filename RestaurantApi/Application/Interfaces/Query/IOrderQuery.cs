using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IOrderQuery
    {
        IQueryable<Order> Query();
        Task<List<Order>> IncludeRelatedAsync(IQueryable<Order> query, CancellationToken ct = default);
        Task<Order?> GetOrderAsync(long id);
    }
}