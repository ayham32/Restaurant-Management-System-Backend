
using FluentValidation;
using RestaurantShared.DTOs.PeopleDTOs;

namespace RestaurantBusiness.Validation.PeopleValidation
{
    public class CreatePersonValidation :PersonValidation<CreatePersonDto>
    {
        public CreatePersonValidation()
        {
            ApplyPersonValidation(
                x => x.FirstName,
                x => x.LastName,
                x => x.NationalNo,
                x => x.Phone,
                x => x.DateOfBirth,
                x => x.Gender
            );
        }

       

    }


    }
