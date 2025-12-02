using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IDeliveryTypeQuery
    {
        Task<IEnumerable<DeliveryType>> GetAllAsync();
        Task<bool> ExistsByIdAsync(int id);
    }
}