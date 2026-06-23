using FluentValidation;
using RestaurantShared.DTOs.BillsDTOs;


namespace RestaurantBusiness.Validation.BillsValidation
{
    public class CreateBillValidation:AbstractValidator<CreateBillDto>
    {

        public CreateBillValidation() 
        {
            ApplyBillValidation();
        }

        private void ApplyBillValidation()
        {
            RuleFor(b => b.OrderId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(b => b.SubTotal)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(b => b.TaxAmount)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(b => b.Discount)
              .NotEmpty()
              .GreaterThanOrEqualTo(0);

            RuleFor(b => b.CreatedBy)
              .NotEmpty()
              .GreaterThan(0);

            RuleFor(b => b.PaymentMethod)
              .NotEmpty()
              .IsInEnum();


            RuleFor(b => b.PaymentStatus)
              .NotEmpty()
              .IsInEnum();
        }
    }
}
