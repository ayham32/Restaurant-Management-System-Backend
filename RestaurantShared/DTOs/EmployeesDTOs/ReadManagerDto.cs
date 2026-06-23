
using RestaurantShared.DTOs.UsersDTOs;

namespace RestaurantShared.DTOs.EmployeesDTOs
{
    public class ReadManagerDto
    {
        public int ManagerId { get; set; }
        public ReadUsersDto User { get; set; } = null!;



    }
}
