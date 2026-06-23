using FluentValidation;
using RestaurantShared.Enums;
using System.Linq.Expressions;


namespace RestaurantBusiness.Validation.DeliveriesValidation
{
    public abstract class DeliveryValidation<T> :AbstractValidator<T>
    {
        protected void ApplyDeliveryValidation(
          Expression<Func<T, int>> EmployeeId,
          Expression<Func<T, int>> OrderId,
          Expression<Func<T, enDelivaryStatus>> Status
            )
        {

           RuleFor(EmployeeId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(OrderId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(Status)
                 .NotEmpty()
                 .IsInEnum();


        }


    }
}
