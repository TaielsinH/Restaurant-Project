using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;

namespace Application.Dtos.Requests
{
    public class CreateOrderRequest
    {
        public List<CreateOrderItemDto> Items { get; set; } = null!;
        public DeliveryRequest Delivery { get; set; } = null!;
        public string Notes { get; set; } = "";
    }
}