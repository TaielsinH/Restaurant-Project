using System.Linq.Expressions;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Interfaces.Query;
using Domain.Entities;
using Infrastructure.Persistency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class DishQuery : IDishQuery
    {
        private readonly AppDbContext _context;
        public DishQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> NameExists(string name)
        {
            return await _context.Dishes.AnyAsync(d => d.Name == name);
        }
        public async Task<bool> DishExists(Guid id)
        {
            return await _context.Dishes.AnyAsync(d => d.DishId == id);
        }
        //Dejo el nullable porque quiero que application maneje las exceptions. 

        public async Task<Dish?> GetByIdAsync(Guid request, CancellationToken ct = default)
        {
            var dish = await _context.Dishes.Include(d => d.CategoryNav)
                                      .FirstOrDefaultAsync(d => d.DishId == request, ct);
            return dish;
        }
        public async Task<List<DishResponse>> ListAsync(DishQueryParameters parameters, CancellationToken ct = default)
        {
            IQueryable<Dish> q = _context.Dishes.AsNoTracking()
                                                .Include(d => d.CategoryNav);
            if (parameters.OnlyActive)
            {
                q = q.Where(d => d.Available);
            }
            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                q = q.Where(d => d.Name.Contains(parameters.Name));
            }
            if (parameters.Category.HasValue)
            {
                q = q.Where(d => d.Category == parameters.Category.Value);
            }
            if (parameters.SortByPrice == SortDirection.asc)
            {
                q = q.OrderBy(d => d.Price);
            }
            else if (parameters.SortByPrice == SortDirection.desc)
            {
                q = q.OrderByDescending(d => d.Price);
            }
            return await q.Select(d => new DishResponse
            {
                Id = d.DishId,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                Image = d.ImageUrl,
                IsActive = d.Available,
                Category = new CategoryResponseDto { Id = d.Category, Name = d.CategoryNav.Name },
                CreatedAt = d.CreateDate,
                UpdatedAt = d.UpdateDate
            }).ToListAsync(ct);
        }
    }
}