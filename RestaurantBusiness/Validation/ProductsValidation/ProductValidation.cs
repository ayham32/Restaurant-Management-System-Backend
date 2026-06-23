using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace RestaurantBusiness.Validation.ProductsValidation
{
    public abstract class ProductValidation<T>:AbstractValidator<T>
    {

        protected void ApplyProductValidation(
       Expression<Func<T, string>> Name,
       Expression<Func<T, decimal>> Price,
       Expression<Func<T, int>> Quantity,
       Expression<Func<T, int>> CategoryId,
       Expression<Func<T, int?>> PreparationTime,
       Expression<Func<T, bool>> IsAvailable
       )
        {
            RuleFor(Name)
                .NotEmpty();

            RuleFor(Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(Quantity)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
           
            RuleFor(CategoryId)
                .NotEmpty()
                .GreaterThan(0);
           
            if(PreparationTime!= null)
                RuleFor(PreparationTime)
                   .GreaterThan(0);

            RuleFor(IsAvailable)
                .NotEmpty();
        }

    }

}
