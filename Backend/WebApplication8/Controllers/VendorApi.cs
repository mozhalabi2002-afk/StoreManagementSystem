using BuisnessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VendorApi : Controller
    {

        [HttpGet("All",Name ="GetAllVenders")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        
        

        public ActionResult<IEnumerable<DTOVendor>> GetAllVenders()
        {
            List<DTOVendor> vendorList = ClsVendors.GetAllVendors();

            if (vendorList.Count == 0)
            {
                return NotFound("There's any vendor"); 
            }

            return Ok(vendorList);
        }

        [HttpPost("CreateNewVendor", Name = "CreateNewVendor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<DTOVendor>> CreateNewVendor([FromBody] DTOVendor dto)
        {
            
            if (dto == null || string.IsNullOrEmpty(dto.VendorName) || string.IsNullOrEmpty(dto.Password))
            {

                return BadRequest("Invaild vendor information");
            }

            ClsVendors vendor = new ClsVendors(dto, ClsVendors.eMode.eAddNew);

            if (vendor.Save())
            {
                dto.VendorId = vendor.VendorId;
                return CreatedAtRoute("GetVendorById", new { Id = dto.VendorId }, dto);
            }
            else
            {
                return StatusCode(500, "Failed to add new a vendor");

            }


        }


        [HttpPut("UpdateVendor", Name = "UpdateVendor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<DTOVendor> UpdateVendor(int VendorId, [FromBody] DTOVendor dto)
        {
            if (dto == null || dto.VendorId < 0 || string.IsNullOrEmpty(dto.VendorName) || string.IsNullOrEmpty(dto.Password))
            {
                return BadRequest($"Not accepted Id {VendorId}");
            }

            ClsVendors vendor = ClsVendors.FindVendor(VendorId);

            if (vendor == null)
            {
                return NotFound($"Vendor with ID {dto.VendorId} not found.");
            }

            vendor.VendorName = dto.VendorName;
            vendor.Password = dto.Password;
            vendor.ShiftTimeStarted = dto.ShiftTimeStarted;
            vendor.ShiftTimeFinshed = dto.ShiftTimeFinshed;
            vendor.SalaryPerHour = dto.SalaryPerHour;
            vendor.Permission = dto.Permission;

            if (vendor.Save())
            {
                return Ok(vendor.Vendor);
            }
            else
            {
                return StatusCode(500, "Failed to update person");

            }
        }


        [HttpDelete("DeleteVendor", Name = "DeleteVendor")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult DeleteVendor(int VendorId)
        {
            if (VendorId < 1)
            {
                return BadRequest("Id is Invaild");

            }


            ClsVendors vendor = ClsVendors.FindVendor(VendorId);

            

            if (vendor == null)
            {
                return NotFound($"The vendor with {VendorId} is not found");
            }


            if (ClsVendors.DeleteVendor(VendorId, vendor.PersonId))
            {

                return Ok("Delete Vendor is Suceefully");
            }
            else
            {
                return StatusCode(500, "Failed to update person");

            }
        }

        [HttpGet("GetVendorById", Name = "GetVendorById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTOVendor> GetVendorById(int Vendord)
        {

            if (Vendord < 1)
            {
                return BadRequest($"Not accepted Id :{Vendord}");
            }

            ClsVendors vendor = ClsVendors.FindVendor(Vendord);


            if (vendor == null)
            {
                return NotFound($"Vendor with id {Vendord} not found");
            }

            DTOVendor dto = vendor.Vendor;

            return Ok(dto);

        }

        [HttpGet("GetVendorByNameAndPassword", Name = "GetVendorByNameAndPassword")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTOVendor> GetvendorByNameAndPassword(string VendorName, string Password)
        {

            if (string.IsNullOrEmpty(VendorName) || string.IsNullOrEmpty(Password))
            {
                return BadRequest($"Not accepted vendorName :{VendorName} and {Password}");
            }

            ClsVendors vendor = ClsVendors.FindVendorByUserNameAndPassword(VendorName, Password);

            if (vendor == null)
            {
                return NotFound($"Vendor with name: {VendorName} not found");
            }

            DTOVendor dto = vendor.Vendor;

            return Ok(dto);

        }

    }
}
