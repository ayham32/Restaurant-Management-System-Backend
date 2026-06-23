
using RestaurantDataAccess.Entities;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface IPeopleRepository:IGenericRepository<Person>
    {
     
        public Task<PagedResult<Person>> GetAll(PersonParameter personParameter);
        public Task<Person> GetPersonAsync(string NationalNo);

      
        public Task<bool> isPersonExist(string NationalNo);
    }
}
