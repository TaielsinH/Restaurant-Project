using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.StatusServices
{
    public class GetAllStatusesService
    {
        private readonly IStatusQuery _query;
        public GetAllStatusesService(IStatusQuery query)
        {
            _query = query;
        }
        public async Task<List<StatusDto>> GetAllAsync()
        {
            var statuses = await _query.GetAllAsync();
            return statuses.Select(s => new StatusDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }
    }
}