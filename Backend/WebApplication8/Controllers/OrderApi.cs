using BuisnessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderApi : Controller
    {
        [HttpGet("CancelOrder", Name = "CancelOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<IEnumerable<bool>> CancelOrder(int OrderId)
        {

            if (OrderId<0)
            {

                return BadRequest("Invaild order information");
            }

            
            if (ClsOrder.CancelOrder(OrderId))
            {
                return Ok("Canceled Orderd");
            }
            else
            {
                return StatusCode(500, "Failed to cancel order");
            }


        }


        [HttpGet("CompleteOrder", Name = "CompleteOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<IEnumerable<bool>> CompleteOrder(int OrderId)
        {

            if (OrderId < 0)
            {

                return BadRequest("Invaild order information");
            }


            if (ClsOrder.CompleteOrder(OrderId))
            {
                return Ok("Complete Orderd");
            }
            else
            {
                return StatusCode(500, "Failed to Complete order");
            }


        }

    }
}
