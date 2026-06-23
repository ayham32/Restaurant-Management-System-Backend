using FluentValidation;
using RestaurantShared.DTOs.CustomersDTOs;


namespace RestaurantBusiness.Validation.CustomersValidation
{
    public class CreateCustomerValidation:AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerValidation()
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
