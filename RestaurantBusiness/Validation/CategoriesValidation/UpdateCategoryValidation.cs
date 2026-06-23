using RestaurantShared.DTOs.CategoriesDTOs;

namespace RestaurantBusiness.Validation.CategoriesValidation
{
    public class UpdateCategoryValidation : CategoryValidation<UpdateCategoryDto>
    {
        public UpdateCategoryValidation()
        {
            ApplyCategoryValidation(c => c.CategoryName);
        }
    }
}
