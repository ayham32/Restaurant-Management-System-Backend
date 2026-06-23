using RestaurantDataAccess.Entities;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface IDeliveryRepository:IGenericRepository<Delivery>
    {

        public Task<List<Delivery>> GetDeliveriesAsync();

        public Task<Delivery> GetDeliveryAsync(int DeliveryId);

      
    
    }
}
