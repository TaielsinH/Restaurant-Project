
namespace Application.Dtos.Models.SearchOrderResponses
{
    public class SOItemResponse
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; } = null!;
        public SOStatusResponse Status { get; set; } = null!;
        public SODishResponse Dish { get; set; } = null!;
    }
}