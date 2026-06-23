using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.BillsDTOs;


namespace RestaurantApi.Controllers
{
    [Authorize]
    [Route("api/Bills")]
    [ApiController]
    public class BillsController : ControllerBase
    {

        private readonly IBillServices _bill;

        public BillsController(IBillServices bill)
        {
            _bill = bill;
        }

        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("AllBills")]
        public async Task<ActionResult<IEnumerable<ReadBillsDto>>> GetBills()
        {
            var bills = await _bill.GetBillsAsync();


            return !bills.IsSuccess  ? NotFound(bills.ErrorMessage) : Ok(bills.Data);
        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Bill/{Id}")]
        public async Task<ActionResult<ReadBillsDto>> GetBill(int Id)
        {

            var bill = await _bill.GetBillAsync(Id);

            return bill.IsSuccess  ? NotFound(bill.ErrorMessage) : Ok(bill.Data);

        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("AddNewBill")]
        public async Task<IActionResult> AddNewBill(CreateBillDto newBill)
        {
            var result = await _bill.AddNewBill(newBill);

            return result.IsSuccess ? Created("" , result.Data) : BadRequest(result.ErrorMessage);
        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("UpdateBill/{Id}")]
        public async Task<IActionResult> UpdateBill(int Id, UpdateBillDto bill)
        {

            var result = await _bill.UpdateBill(Id, bill);

            return result.IsSuccess ? Ok("Updated successfully.") : BadRequest(result.ErrorMessage);
        }


        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteBill/{Id}")]
        public async Task<IActionResult> DeleteBills(int Id)
        {

            var result = await _bill.DeleteBill(Id);

            return result.IsSuccess ? Ok("Deleted successfully") : BadRequest(result.ErrorMessage);
        }


    }
}
