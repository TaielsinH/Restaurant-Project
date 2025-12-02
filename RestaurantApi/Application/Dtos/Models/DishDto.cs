using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Domain.Entities;

namespace Application.Dtos.Models
{
    public class DishDto
    {
        public Guid DishId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public CategoryDto Category { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}