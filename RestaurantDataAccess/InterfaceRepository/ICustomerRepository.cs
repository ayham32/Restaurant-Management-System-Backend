using RestaurantDataAccess.Entities;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {

        public Task<List<Customer>> GetAllCustomersAsync();

        public Task<Customer> GetCustomerAsync(int CustomerId);

        
       
  
    }
}
