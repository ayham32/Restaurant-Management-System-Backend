
namespace RestaurantShared.DTOs.UsersDTOs
{
    public class ReadUsersDto
    {
        public int UserId { get; set; }

        public int PersonId { get; set; }
        
        public string FullName { get; set; } = null!;
        
        public string NationalNo {  get; set; } = null!;
       
        public string Username { get; set; } = null!;
       
        public bool? IsActive { get; set; }

    }
}
