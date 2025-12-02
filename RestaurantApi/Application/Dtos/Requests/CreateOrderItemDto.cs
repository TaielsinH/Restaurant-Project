using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Requests
{
    public class CreateOrderItemDto
    {
        public Guid Id { get; set; } //I think this is a fk to Dish
        public int Quantity { get; set; }
        public string Notes { get; set; } = "";
    }
}