namespace TestApi.Models.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static ProductDTO MapToDTOProduct(Product product)
        {
            return new ProductDTO
            {
                Name = product.Name
            };
        }
    }
}