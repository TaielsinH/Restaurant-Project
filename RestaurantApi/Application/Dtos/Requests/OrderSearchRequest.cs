namespace Application.Dtos.Requests
{
    public class OrderSearchRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? Status { get; set; }
    }
}