using Application.Dtos.Requests;
using Application.Exceptions;
using Application.Interfaces.Query;
using Domain.Entities;
using Application.Dtos.Models.SearchOrderResponses;
using Application.Interfaces.Mapping;

namespace Application.Services.OrderServices
{
    public class OrderSearchService
    {
        private readonly IOrderQuery _orderQuery;
        private readonly IStatusQuery _statusQuery;
        private readonly IOrderMappingService _mapper;

        public OrderSearchService(IOrderQuery orderQuery, IStatusQuery statusQuery, IOrderMappingService mapper)
        {
            _orderQuery = orderQuery;
            _statusQuery = statusQuery;
            _mapper = mapper;
        }
        public async Task<List<OrderResponse>> SearchAsync(OrderSearchRequest request, CancellationToken ct = default)
        {
            var query = _orderQuery.Query(); // generates a IQueryable<Order>. I've just learned it and I love this interface
            if (request.From.HasValue)
                query = query.Where(o => o.CreateDate >= request.From.Value);

            if (request.To.HasValue)
                query = query.Where(o => o.CreateDate <= request.To.Value);

            if (request.Status.HasValue)
            {
                await ValidateStatus(request.Status.Value);
                query = query.Where(o => o.OverallStatus == request.Status);
            }
            List<Order> orderList = await _orderQuery.IncludeRelatedAsync(query); // Includes: Status, DeliveryType, Items.Status, Items.Dish
            return _mapper.MapToDto(orderList);
        }
        private async Task ValidateStatus(int id)
        {
            if (!await _statusQuery.ExistsById(id))
                throw new BusinessRuleException("No existe un Status con ese id");
        }
        
    }
}