using FluentValidation;
using RestaurantShared.DTOs.BillsDTOs;

namespace RestaurantBusiness.Validation.BillsValidation
{
    public class UpdateBillValidation : AbstractValidator<UpdateBillDto>
    {

        public UpdateBillValidation()
        {
            ApplyBillValidation();
        }

        private void ApplyBillValidation()
        {
        
            RuleFor(b => b.PaymentMethod)
              .NotEmpty()
              .IsInEnum();


            RuleFor(b => b.PaymentStatus)
              .NotEmpty()
              .IsInEnum();
        }
    }
}
