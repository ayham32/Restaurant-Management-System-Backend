
namespace RestaurantShared.DTOs.CustomersDTOs
{
    public class UpdateCustomerDto
    {

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Address { get; set; }
    }
}
