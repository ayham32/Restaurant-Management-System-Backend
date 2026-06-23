

using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.OrdersDTOs
{
    public class CreateOrderDto
    {
        
        public int? CustomerId { get; set; }

        public enOrderType OrderType { get; set; }

        public int? CreatedBy {get;set;}

        public enOrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public int? TableNumber { get; set; }
    }
}
