using Application.Dtos.Models.SearchOrderResponses;
using Application.Exceptions;
using Application.Interfaces.Mapping;
using Application.Interfaces.Query;

namespace Application.Services.OrderServices
{
    public class GetOrderService
    {
        private readonly IOrderQuery _query;
        private readonly IOrderMappingService _mapper;
        public GetOrderService(IOrderQuery query, IOrderMappingService mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<OrderResponse> GetAsync(string request)
        {
            if (!long.TryParse(request, out var id))
                throw new BusinessRuleException("Formato de ID inválido");
            var order = await _query.GetOrderAsync(id) ?? throw new KeyNotFoundException("Orden no encontrada");
            var response = _mapper.MapToDto(order);
            return response;
        }
    }
}