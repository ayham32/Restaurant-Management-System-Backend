using RestaurantShared;
using RestaurantShared.DTOs.PeopleDTOs;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;
using RestaurantShared.Results;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IPeopleService
    {
      
        public Task<Result<PagedResult<ReadPeopleDto>>> GetAllPeopleAsync(PersonParameter personParameter);

        public Task<Result<ReadPeopleDto>> GetPersonAsync(int PersonId);

        public Task<Result<ReadPeopleDto>> GetPersonAsync(string NationalNo);

        public Task<bool> isPersonExistAsync(int PersonId);
        
        public Task<bool> isPersonExistAsync(string NationalNo);

        public Task<Result<int>> AddNewPersonAsync(CreatePersonDto newPerson);
                                   
        public Task<Result> UpdatePersonAsync(int PersonId , UpdatePersonDto person);

        public Task<Result> DeletePersonAsync(int PersonId);




    }
}
