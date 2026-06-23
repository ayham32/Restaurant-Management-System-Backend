

namespace RestaurantShared.DTOs.OrderItemsDTOs
{
    public class ReadOrderItemsDto
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
