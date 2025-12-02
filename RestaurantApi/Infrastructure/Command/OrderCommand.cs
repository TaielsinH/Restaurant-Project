using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistency;

namespace Infrastructure.Command
{
    public class OrderCommand : IOrderCommand
    {
        private readonly AppDbContext _context;
        public OrderCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Order order)
            => await _context.Orders.AddAsync(order);
        public void Update(Order order)
        {
            order.UpdateDate = DateTime.UtcNow;
            _context.Orders.Update(order);
        }
    }
}