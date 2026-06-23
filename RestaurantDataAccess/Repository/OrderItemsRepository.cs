using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.Entities;
using RestaurantDataAccess.InterfaceRepository;

namespace RestaurantDataAccess.Repository
{
    public class OrderItemsRepository : GenericRepository<OrderItem>,IOrderItemsRepository
    {
        private readonly RestaurantDbContext _context;
        
        public OrderItemsRepository(RestaurantDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<OrderItem> GetOrderItemAsync(int OrderItemId)
            => await _context.OrderItems
                             .Include(oi => oi.Order)
                             .Include(oi => oi.Product)
                             .SingleOrDefaultAsync(o=> o.OrderItemId == OrderItemId);

        public async Task<List<OrderItem>> GetOrderItemsAsync()
            => await _context.OrderItems
                             .Include(oi=>oi.Order)
                             .Include(oi=>oi.Product)
                             .AsNoTracking()
                             .ToListAsync();

     
    }
}
