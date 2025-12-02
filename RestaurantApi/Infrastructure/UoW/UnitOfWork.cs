using Application.Interfaces;
using Application.Interfaces.Command;
using Infrastructure.Persistency;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IOrderCommand OrderCommand { get; }
        public IOrderItemCommand OrderItemCommand { get; }
        public IDishCommand DishCommand { get; }
        public UnitOfWork
        (AppDbContext context, IOrderCommand orderCommand, IOrderItemCommand orderItemCommand, IDishCommand dishCommand)
        {
            _context = context;
            OrderCommand = orderCommand;
            OrderItemCommand = orderItemCommand;
            DishCommand = dishCommand;
        }
        public async Task<int> Save()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();

    }
}