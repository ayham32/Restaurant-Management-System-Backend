
using FluentValidation;
using RestaurantShared.Enums;
using System.Linq.Expressions;

namespace RestaurantBusiness.Validation.PeopleValidation
{
    public abstract class PersonValidation<T> : AbstractValidator<T>
    {
        protected void ApplyPersonValidation(
        Expression<Func<T, string>> firstName,
        Expression<Func<T, string>> lastName,
        Expression<Func<T, string>> nationalNo,
        Expression<Func<T, string>> phone,
        Expression<Func<T, DateOnly>> dateOfBirth,
        Expression<Func<T, enGender>> gender)
        {
            RuleFor(firstName)
                .NotEmpty();

            RuleFor(lastName)
                .NotEmpty();

            RuleFor(nationalNo)
                .NotEmpty();

            RuleFor(phone)
                .NotEmpty();

            RuleFor(dateOfBirth)
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Today.AddYears(-16)))
                .WithMessage("Person must be at least 16 years old.");

            RuleFor(gender)
                .IsInEnum();
        }


    }


    }
