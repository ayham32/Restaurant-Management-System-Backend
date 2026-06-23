
namespace RestaurantShared.DTOs.UsersDTOs
{
    public class CreateUserDto
    {
      
        public int PersonId { get; set; }

        public string Username { get; set; } = null!;

        public string HashPassword { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}
