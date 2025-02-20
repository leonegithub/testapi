namespace TestApi.Models.Dto
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItemDTO>? OrderItems { get; set; }
    }
}