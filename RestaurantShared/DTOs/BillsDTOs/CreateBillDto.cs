
using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.BillsDTOs
{
    public class CreateBillDto
    {
        
        public int OrderId { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal Discount { get; set; }

        public int CreatedBy { get; set; }

        public enPaymentMethod PaymentMethod { get; set; }

        public enPaymentStatus PaymentStatus { get; set; }

       
    }
}
