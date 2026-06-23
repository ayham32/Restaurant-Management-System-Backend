using FluentValidation;
using RestaurantShared.DTOs.OrderItemsDTOs;

namespace RestaurantBusiness.Validation.OrderItemsValidation
{
    public class UpdateOrderItemValidation : AbstractValidator<UpdateOrderItemDto>
    {
        public UpdateOrderItemValidation()
        {
            ApplyOrderItemValidation();
        }

        private void ApplyOrderItemValidation()
        {
          

            RuleFor(oi => oi.UnitPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(oi => oi.Quantity)
                .NotEmpty()
                .GreaterThan(0);


        }

    }
}
