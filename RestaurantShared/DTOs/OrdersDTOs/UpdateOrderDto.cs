

using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.OrdersDTOs
{
    public class UpdateOrderDto
    {
        
        public enOrderType OrderType { get; set; }

        public enOrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public int? TableNumber { get; set; }

    }
}
