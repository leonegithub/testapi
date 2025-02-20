namespace TestApi.Models.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public static ProductDTO MapToDTOProduct(Product product)
        {
            return new ProductDTO
            {
                Id = product.ProductId,
                Name = product.Name,
                Price = product.Price,
            };
        }
    }
}