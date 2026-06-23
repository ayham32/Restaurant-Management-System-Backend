using FluentValidation;
using RestaurantShared.DTOs.CustomersDTOs;


namespace RestaurantBusiness.Validation.CustomersValidation
{
    public class UpdateCustomerValidation : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerValidation()
        {
            ApplyCustomerValidaation();
        }

        private void ApplyCustomerValidaation()
        {
          
            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.Phone)
                .NotEmpty()
                .Length(10);

        }

    }
}
