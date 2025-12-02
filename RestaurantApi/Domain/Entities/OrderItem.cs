using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public long Order { get; set; }
        public Order OrderNav { get; set; } = null!;
        public Guid Dish { get; set; }
        public Dish DishNav { get; set; } = null!;
        public int Quantity { get; set; }
        public string Notes { get; set; } = null!;
        public int Status { get; set; }
        public Status StatusNav { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}