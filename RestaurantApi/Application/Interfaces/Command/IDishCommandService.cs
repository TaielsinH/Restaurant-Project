using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IDishCommand
    {
        Task AddAsync(Dish dish, CancellationToken ct);
        void Delete(Dish dish);
        void Update(Dish dish);
    }
}