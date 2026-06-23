using RestaurantShared.Enums;

namespace RestaurantDataAccess.Entities;

public partial class Bill
{
    public int BillId { get; set; }

    public int OrderId { get; set; }

    public decimal SubTotal { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal Discount { get; set; }

    public decimal FinalAmount { get; set; }

    public enPaymentMethod PaymentMethod { get; set; }

    public enPaymentStatus PaymentStatus { get; set; }

    public DateTime IssuedAt { get; set; }

    public int CreatedBy { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
