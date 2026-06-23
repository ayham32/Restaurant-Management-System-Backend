

using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.DeliveriesDTOs
{
    public class UpdateDeliveryDto
    {
    
        public int EmployeeId { get; set; }

        public int OrderId { get; set; }

        public enDelivaryStatus Status { get; set; }

    }

}
