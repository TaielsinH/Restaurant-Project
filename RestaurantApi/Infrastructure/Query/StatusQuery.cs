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
    public class StatusQuery : IStatusQuery
    {
        private readonly AppDbContext _context;
        public StatusQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _context.Statuses.ToListAsync();
        }
        public async Task<bool> ExistsById(int id)
        {
            return await _context.Statuses.AnyAsync(s => s.Id == id);
        }
    }
}