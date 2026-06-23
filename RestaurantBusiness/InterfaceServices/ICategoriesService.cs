using RestaurantShared.DTOs.CategoriesDTOs;
using RestaurantShared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.InterfaceServices
{
    public interface ICategoriesService
    {

        public Task<Result<List<ReadCategoriesDto>>> GetCategoriesAsync();

        public Task<Result<ReadCategoriesDto>> GetCategoryAsync(int categoryId);

        public Task<bool> isCategoryExistAsync(int categoryId);

        public Task<Result<int>> AddNewCategory(CreateCategoryDto newCategory);

        public Task<Result> UpdateCategory(int categoryId, UpdateCategoryDto category);

        public Task<Result> DeleteCategory(int categoryId);
    }
}
