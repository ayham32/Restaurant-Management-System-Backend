using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.OrderItemsDTOs;

namespace RestaurantApi.Controllers
{
    [Authorize]
    [Route("api/OrderItems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        private readonly IOrderItemsService _orderItem;

        public OrderItemsController(IOrderItemsService orderItem)
        {
            _orderItem = orderItem;
        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("AllOrderItems")]
        public async Task<ActionResult<IEnumerable<ReadOrderItemsDto>>> GetOrderItems()
        {
            var orderItem = await _orderItem.GetOrderItemsAsync();  


            return !orderItem.IsSuccess ?NotFound(orderItem.ErrorMessage): Ok(orderItem.Data);
        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("OrderItem/{Id}")]
        public async Task<ActionResult<ReadOrderItemsDto>> GetOrderItem(int Id)
        {

            
            var orderItem = await _orderItem.GetOrderItemAsync(Id);
           
            return orderItem.IsSuccess? NotFound(orderItem.ErrorMessage): Ok(orderItem.Data); 

        }



        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("AddNewOrderItem")]
        public async Task<IActionResult> AddNewOrderItem(CreateOrderItemDto newOrderItem)
        {
            var result = await _orderItem.AddNewOrderItem(newOrderItem);

            return result .IsSuccess? Created("" , result.Data): BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("UpdateOrderItem/{Id}")]
        public async Task<IActionResult> UpdateOrderItem(int Id,UpdateOrderItemDto orderItem)
        {
            var result = await _orderItem.UpdateOrderItem(Id, orderItem);
           
            return result.IsSuccess? Ok("Updated successfully.") : BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteOrderItem/{Id}")]
        public async Task<IActionResult> DeleteOrderItem(int Id)
        {

            var result = await _orderItem.DeleteOrderItem(Id);

            return result.IsSuccess ? Ok("Deleted successfully") : BadRequest(result .ErrorMessage);
        }
    }
}
