using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IStatusQuery
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task<bool> ExistsById(int id);
    }
}