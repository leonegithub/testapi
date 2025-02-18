namespace TestApi.Models.Dto
{
    public class OrderItemDTO
    {

        public int OrderItemDTOId { get; set; }
        public ProductDTO? Product { get; set; }
        public int Quantity { get; set; }

        public static OrderItemDTO MapToDTOOrder(OrderItem orderItem)
        {
            return new OrderItemDTO
            {
                Product = ProductDTO.MapToDTOProduct(orderItem.Product),
                Quantity = orderItem.Quantity,
            };
        }
    };

}