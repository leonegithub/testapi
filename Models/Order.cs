namespace TestApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem>? OrderItems { get; } = new List<OrderItem>();
        public ApplicationUser? ApplicationUser { get; set; }
    }
}