using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.DishServices
{
    public class CreateDishService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDishQuery _query;
        private readonly ICategoryQuery _categoryQuery;
        public CreateDishService
        (IUnitOfWork unitOfWork, IDishQuery query, ICategoryQuery categoryQuery, IDishCommand command)
        {
            _unitOfWork = unitOfWork;
            _query = query;
            _categoryQuery = categoryQuery;
        }
        public async Task<DishResponse> Create(CreateDishRequest dto, CancellationToken ct)
        {

            var category = await Validate(dto, ct);

            var dish = new Dish
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Available = true,
                Category = dto.Category,
                ImageUrl = dto.Image,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
            await _unitOfWork.DishCommand.AddAsync(dish, ct);
            await _unitOfWork.Save();
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
        private async Task<Category> Validate(CreateDishRequest dto, CancellationToken ct)
        {
            if (await _query.NameExists(dto.Name))
                throw new ConflictException("Ya existe un plato con ese nombre");
            var categoria = await _categoryQuery.GetByIdAsync(dto.Category, ct);
            if ( categoria == null)
                throw new BusinessRuleException("No existe una categoria que coincida con el id categoria");

            return categoria;
        }
    }
}