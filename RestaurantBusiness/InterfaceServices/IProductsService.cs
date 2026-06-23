
using RestaurantShared.DTOs.ProductsDTOs;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;
using RestaurantShared.Results;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IProductsService
    {
        public Task<Result<PagedResult<ReadProductsDto>>> GetProductsAsync(ProductParameter parameter);

        public Task<Result<ReadProductsDto>> GetProductAsync(int ProductId);

        public Task<bool> isProductExist(int ProductId);

        public Task<Result<int>> AddNewProduct(CreateProductDto newProduct);

        public Task<Result> UpdateProduct(int  ProductId, UpdateProductDto product);

        public Task<Result> DeleteProduct(int ProductId);

    }
}
