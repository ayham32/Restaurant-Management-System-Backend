using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.CategoriesDTOs;

namespace RestaurantApi.Controllers
{
    [Authorize]
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoriesService _category;

        public CategoriesController(ICategoriesService category)
        {
            _category = category;
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("AllCategories")]
        public async Task<ActionResult<IEnumerable<ReadCategoriesDto>>> GetAllCategories()
        {
            var categories = await _category.GetCategoriesAsync();


            return !categories.IsSuccess? NotFound(categories.ErrorMessage) : Ok(categories.Data);

        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("Category/{Id}")]
        public async Task<ActionResult<ReadCategoriesDto>> GetCategory(int Id)
        {

            var category = await _category.GetCategoryAsync(Id);
            
            return !category.IsSuccess ? NotFound(category.ErrorMessage) : Ok(category.Data);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("isCategoryExists/{Id}")]
        public async Task<IActionResult> isCategoryExist(int Id)
        {

            if(Id<=0 )
                return BadRequest("You cannot enter a id less than one.");


            return await _category.isCategoryExistAsync(Id) ? Ok("is exists") : NotFound($"No category with Id: {Id}");
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [HttpPost("AddNewCategory")]
        public async Task<IActionResult> AddNewCategory(CreateCategoryDto newCategory)
        {
            var result = await _category.AddNewCategory(newCategory);

            return result.IsSuccess ? Created("" , result.Data) : BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPut("UpdateCategory/{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id,UpdateCategoryDto category)
        {

            var result = await _category.UpdateCategory(Id, category);

            return result.IsSuccess ? Ok("Updated successfully.") : BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpDelete("DeleteCategory/{Id}")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var result = await _category.DeleteCategory(Id);

            return result.IsSuccess ? Ok("Deleted successfully") : BadRequest(result.ErrorMessage);
        }



    }
}
