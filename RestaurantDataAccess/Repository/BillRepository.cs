using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.Entities;
using RestaurantDataAccess.InterfaceRepository;


namespace RestaurantDataAccess.Repository
{
    public class BillRepository:GenericRepository<Bill>,  IBillRepository
    {

        private readonly RestaurantDbContext _context;

        public BillRepository(RestaurantDbContext context):base (context)
        {
            _context = context;
        }

        public async Task<Bill> GetBillAsync(int BillId)
            => await _context.Bills
                             .Include(b => b.Order)
                             .SingleOrDefaultAsync(b=>b.BillId==BillId);
        
        public async Task<List<Bill>> GetBillsAsync()
            => await _context.Bills
                             .Include(b=>b.Order)
                             .AsNoTracking()
                             .ToListAsync();

       
      

    }
}

