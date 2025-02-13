using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public ICollection<Product>? Products { get; } = new List<Product>();
    }
}