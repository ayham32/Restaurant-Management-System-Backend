
using RestaurantShared.Enums;

namespace RestaurantShared.DTOs.PeopleDTOs
{
    public class ReadPeopleDto
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? NationalNo { get; set; }

        public string Phone { get; set; } = null!;

        public enGender Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }


    }
}
