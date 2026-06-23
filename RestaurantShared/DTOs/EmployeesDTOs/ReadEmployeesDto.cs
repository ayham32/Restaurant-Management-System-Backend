
using RestaurantShared.DTOs.UsersDTOs;

namespace RestaurantShared.DTOs.EmployeesDTOs
{
    public class ReadEmployeesDto
    {
        public int EmployeeId { get; set; }

        public ReadUsersDto User { get; set; } = null!;

        public int? ManagerBy{ get; set; }

        public decimal? Salary { get; set; }

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

    }
}
