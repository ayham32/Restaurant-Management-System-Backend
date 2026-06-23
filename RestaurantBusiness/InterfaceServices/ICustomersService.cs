
using RestaurantShared.DTOs.CustomersDTOs;
using RestaurantShared.Results;

namespace RestaurantBusiness.InterfaceServices
{
    public interface ICustomersService
    {
        public Task<Result<List<ReadCustomersDto>>> GetCustomersAsync();

        public Task<Result<ReadCustomersDto>> GetCustomerAsync(int CustomerId);

        public Task<bool> isCustomerExistAsync(int CustomerId);

        public Task<Result<int>> AddNewCustomer(CreateCustomerDto newCustomer);

        public Task<Result> UpdateCustomerAsync(int customerId, UpdateCustomerDto customer);

        public Task<Result> DeleteCustomer(int CustomerId);



        
    }
}
