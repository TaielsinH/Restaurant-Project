using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Models.SearchOrderResponses
{
    public class SODishResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}