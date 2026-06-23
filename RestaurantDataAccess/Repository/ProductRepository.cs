

using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.Entities;
using RestaurantDataAccess.InterfaceRepository;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;

namespace RestaurantDataAccess.Repository
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        private readonly RestaurantDbContext _context;

        public ProductRepository(RestaurantDbContext context):base(context) 
        {
            _context = context;
        }

        
        
        public async Task<Product> GetProductAsync(int ProductId)
            => await _context.Products
                             .Include(p=>p.Category)
                             .SingleOrDefaultAsync(p => p.ProductId == ProductId);

        public async Task<PagedResult<Product>> GetProductsAsync(ProductParameter parameter)
        {
            var query = _context.Products                       
                        .AsNoTracking()
                        .Include(p=>p.Category)
                        .AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameter.Category))
                query = query.Where(p => p.Category.CategoryName .Contains(parameter.Category));

            if(!string .IsNullOrWhiteSpace(parameter.Search))
                query = query.Where(p => p.Name.Contains(parameter.Search));

            if(parameter.IsAvailable.HasValue)
                query = query.Where(p => p.IsAvailable==parameter.IsAvailable);


            var totalCount = await query.CountAsync();

            var products = await query
                .Skip((parameter.PageNumber - 1)
                    * parameter.PageSize)
                .Take(parameter.PageSize)             
                .ToListAsync();

            return new PagedResult<Product>
            {
                Items = products,
                TotalCount = totalCount,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize
            };
        }


    }
}
