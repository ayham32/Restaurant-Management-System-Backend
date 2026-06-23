using RestaurantShared.DTOs.OrderItemsDTOs;
using RestaurantShared.Results;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IOrderItemsService
    {

        public Task<Result<List<ReadOrderItemsDto>>> GetOrderItemsAsync();

        public Task<Result<ReadOrderItemsDto>> GetOrderItemAsync(int OrderItemId);

        public Task<Result<int>> AddNewOrderItem(CreateOrderItemDto newOrderItem);

        public Task<Result> UpdateOrderItem(int OrderItemId, UpdateOrderItemDto orderItem);

        public Task<Result> DeleteOrderItem(int OrderItemId);

    }
}
