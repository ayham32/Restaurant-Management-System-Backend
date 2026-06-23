using RestaurantShared.DTOs.EmployeesDTOs;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;
using RestaurantShared.Results;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IEmployeesService
    {
        public Task<Result<PagedResult<ReadEmployeesDto>>> GetEmployeesAsync(EmployeeParameter parameter);

        public Task<Result<ReadEmployeesDto>> GetEmployeeAsync(int EmployeeId);

        public Task<bool> isEmployeeExistAsync(int EmployeeId);

        public Task<Result<int>> AddNewEmployee(CreateEmployeeDto newEmployee);

        public Task<Result> UpdateEmployee(int EmployeeId, UpdateEmployeeDto employee);

        public Task<Result> DeleteEmployee(int EmployeeId);

    }
}
