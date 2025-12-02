using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface ICategoryQuery
    {
        Task<bool> ExistsById(int id);
        Task<Category?> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}