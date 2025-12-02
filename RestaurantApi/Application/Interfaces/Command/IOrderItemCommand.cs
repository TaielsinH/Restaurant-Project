using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IOrderItemCommand
    {
        Task AddAsync(OrderItem orderItem);
        void Update(OrderItem orderItem);
    }
}