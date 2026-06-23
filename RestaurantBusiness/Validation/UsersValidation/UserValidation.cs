
using FluentValidation;
using System.Linq.Expressions;

namespace RestaurantBusiness.Validation.UsersValidation
{
    public abstract class UserValidation<T> : AbstractValidator<T>
    {
        protected void ApplyUserValidation(
        Expression<Func<T, int>> PersonId,
        Expression<Func<T, string>> Username,
        Expression<Func<T, string>> HashPassword,
        Expression<Func<T, bool>> IsActive)
        {
            RuleFor(PersonId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(Username)
                .NotEmpty();

            RuleFor(HashPassword)
                .NotEmpty()
                .Length(8,20);

            RuleFor(IsActive)
                .NotEmpty();

        }


    }


    }
