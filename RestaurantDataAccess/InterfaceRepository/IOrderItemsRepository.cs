using RestaurantDataAccess.Entities;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface IOrderItemsRepository:IGenericRepository<OrderItem>
    {

        public Task<List<OrderItem>> GetOrderItemsAsync();

        public Task<OrderItem> GetOrderItemAsync(int OrderItemId);

        
    }
}
