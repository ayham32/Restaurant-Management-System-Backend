using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.Entities;
using RestaurantDataAccess.InterfaceRepository;

namespace RestaurantDataAccess.Repository
{
    public class DeliveryRepository: GenericRepository<Delivery>,IDeliveryRepository
    {
        private readonly RestaurantDbContext _context;

        public DeliveryRepository(RestaurantDbContext context):base(context)
        {
            _context = context;
        }

        
        public async Task<List<Delivery>> GetDeliveriesAsync()
            => await _context.Deliveries
                             .Include(e=>e.Employee)
                             .ThenInclude(e=>e.User)
                             .ThenInclude(e=>e.Person)
                             .Include(e=>e.Order)
                             .AsNoTracking()
                             .ToListAsync();

        public async Task<Delivery?> GetDeliveryAsync(int DeliveryId)
            => await _context.Deliveries
                             .Include(e => e.Employee)
                             .ThenInclude(e => e.User)
                             .ThenInclude(e => e.Person)
                             .Include(e => e.Order)
                             .SingleOrDefaultAsync(d => d.DeliveryId == DeliveryId);

        

      
    }
}
