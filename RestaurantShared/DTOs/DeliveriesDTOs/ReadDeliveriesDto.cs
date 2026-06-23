
using RestaurantShared.DTOs.EmployeesDTOs;
using RestaurantShared.DTOs.OrdersDTOs;
using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.DeliveriesDTOs
{
    public class ReadDeliveriesDto
    {
        public int DeliveryId { get; set; }

        public ReadEmployeesDto Employee { get; set; } = null!;

        public ReadOrdersDto Order { get; set; } = null!;

        public enDelivaryStatus Status { get; set; }

    }
}
