using BuisnessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CustomerApi : Controller
    {

        [HttpGet("All", Name = "GetAllCustomers")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            List<CustomerDTO> customers = ClsCustomers.GetAllCustomers();

            if (customers.Count == 0)
            {
                return NotFound("There's not any customer");
            }

            return Ok(customers);
        }



        [HttpPost("CreateNewCustomer", Name = "CreateNewCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<CustomerDTO>> CreateNewCustomer([FromBody] CustomerDTO dto)
        {

            if (dto == null || string.IsNullOrEmpty(dto.CustomerName) || string.IsNullOrEmpty(dto.Password))
            {

                return BadRequest("Invaild customer information");
            }

            ClsCustomers Customer = new ClsCustomers(dto);

            if (Customer.Save())
            {
                dto.CustomerId = Customer.CustomerId;
                return CreatedAtRoute("GetCustomerById", new { Id = dto.CustomerId }, dto);
            }
            else
            {
                return StatusCode(500, "Failed to add new a customer");
            }


        }


        [HttpPut("UpdateCustomer", Name = "UpdateCustomer")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<CustomerDTO> UpdateCustomer(int CustomerId,[FromBody] CustomerDTO dto)
        {
            if (dto == null || dto.CustomerId < 0 || string.IsNullOrEmpty(dto.CustomerName)||string.IsNullOrEmpty(dto.Password))
            {
                return BadRequest($"Not accepted Id {CustomerId}");
            }

            ClsCustomers Customer = ClsCustomers.FindCustomer(CustomerId);

            if (Customer == null)
            {
                return NotFound($"Customer with ID {dto.CustomerId} is not found.");
            }

            Customer.CustomerName = dto.CustomerName;

            if (Customer.Save())
            {
                return Ok(Customer.customer);
            }
            else
            {
                return StatusCode(500, "Failed to Update a customer");

            }
        }


        [HttpDelete("DeleteCustomer", Name = "DeleteCustomer")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCustomer(int CustomerId)
        {
            if (CustomerId < 1)
            {
                return BadRequest("Id is Invaild");

            }

            ClsCustomers Customer = ClsCustomers.FindCustomer(CustomerId);


            if (Customer == null)
            {
                return NotFound($"The customer with {CustomerId} is not found");
            }


            if (ClsCustomers.DeleteCustomer(CustomerId,Customer.PersonId))
            {
                return Ok("Delete Customer is Suceefully");
            }
            else
            {
                return StatusCode(500, "Failed to delete a customer");


            }
        }

        [HttpGet("GetCustomerById", Name = "GetCustomerById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetCustomerById(int CustomerId)
        {

            if (CustomerId < 1)
            {
                return BadRequest($"Not accepted Id :{CustomerId}");
            }

            ClsCustomers Customer = ClsCustomers.FindCustomer(CustomerId);


            if (Customer == null)
            {
                return NotFound($"Customer with id {CustomerId} is not found");
            }

            CustomerDTO dto = Customer.customer;

            return Ok(dto);

        }

        [HttpGet("GetCustomerByNameAndPassword", Name = "GetCustomerByNameAndPassword")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetCustomerByNameAndPassword(string CustomerName, string Password)
        {

            if (string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(Password))
            {
                return BadRequest($"Not accepted CustomerName :{CustomerName} and {Password}");
            }

            ClsCustomers Customer = ClsCustomers.FindCustomerByCustomerNameAndPassword(CustomerName, Password);

            if (Customer == null)
            {
                return NotFound($"Customer with name: {CustomerName} not found");
            }

            CustomerDTO dto = Customer.customer;

            return Ok(dto);

        }

    }
}
