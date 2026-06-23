

using FluentValidation;
using System.Linq.Expressions;

namespace RestaurantBusiness.Validation.CategoriesValidation
{
    public abstract class CategoryValidation<T> :AbstractValidator<T>
    {

        protected void ApplyCategoryValidation(
        Expression<Func<T, string>> CategoryName
        )
        {
            RuleFor(CategoryName)
                .NotEmpty();
            
        }
    }
}
