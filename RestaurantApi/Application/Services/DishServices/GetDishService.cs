using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces.Query;

namespace Application.Services.DishServices
{
    public class GetDishService(IDishQuery query)
    {
        private readonly IDishQuery _query = query;

        public async Task<DishResponse> GetDishAsync(string request, CancellationToken ct)
        {
            if (!Guid.TryParse(request, out var guid))
                throw new BusinessRuleException("Formato de ID inválido");
            var dish = await _query.GetByIdAsync(guid, ct) ?? throw new KeyNotFoundException("Plato no encontrado");
            var response = new DishResponse
            {
                Id = dish.DishId,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Category = new CategoryResponseDto { Id = dish.Category, Name = dish.CategoryNav.Name },
                Image = dish.ImageUrl,
                IsActive = dish.Available,
                CreatedAt = dish.CreateDate,
                UpdatedAt = dish.UpdateDate
            };
            return response;
        }
    }
}