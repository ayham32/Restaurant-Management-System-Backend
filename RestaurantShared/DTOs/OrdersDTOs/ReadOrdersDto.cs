using RestaurantShared.DTOs.CustomersDTOs;
using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.OrdersDTOs
{
    public class ReadOrdersDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public enOrderType OrderType { get; set; }

        public enOrderStatus Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? TableNumber { get; set; }
    }
}
