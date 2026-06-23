using RestaurantShared.DTOs.DeliveriesDTOs;


namespace RestaurantBusiness.Validation.DeliveriesValidation
{
    public class UpdateDeliveryValidation : DeliveryValidation<UpdateDeliveryDto>
    {
        public UpdateDeliveryValidation()
        {
            ApplyDeliveryValidation
                (
                    d => d.EmployeeId,
                    d => d.OrderId,
                    d => d.Status
                );
        }
    }
}
