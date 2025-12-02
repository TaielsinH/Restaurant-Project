using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.DishServices
{
    public class UpdateDishService
    {
        private readonly IDishQuery _query;
        private readonly ICategoryQuery _categoryQuery;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDishService
        (IDishQuery query, ICategoryQuery categoryQuery, IUnitOfWork unitOfWork)
        {
            _query = query;
            _categoryQuery = categoryQuery;
            _unitOfWork = unitOfWork;
        }
        public async Task<DishResponse> Update(UpdateDishRequest request, Guid id, CancellationToken ct)
        {
            var category = await Validation(request, ct);
            var dish = await _query.GetByIdAsync(id, ct);
            if (dish == null)
                throw new KeyNotFoundException("Plato no encontrado");

            dish.Name = request.Name;
            dish.Description = request.Description;
            dish.Price = request.Price;
            dish.Available = request.IsActive;
            dish.Category = request.Category;
            dish.ImageUrl = request.Image;
            dish.UpdateDate = DateTime.UtcNow;

            _unitOfWork.DishCommand.Update(dish);
            var rowsAffect = await _unitOfWork.Save();
            if (rowsAffect == 0)
                throw new Exception("No se guardaron el updateDish");
            var response = new DishResponse
            {
                Id = dish.DishId,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                IsActive = dish.Available,
                Image = dish.ImageUrl,
                Category = new CategoryResponseDto { Id = dish.Category, Name = category.Name },
                CreatedAt = dish.CreateDate,
                UpdatedAt = dish.UpdateDate
                
            };
            return response;
        }
        private async Task<Category> Validation(UpdateDishRequest request, CancellationToken ct)
        {
            if (await _query.NameExists(request.Name))
                throw new ConflictException("Ya existe un plato con ese nombre");
            var categoria = await _categoryQuery.GetByIdAsync(request.Category, ct);
            if (categoria == null)
                throw new BusinessRuleException("No existe una categoria que coincida con el id categoria");
            return categoria;
        }
    }
}