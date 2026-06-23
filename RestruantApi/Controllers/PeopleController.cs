using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.PeopleDTOs;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;
using RestaurantShared.Results;

namespace RestaurantApi.Controllers
{
    [Authorize]
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _perosn;
        private readonly IUsersService _user;
        public PeopleController(IPeopleService person,IUsersService user)
        {
            _perosn = person;
            _user = user;

        }


        [Authorize(Roles = "Admin")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        
        [HttpGet("AllPeople")]
        public async Task<ActionResult<Result<PagedResult<ReadPeopleDto>>>> GetAllPeople([FromQuery] PersonParameter  personParameter)
        {
            var People = await _perosn.GetAllPeopleAsync(personParameter);

            return People.IsSuccess? Ok(People):NotFound(People.ErrorMessage);
        }

        [ProducesResponseType(statusCode:StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode:StatusCodes.Status404NotFound)]

        [HttpGet("GetPersonWithId/{Id}")] 
        public async Task<ActionResult<Result<ReadPeopleDto>>> GetPerson(int Id)
        {
            if (Id <= 0)
                return BadRequest("You cannot enter a id less than one.");

            var user = await _user.GetUserByPersonId(Id);

            if (user == null)
                return NotFound(user.ErrorMessage);

            bool isntAllow = await IUsersService.isAllow(user.Data.UserId, User);

            if (isntAllow)
                return Forbid();

            var person = await _perosn.GetPersonAsync(Id);

            return person.IsSuccess ? Ok(person.Data):NotFound(person.ErrorMessage);
        }



        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]

        [HttpGet("GetPersonWithNationalNo/{NationalNo}")]
        public async Task<ActionResult<Result<ReadPeopleDto>>> GetPerson(string NationalNo)
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
                return BadRequest("You cannot enter a text empty.");

            var person = await _perosn.GetPersonAsync(NationalNo);

            var user = await _user.GetUserByPersonId(person.Data.PersonId);

            if (user == null)
                return NotFound(user.ErrorMessage);

            bool isntAllow = await IUsersService.isAllow(user.Data.UserId, User);

            if (isntAllow)
                return Forbid();

            return person.IsSuccess  ? Ok(person.Data):NotFound(person.ErrorMessage);
        }



        [Authorize(Roles = "Admin")]

        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]

        [HttpGet("isPersonExistsWithId/{Id}")]
        public async Task<IActionResult> isPersonExist(int Id)
        {
            if (Id <= 0)
                return BadRequest("You cannot enter a id less than one.");

            var person = await _perosn.isPersonExistAsync(Id);

            return !person ? NotFound($"No person with Id = {Id}") : Ok("Yse is exist");
        }



        [Authorize(Roles = "Admin")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]

        [HttpGet("isPersonExistsWithNationalNo/{NationalNo}")]
        public async Task<IActionResult> isPersonExist(string NationalNo)
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
                return BadRequest("You cannot enter a text empty.");

            var person = await _perosn.isPersonExistAsync(NationalNo);

            return !person ? NotFound($"No person with NationalNo = {NationalNo}") : Ok("Yes is exist");
        }


        [Authorize(Roles = "Admin")]

        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]

        [HttpPost("AddNewPerson")]
        public async Task<IActionResult> AddNewPerson(CreatePersonDto newPerson)
        {

            var result = await _perosn.AddNewPersonAsync(newPerson);

            return result.IsSuccess ? Created("",result.Data) : BadRequest(result.ErrorMessage);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]

        [HttpPut ("UpdatePerson/{Id}")]
        public async Task<IActionResult> UpdatePerson(int Id , UpdatePersonDto person)
        {
            if (Id <= 0)
                return BadRequest("You cannot enter a id less than one.");


            var user = await _user.GetUserByPersonId(Id);

            if (user == null)
                return NotFound(user.ErrorMessage);

            bool isntAllow = await IUsersService.isAllow(user.Data.UserId, User);

            if (isntAllow)
                return Forbid();


            var result = await _perosn.UpdatePersonAsync(Id, person);

            return result.IsSuccess? Ok("Updated is successfully.") : BadRequest(result.ErrorMessage);
        }


        [Authorize(Roles = "Admin")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]

        [HttpDelete("DeletePerson{Id}")]
        public async Task<IActionResult> DeletePerson(int Id)
        {
            if (Id <= 0)
                return BadRequest("You cannot enter a id less than one.");



            var result = await _perosn.DeletePersonAsync(Id);

            return result.IsSuccess ? Ok("Deleted is successfully.") : BadRequest(result.ErrorMessage);

        }

    }
}
