using FluentValidation;
using RestaurantShared.Enums;
using System.Linq.Expressions;

namespace RestaurantBusiness.Validation.EmployeesValidation
{
    public abstract class EmployeeValidation<T> : AbstractValidator<T>
    {
        protected void ApplyEmployeeValidation(
        Expression<Func<T, int?>> ManagerId,
        Expression<Func<T, decimal>> Salary,
        Expression<Func<T, TimeOnly>> StartTime,
        Expression<Func<T, TimeOnly>> EndTime
        )
        {

            if (ManagerId != null)
                RuleFor(ManagerId)
                    .GreaterThan(0);

            RuleFor(Salary)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(StartTime)
                .NotEmpty()
                .LessThan(EndTime);

            RuleFor(EndTime)
                .NotEmpty()
                .GreaterThan(StartTime);

        
        }


    }
}
