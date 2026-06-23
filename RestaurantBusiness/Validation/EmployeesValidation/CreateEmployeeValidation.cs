using FluentValidation;
using RestaurantShared.DTOs.EmployeesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.Validation.EmployeesValidation
{
    public class CreateEmployeeValidation : EmployeeValidation<CreateEmployeeDto>
    {
        public CreateEmployeeValidation()
        {
            ApplyEmployeeValidation
                (
                    e => e.ManagerId,
                    e => e.Salary,
                    e => e.StartTime,
                    e => e.EndTime

                );

            RuleFor(e => e.UserId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

}
