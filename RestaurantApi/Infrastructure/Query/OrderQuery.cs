using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application.Interfaces.Query;
using Domain.Entities;
using Infrastructure.Persistency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly AppDbContext _context;
        public OrderQuery(AppDbContext context)
            => _context = context;
        public IQueryable<Order> Query()
            => _context.Orders.AsQueryable();
        public async Task<List<Order>> IncludeRelatedAsync(IQueryable<Order> query, CancellationToken ct = default)
        {
            var queryWithIncludes = query
                .Include(o => o.OverallStatusNav)
                .Include(o => o.DeliveryTypeNav)
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.StatusNav)
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.DishNav);
            return await queryWithIncludes.ToListAsync(ct);
        }
        public async Task<Order?> GetOrderAsync(long id)
        {
            var Order = await _context.Orders
            .Include(o => o.OverallStatusNav)
            .Include(o => o.DeliveryTypeNav)
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.StatusNav)
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.DishNav)
            .FirstOrDefaultAsync(o => o.OrderId == id);
            return Order;
        }
        
        
    }
}