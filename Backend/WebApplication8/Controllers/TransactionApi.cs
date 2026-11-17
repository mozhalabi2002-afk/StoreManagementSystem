using BuisnessLayer;
using Microsoft.AspNetCore.Mvc;
using StoreBussinessLayer;
using StortDataAccessLayer;

namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("api/Transaction")]
    public class TransactionApi : Controller
    {
        [HttpPost("AddNewTransaction", Name = "AddNewTransaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<bool>> AddNewTransaction(TransactionDTO dto)
        {

            if (dto.OrderId <= 0||dto.TransactionId<0)
            {

                return BadRequest(false);
            }


            if (ClsTransaction.AddNewTransaction(dto))
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500, false);
            }


        }

        [HttpGet("GetTransactionList", Name = "GetTransactionList")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TransationListDto>> GetTransactionList()
        {
            List<TransationListDto> list = ClsTransaction.GetAllTransationList();

            if (list!=null)
            {
                return Ok(list);
            }
            else
            {
                return StatusCode(500, list);
            }


        }


    }
}
