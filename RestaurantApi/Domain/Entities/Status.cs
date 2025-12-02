
namespace Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}