using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.Entities;
using RestaurantDataAccess.InterfaceRepository;

namespace RestaurantDataAccess.Repository
{
    public class CustomerRepository : GenericRepository<Customer>,ICustomerRepository
    {

        private readonly RestaurantDbContext _context;

        public CustomerRepository(RestaurantDbContext context):base(context)
        {
            _context = context;
        }

       
        public async Task<List<Customer>> GetAllCustomersAsync()
            => await _context.Customers
                             .AsNoTracking()
                             .ToListAsync();


        public async Task<Customer> GetCustomerAsync(int CustomerId)
            => await _context.Customers
                             .FindAsync(CustomerId);

        
        
    }
}
