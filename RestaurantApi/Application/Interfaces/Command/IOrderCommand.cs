using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IOrderCommand
    {
        Task AddAsync(Order order);
        void Update(Order order);
    }
}