using RestaurantShared.DTOs.EmployeesDTOs;

namespace RestaurantBusiness.Validation.EmployeesValidation
{
    public class UpdateEmployeeValidation : EmployeeValidation<UpdateEmployeeDto>
    {
        public UpdateEmployeeValidation()
        {
            ApplyEmployeeValidation
                (
                    e => e.ManagerId,
                    e => e.Salary,
                    e => e.StartTime,
                    e => e.EndTime

                );

          
        }
    }

}
