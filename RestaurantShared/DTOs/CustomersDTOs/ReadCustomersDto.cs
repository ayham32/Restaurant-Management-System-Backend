
using RestaurantShared.DTOs.UsersDTOs;

namespace RestaurantShared.DTOs.CustomersDTOs
{
    public class ReadCustomersDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

    }
}
