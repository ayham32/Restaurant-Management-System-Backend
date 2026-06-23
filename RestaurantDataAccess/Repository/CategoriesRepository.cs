
using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.InterfaceRepository;
using RestaurantShared.Entities;

namespace RestaurantDataAccess.Repository
{
    public class CategoriesRepository: GenericRepository<Category>,ICategoriesRepository
    {
        private readonly RestaurantDbContext _context;

        public CategoriesRepository(RestaurantDbContext context):base(context)
        {
            _context = context;
        }

        
    }
}
