using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Domain.Entities;

namespace Application.Services.DishServices
{
    public class SearchDishService
    {
        private readonly IDishQuery _query;
        public SearchDishService(IDishQuery query)
        {
            _query = query;
        }
        public async Task<List<DishResponse>> Search(DishQueryParameters parameters, CancellationToken ct)
        {
            return await _query.ListAsync(parameters, ct);
        }
    }
}