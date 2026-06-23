using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.OrdersDTOs;

namespace RestaurantApi.Controllers
{
    [Authorize]
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
         
        private readonly IOrdersService _order;

        public OrdersController(IOrdersService order)
        {
            _order = order;
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("AllOrders")]
        public async Task<ActionResult<IEnumerable<ReadOrdersDto>>> GetAllOrders()
        {
            var orders = await _order.GetOrdersAsync();

            return !orders.IsSuccess  ? NotFound(orders.ErrorMessage) : Ok(orders.Data);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Order/{Id}")]
        public async Task<ActionResult<ReadOrdersDto>> GetOrder(int Id)
        {
            

           var order = await _order.GetOrderAsync(Id);

           

            return order.IsSuccess ? NotFound(order.ErrorMessage) : Ok(order.Data);


        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("isOrderExists/{Id}")]
        public async Task<IActionResult> isOrderExist(int Id)
        {
            if (Id <= 0)
                return BadRequest("You cannot enter a id less than one.");

            return await _order.isOrderExistAsync(Id)?Ok("Yes is exist") : NotFound($"No order with Id: {Id}");
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("AddNewOrder")]
        public async Task<IActionResult> AddNewOrder(CreateOrderDto newOrder)
        {
            var result = await _order.AddNewOrderAsync(newOrder);

            return result.IsSuccess? Created("" ,result.Data) : BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("UpdateOrder/{Id}")]
        public async Task<IActionResult> UpdateOrder(int Id,UpdateOrderDto order)
        {

            var result = await _order.UpdateOrderAsync(Id, order);

            return result.IsSuccess ? Ok("Updated successfully.") : BadRequest(result.ErrorMessage);
        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteOrder/{Id}")]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var result = await _order.DeleteOrder(Id);

            return result.IsSuccess ? Ok("Deleted successfully.") : BadRequest(result.ErrorMessage);
        }



    }
}
