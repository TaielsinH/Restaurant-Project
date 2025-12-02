
namespace Application.Dtos.Models.SearchOrderResponses
{
    public class OrderResponse
    {
        public long OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryTo { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public SOStatusResponse Status { get; set; } = null!;
        public SODeliveryTypeResponse DeliveryType { get; set; } = null!;
        public List<SOItemResponse> Items { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }
}