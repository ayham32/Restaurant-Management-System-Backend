using RestaurantShared.DTOs.CategoriesDTOs;

namespace RestaurantBusiness.Validation.CategoriesValidation
{
    public class CreateCategoryValidation : CategoryValidation<CreateCategoryDto>
    {
        public CreateCategoryValidation()
        {
            ApplyCategoryValidation(c => c.CategoryName);
        }
    }
}
