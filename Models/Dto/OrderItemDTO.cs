namespace TestApi.Models.Dto
{
    public class OrderItemDTO
    {

        public int OrderItemDTOId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public static OrderItemDTO MapToDTO(OrderItem orderItem)
        {
            return new OrderItemDTO
            {
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
            };
        }
    };

}