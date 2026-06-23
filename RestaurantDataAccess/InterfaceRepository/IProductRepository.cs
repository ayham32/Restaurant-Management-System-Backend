using RestaurantDataAccess.Entities;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface IProductRepository:IGenericRepository<Product>
    {

        public Task<PagedResult<Product>> GetProductsAsync(ProductParameter parameter);

        public Task<Product> GetProductAsync(int ProductId);

       
    }
}
