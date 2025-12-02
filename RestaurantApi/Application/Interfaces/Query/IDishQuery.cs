using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IDishQuery
    {
        Task<bool> NameExists(string name);
        Task<bool> DishExists(Guid id);
        Task<Dish?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<DishResponse>> ListAsync(DishQueryParameters p, CancellationToken ct = default);
    }
}