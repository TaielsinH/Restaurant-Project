using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Command;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderCommand OrderCommand { get; }
        IOrderItemCommand OrderItemCommand { get; }
        IDishCommand DishCommand { get; }
        Task<int> Save();
    }
}