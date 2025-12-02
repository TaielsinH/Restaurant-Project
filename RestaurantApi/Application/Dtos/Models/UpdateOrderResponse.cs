using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Models
{
    public class UpdateOrderResponse
    {
        public long OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}