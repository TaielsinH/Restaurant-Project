using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Interfaces.Query;

namespace Application.Services.DeliveryTypeServices
{
    public class GetAllDeliveryTypesService
    {
        private readonly IDeliveryTypeQuery _query;
        public GetAllDeliveryTypesService(IDeliveryTypeQuery query)
        {
            _query = query;
        }
        public async Task<List<DeliveryTypeDto>> GetAllAsync()
        {
            var deliveries = await _query.GetAllAsync();
            return deliveries.Select(d => new DeliveryTypeDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }
    }
}