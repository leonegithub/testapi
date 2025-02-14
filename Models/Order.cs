using TestApi.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    public ICollection<OrderItem> OrderItems { get; set; }

    public Order()
    {
        OrderItems = new List<OrderItem>();
    }
}