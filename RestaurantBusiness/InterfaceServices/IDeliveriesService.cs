using RestaurantShared.DTOs.DeliveriesDTOs;
using RestaurantShared.Results;


namespace RestaurantBusiness.InterfaceServices
{
    public interface IDeliveriesService
    {
        public Task<Result<List<ReadDeliveriesDto>>> GetDeliveriesAsync();

        public Task<Result<ReadDeliveriesDto>> GetDeliveryAsync(int DeliveryId);

        public Task<bool> isDeliveryExistAsync(int DeliveryId);

        public Task<Result<int>> AddNewDeliveryAsync(CreateDeliveryDto newDelivery);

        public Task<Result> UpdateDeliveryAsync(int deliveryId, UpdateDeliveryDto delivery);

        public Task<Result> DeleteDeliveryAsync(int deliveryId);

    }
}
