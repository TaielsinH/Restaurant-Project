
namespace Application.Dtos.Requests
{
    public class OrderUpdateRequest
    {
        public List<CreateOrderItemDto> Items { get; set; } = null!;
    }
}