using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistency;

namespace Infrastructure.Command
{
    public class OrderItemCommand(AppDbContext context) : IOrderItemCommand
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(OrderItem orderItem)
            => await _context.OrderItems.AddAsync(orderItem);
        public void Update(OrderItem orderItem)
            => _context.OrderItems.Update(orderItem);
            
    }
}