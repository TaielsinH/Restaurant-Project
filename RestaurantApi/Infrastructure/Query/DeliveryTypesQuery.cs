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
    public class DeliveryTypesQuery : IDeliveryTypeQuery
    {
        private readonly AppDbContext _context;
        public DeliveryTypesQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DeliveryType>> GetAllAsync()
        {
            return await _context.DeliveryTypes.ToListAsync();
        }
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.DeliveryTypes.AnyAsync(d => d.Id == id);
        }
    }
}