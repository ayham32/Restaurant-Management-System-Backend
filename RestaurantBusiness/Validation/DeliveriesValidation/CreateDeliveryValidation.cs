using RestaurantShared.DTOs.DeliveriesDTOs;


namespace RestaurantBusiness.Validation.DeliveriesValidation
{
    public class CreateDeliveryValidation : DeliveryValidation<CreateDeliveryDto>
    {
        public CreateDeliveryValidation() 
        {
            ApplyDeliveryValidation
                (
                    d=>d.EmployeeId,
                    d=>d.OrderId,
                    d=>d.Status
                );
        }
    }
}
