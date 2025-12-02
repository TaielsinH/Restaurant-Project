using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Interfaces.Query;
using Domain.Entities;
using Infrastructure.Persistency;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly AppDbContext _context;
        public CategoryQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistsById(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
        public async Task<Category?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var category = await _context.Categories.FindAsync(id, ct);
            return category;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}