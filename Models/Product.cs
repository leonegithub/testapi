namespace TestApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool isAvailable { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

}