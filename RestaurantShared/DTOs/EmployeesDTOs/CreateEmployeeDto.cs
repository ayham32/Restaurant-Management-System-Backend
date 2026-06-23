
namespace RestaurantShared.DTOs.EmployeesDTOs
{
    public class CreateEmployeeDto
    {
     
        public int UserId { get; set; }

        public int? ManagerId { get; set; }

        public decimal Salary { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
