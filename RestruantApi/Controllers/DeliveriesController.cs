

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.InterfaceServices;
using RestaurantDataAccess.Entities;
using RestaurantShared.DTOs.BillsDTOs;
using RestaurantShared.DTOs.DeliveriesDTOs;

namespace RestaurantApi.Controllers
{
    [Authorize]
    [Route("api/Deliveries")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveriesService _delivery;

        public DeliveriesController(IDeliveriesService delivery)
        {
            _delivery = delivery;
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("AllDeliveries")]
        public async Task<ActionResult<IEnumerable<ReadDeliveriesDto>>> GetDeliveries()
        {
            var deliveries = await _delivery.GetDeliveriesAsync();


            return !deliveries.IsSuccess ? NotFound(deliveries.ErrorMessage) : Ok(deliveries.Data);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Delivery/{Id}")]
        public async Task<ActionResult<ReadDeliveriesDto>> GetDelivery(int Id)
        {

            var delivery = await _delivery.GetDeliveryAsync(Id);
           
            return !delivery.IsSuccess ? NotFound(delivery.ErrorMessage) : Ok(delivery.Data);

        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("AddNewDelivery")]
        public async Task<IActionResult> AddNewBill(CreateDeliveryDto newDelivery)
        {
            var result = await _delivery.AddNewDeliveryAsync(newDelivery);

            return result.IsSuccess ? Created("",result.Data) : BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("UpdateDelivery/{Id}")]
        public async Task<IActionResult> UpdateBill(int Id, UpdateDeliveryDto delivery)
        {

            var result = await _delivery.UpdateDeliveryAsync(Id, delivery);

            return result.IsSuccess? Ok("Updated successfully.") : BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteDelivery/{Id}")]
        public async Task<IActionResult> DeleteDelivery(int Id)
        {

            var result = await _delivery.DeleteDeliveryAsync(Id);

            return  result .IsSuccess? Ok("Deleted successfully") : BadRequest(result.ErrorMessage);
        }


    }
}
