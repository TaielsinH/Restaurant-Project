using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Services.DishServices;
using Infrastructure.Command;
using Infrastructure.Query;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Validators;
using Application.Interfaces.Logs;
using Infrastructure.Logging;
using Application.Services.CategoryServices;
using Application.Services.DeliveryTypeServices;
using Application.Services.StatusServices;
using Application.Services.OrderServices;
using Application.Interfaces;
using Infrastructure.UoW;
using Application.Interfaces.Mapping;
using Application.Services.Mapping;

namespace Infrastructure.Persistency
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDishCommand, DishCommand>();
            services.AddScoped<IDishQuery, DishQuery>();
            services.AddScoped<ICategoryQuery, CategoryQuery>();
            services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IDeliveryTypeQuery, DeliveryTypesQuery>();
            services.AddScoped<IStatusQuery, StatusQuery>();
            services.AddScoped<IOrderCommand, OrderCommand>();
            services.AddScoped<IOrderItemCommand, OrderItemCommand>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderQuery, OrderQuery>();
            services.AddScoped<IOrderItemQuery, OrderItemQuery>();

            return services;
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateDishService>();
            services.AddScoped<UpdateDishService>();
            services.AddScoped<SearchDishService>();
            services.AddScoped<GetDishService>();
            services.AddScoped<GetAllCategoriesService>();
            services.AddScoped<GetAllDeliveryTypesService>();
            services.AddScoped<GetAllStatusesService>();
            services.AddScoped<CreateOrderService>();
            services.AddScoped<IOrderMappingService, SearchOrderMappingService>();
            services.AddScoped<OrderSearchService>();
            services.AddScoped<GetOrderService>();
            services.AddScoped<DeleteDishService>();
            services.AddScoped<UpdateOrderService>();
            services.AddScoped<UpdateOrderItemService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateDishValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateDishValidator>();
            services.AddValidatorsFromAssemblyContaining<DishQueryParametersValidator>();
            services.AddValidatorsFromAssemblyContaining<GetDishByIdValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderSearchRequestValidator>();
            return services;
        }
    }
}