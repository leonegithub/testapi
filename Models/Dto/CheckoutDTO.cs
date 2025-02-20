namespace TestApi.Models.Dto
{
    public class CheckoutItemDTO
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}