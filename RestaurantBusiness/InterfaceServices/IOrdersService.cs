
using RestaurantShared.DTOs.OrdersDTOs;
using RestaurantShared.Results;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IOrdersService
    {

        public Task<Result<List<ReadOrdersDto>>> GetOrdersAsync();

        public Task<Result<ReadOrdersDto>> GetOrderAsync(int OrderId);

        public Task<bool> isOrderExistAsync(int OrderId);

        public Task<Result<int>> AddNewOrderAsync(CreateOrderDto newOrder);

        public Task<Result> UpdateOrderAsync(int orderId, UpdateOrderDto order);

        public Task<Result> DeleteOrder(int OrderId);

    }
}
