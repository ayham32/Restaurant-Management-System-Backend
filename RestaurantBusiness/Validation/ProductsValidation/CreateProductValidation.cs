using RestaurantShared.DTOs.ProductsDTOs;

namespace RestaurantBusiness.Validation.ProductsValidation
{
    public class CreateProductValidation : ProductValidation<CreateProductDto>
    {
        public CreateProductValidation() 
        {
            ApplyProductValidation
                (
                    p=>p.Name,
                    p=>p.Price,
                    p=>p.Quantity,
                    p=>p.CategoryId,
                    p=>p.PreparationTime,
                    p=> p.IsAvailable
                );
        }
    }

}
