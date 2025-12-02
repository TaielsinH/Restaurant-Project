using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Query;
using Domain.Entities;
using Infrastructure.Persistency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class OrderItemQuery(AppDbContext context) : IOrderItemQuery
    {
        private readonly AppDbContext _context = context;
        public async Task<bool> OrderItemContainsDishAsync(Dish dish)
        {
            return await _context.OrderItems
                .AnyAsync(oi => oi.Dish == dish.DishId && oi.Status != 5);//I consider an order to be active when it's not closed
        }
        public async Task<OrderItem?> GetByIdAsync(long id)
        { return await _context.OrderItems.FindAsync(id); }
        
    }
}