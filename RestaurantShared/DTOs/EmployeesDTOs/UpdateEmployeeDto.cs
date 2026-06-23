
namespace RestaurantShared.DTOs.EmployeesDTOs
{
    public class UpdateEmployeeDto
    {


        public int? ManagerId { get; set; }

        public decimal Salary { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
