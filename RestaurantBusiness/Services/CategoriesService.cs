
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.CategoriesDTOs;
using RestaurantShared.Entities;
using RestaurantShared.Results;
using RestuarantDataAccess.UintOfWork;

namespace RestaurantBusiness.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> AddNewCategory(CreateCategoryDto newCategory)
        {
            
            var category = new Category
            {
                CategoryName = newCategory.CategoryName
            };

            await _unitOfWork.categoriesRepository.AddAsync(category);
            
            
            return await _unitOfWork.SaveChangesAsync() > 0? Result<int>.Success(category.CategoryId): Result<int> .Failure("Something is wrong");
        }

        public async Task<Result> DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
                return Result.Failure("id must be a postive");

            var category = await _unitOfWork.categoriesRepository.GetByIdAsync(categoryId);

            _unitOfWork.categoriesRepository.DeleteAsync(category);

            return await _unitOfWork.SaveChangesAsync() >0? Result.Success(): Result.Failure("Something is wrong");
        }

        public async Task<Result<List<ReadCategoriesDto>>> GetCategoriesAsync()
        {
            var Categories = await _unitOfWork.categoriesRepository.GetAllAsync();

            if(Categories== null)
                return Result<List<ReadCategoriesDto>>.Failure("No there are Categories");

            var CategoriesDto = Categories.Select(c => new ReadCategoriesDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();


            return Result<List<ReadCategoriesDto>>.Success(CategoriesDto);

        }

        public async Task<Result<ReadCategoriesDto>>? GetCategoryAsync(int categoryId)
        {
            if (categoryId <= 0)
                return Result<ReadCategoriesDto>.Failure("id must be a postive");

            var category = await _unitOfWork.categoriesRepository.GetByIdAsync(categoryId);

            if (category == null)
                return Result<ReadCategoriesDto>.Failure("No exist category with this id");

            var categoryDto = new ReadCategoriesDto
            {
                CategoryId = categoryId,
                CategoryName = category.CategoryName
            };

            return Result<ReadCategoriesDto>.Success(categoryDto);
        }

        public async Task<bool> isCategoryExistAsync(int categoryId)
        {
            if (categoryId <= 0)
                return false;

            return await _unitOfWork.categoriesRepository.isExistAsync(categoryId);
        }

        public async Task<Result> UpdateCategory(int categoryId, UpdateCategoryDto category)
        {
            if (categoryId <= 0)
                return Result.Failure("id must be a postive");

            var categoryToUpdate = await _unitOfWork.categoriesRepository.GetByIdAsync(categoryId);

            categoryToUpdate.CategoryName = category.CategoryName;

            return await _unitOfWork.SaveChangesAsync() >0? Result.Success():Result.Failure("Something is wrong");
        }
    }
}
