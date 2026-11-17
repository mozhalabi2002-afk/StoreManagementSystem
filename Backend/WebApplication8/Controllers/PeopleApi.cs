using BuisnessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleApi : Controller
    {
        [HttpGet("All", Name = "GetAllPeople")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<PeopleDto>> GetAllPeople()
        {
            List<PeopleDto> peopleList = ClsPeople.GetAllPeople();

            if (peopleList.Count == 0)
            {
                return NotFound("There's not any vendor");
            }

            return Ok(peopleList);
        }

        [HttpGet("GetAllPeopleNo", Name = "GetAllPeopleNo")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<string>> GetAllPeopleNo()
        {
            List<string> peopleList = ClsPeople.GetAllNo();

            if (peopleList.Count == 0)
            {
                return NotFound("There's any people");
            }

            return Ok(peopleList);
        }

        [HttpGet("IsPersonExist", Name = "IsPersonExist")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult IsPeronExist(int PersonId)
        {
            bool IsFound = ClsPeople.IsPersonExist(PersonId);

            if (!IsFound)
            {
                return NotFound("There's any Person");
            }

            return StatusCode(500, $"Person with id : {PersonId} is found");
        }



        [HttpPost("CreateNewPerson", Name = "CreateNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<PeopleDto>> CreateNewPerson([FromBody] PeopleDto dto)
        {

            if (dto == null || string.IsNullOrEmpty(dto.FirstName) ||
                string.IsNullOrEmpty(dto.SecondName)|| string.IsNullOrEmpty(dto.LastName)||
                ((dto.No).ToString()).Length!=9|| ((dto.PhoneNumber).ToString()).Length != 10)
            {

                return BadRequest("Invaild Pesron information");
            }

            ClsPeople person = new ClsPeople(dto, ClsPeople.eMode.AddNew);

            if (person.Save())
            {
                dto.PersonId = person.PersonId;
                return CreatedAtRoute("GetPersonById", new { PersonId = dto.PersonId }, dto);
            }
            else
            {
                return StatusCode(500, "Failed to add new person");

            }


        }


        [HttpPut("UpdatePerson",Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PeopleDto> UpdatePerson(int id,[FromBody] PeopleDto dto)
        {
            if (dto == null || id < 1 ||
                string.IsNullOrEmpty(dto.FirstName) ||
                string.IsNullOrEmpty(dto.SecondName) ||
                string.IsNullOrEmpty(dto.LastName) ||
                dto.No.ToString().Length != 9 ||
                dto.PhoneNumber.ToString().Length != 10)
            {
                return BadRequest("Invalid data");
            }

            if (id != dto.PersonId)
            {
                return BadRequest("ID mismatch");
            }

            var person = ClsPeople.FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person with ID {id} not found.");
            }

            person.FirstName = dto.FirstName;
            person.SecondName = dto.SecondName;
            person.LastName = dto.LastName;
            person.No = dto.No;
            person.PhoneNumber = dto.PhoneNumber;

            if (person.Save())
            {
                return Ok(person.People);
            }

            return StatusCode(500, "Failed to update person");
        }

        [HttpDelete("DeletePerson", Name = "DeletePerson")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePerson(int PersonId)
        {
            if (PersonId < 1)
            {
                return BadRequest("PersonId is Invaild");

            }

            ClsPeople person = ClsPeople.FindPerson(PersonId);


            if (person == null)
            {
                return NotFound($"The person with {PersonId} is not found");
            }


            if (ClsPeople.DeletePerson(PersonId))
            {
                return Ok("Delete perosn is Suceefully");
            }
            else
            {
                return Ok("Delete perosn is not Suceefully");

            }
        }

        [HttpGet("GetPersonById", Name = "GetPersonById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PeopleDto> GetPersonById(int PersonId)
        {

            if (PersonId < 1)
            {
                return BadRequest($"Not accepted Id :{PersonId}");
            }

            ClsPeople person = ClsPeople.FindPerson(PersonId);


            if (person == null)
            {
                return NotFound($"Person with id {PersonId} not found");
            }

            PeopleDto dto = person.People;

            return Ok(dto);

        }


       
    }
}
