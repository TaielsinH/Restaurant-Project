using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models.SearchOrderResponses;
using Domain.Entities;

namespace Application.Interfaces.Mapping
{
    public interface IOrderMappingService
    {
        OrderResponse MapToDto(Order order);
        List<OrderResponse> MapToDto(List<Order> orders);
    }
}