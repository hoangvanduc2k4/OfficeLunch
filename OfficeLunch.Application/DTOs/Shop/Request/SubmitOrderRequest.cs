namespace OfficeLunch.Application.DTOs.Shop.Request
{
    public class SubmitOrderRequest
    {
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }


    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
