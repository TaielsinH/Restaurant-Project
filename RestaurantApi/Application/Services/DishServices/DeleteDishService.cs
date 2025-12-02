using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.DishServices
{
    public class DeleteDishService(IDishQuery query, IUnitOfWork unitOfWork, IOrderItemQuery itemQuery)
    {
        private readonly IDishQuery _query = query;
        private readonly IOrderItemQuery _itemQuery = itemQuery;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<DishResponse> DeleteAsync(string request)
        {
            if (!Guid.TryParse(request, out var id))
                throw new BusinessRuleException("Formato de ID inválido");
                
            var dish = await _query.GetByIdAsync(id) ?? throw new KeyNotFoundException("Plato no encontrado");
            if (await _itemQuery.OrderItemContainsDishAsync(dish))
                throw new ConflictException("No se puede eliminar el plato porque está incluido en órdenes activas");
            dish.Available = false;
            _unitOfWork.DishCommand.Update(dish);
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
            await _unitOfWork.Save();
            return response;
        }
    }
}