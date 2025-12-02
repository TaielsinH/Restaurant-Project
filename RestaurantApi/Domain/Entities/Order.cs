
namespace Domain.Entities
{
    public class Order
    {
        public long OrderId { get; set; }
        public int DeliveryType { get; set; }
        public DeliveryType DeliveryTypeNav { get; set; } = null!;
        public string DeliveryTo { get; set; } = null!;
        public int OverallStatus { get; set; }
        public Status OverallStatusNav { get; set; }
        public string Notes { get; set; } = " ";
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = null!;
    }
}