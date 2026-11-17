using BuisnessLayer;
using BussinessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApi : Controller
    {
        [HttpGet("GetAllCategories", Name = "GetAllCategories")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  ActionResult<IEnumerable<CategoriesDTO>> GetAllCategories()
        {
            List<CategoriesDTO> List = ClsCategory.GetAllCategories();

            if (List.Count == 0)
            {
                return NotFound("There's any category");
            }

            return Ok(List);

        }

    }
}
