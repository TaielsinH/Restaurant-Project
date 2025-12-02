using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Interfaces.Query;

namespace Application.Services.CategoryServices
{
    public class GetAllCategoriesService
    {
        private readonly ICategoryQuery _query;
        public GetAllCategoriesService(ICategoryQuery query)
        {
            _query = query;
        }
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _query.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Order = c.Order
            }).ToList();
        }
    }
}