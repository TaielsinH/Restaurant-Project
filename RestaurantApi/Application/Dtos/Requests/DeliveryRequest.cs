using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Requests
{
    public class DeliveryRequest
    {
        public int Id { get; set; } //this must be an existing pk from DeliveryType
        public string To { get; set; } = null!;
    }
}