using RestaurantShared.DTOs.ProductsDTOs;

namespace RestaurantBusiness.Validation.ProductsValidation
{
    public class UpdateOrderValidation : ProductValidation<UpdateProductDto>
    {
        public UpdateOrderValidation()
        {
            ApplyProductValidation
                (
                    p => p.Name,
                    p => p.Price,
                    p => p.Quantity,
                    p => p.CategoryId,
                    p => p.PreparationTime,
                    p => p.IsAvailable
                );
        }
    }

}
