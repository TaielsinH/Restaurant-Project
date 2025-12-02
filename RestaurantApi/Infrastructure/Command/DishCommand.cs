using Application.Interfaces.Command;
using Domain.Entities;
using Infrastructure.Persistency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class DishCommand(AppDbContext context) : IDishCommand
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Dish dish, CancellationToken ct)
            => await _context.Dishes.AddAsync(dish, ct);
        public void Delete(Dish dish)
            => _context.Dishes.Remove(dish);
        public void Update(Dish dish)
            => _context.Dishes.Update(dish);
    }
}