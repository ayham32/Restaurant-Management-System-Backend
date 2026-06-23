

using RestaurantShared.Enums;

namespace RestaurantDataAccess.Entities;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public int EmployeeId { get; set; }

    public int OrderId { get; set; }

    public enDelivaryStatus Status { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
