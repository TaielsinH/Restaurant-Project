
namespace Domain.Entities
{
    public class Dish
    {
        public Guid DishId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int Category { get; set; }
        public Category CategoryNav { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}