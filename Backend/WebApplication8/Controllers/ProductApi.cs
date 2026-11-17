using BuisnessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductApi : Controller
    {
        [HttpGet("All", Name = "GetAllProducts")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            List<ProductDTO> Products = ClsProduct.GetAllProducts();

            if (Products.Count == 0)
            {
                return NotFound("There's any product");
            }

            return Ok(Products);
        }


        [HttpGet("GetProductsByCategoryName", Name = "GetProductsByCategoryName")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<ProductDTO>> GetProductsByCategoryName(string CategoryName)
        {

            
            List<ProductDTO> Products = ClsProduct.GetProductsByCateoryName(CategoryName);

            if (Products.Count == 0)
            {
                return NotFound("There's any product");
            }

            return Ok(Products);

        }

        [HttpPost("CreateNewProduct", Name = "CreateNewProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<IEnumerable<ProductDTO>> CreateNewProduct([FromBody] ProductDTO dto)
        {

            if (dto == null || string.IsNullOrEmpty(dto.ProductName) ||
                string.IsNullOrEmpty(dto.CategoryName) || string.IsNullOrEmpty(dto.Image) || dto.Weight < 0 || dto.Quantity < 1 || dto.Price <= 0)
            {

                return BadRequest("Invaild vendor information");
            }

            ClsProduct product = new ClsProduct(dto, ClsProduct.eMode.eAddNew);

            if (product.Save())
            {
                dto.ProductId = product.ProductId;
                return CreatedAtRoute("GetProductById", new { ProductId2 = dto.ProductId }, dto);
            }
            else
            {
                return StatusCode(500, "Failed to add a new product");
            }


        }


        [HttpPut("UpdateProduct", Name = "UpdateProduct")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<ProductDTO> UpdateProduct(int ProductId,[FromBody] ProductDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.ProductName) ||
                string.IsNullOrEmpty(dto.CategoryName) || string.IsNullOrEmpty(dto.Image) || dto.Weight < 0 || dto.Quantity < 1 || dto.Price <= 0)
            {

                return BadRequest("Invaild product information");
            }

            ClsProduct product = ClsProduct.FindProduct(ProductId);

            if (product == null)
            {
                return NotFound($"Product with ID {dto.ProductId} not found.");
            }

            product.ProductId = dto.ProductId;
            product.CategoryName = dto.CategoryName;
            product.ProductName = dto.ProductName;
            product.SaleType = (ClsProduct.eSaleType)(dto.SaleType);
            product.Quantity = dto.Quantity;
            product.Price = dto.Price;
            product.Image = dto.Image;
            product.Weight = dto.Weight;
            product.Size = dto.Size;
            product.Parcode = dto.Parcode;


            if (product.Save())
            {
                return Ok(product.product);
            }
            else
            {
                return StatusCode(500, "Failed to update a person");
            }
        }



        [HttpGet("BuyProducts", Name = "BuyProducts")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<ShortOrderDto> BuyProducts(int? CustomerId)
        {


            ShortOrderDto order = ClsProduct.BuyProducts(CustomerId,1);

            if (order!= null)
                return Ok(order);

            return StatusCode(500, "Failed to update a person");

        }

        [HttpPut("BookingProduct", Name = "BookingProduct")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<ProductBookingDTO> BookingProduct(ProductBookingDTO dto)
        {
            if (dto == null || dto.ProductId<1 || dto.Weight < 0 || dto.Quantity < 1)
            {

                return BadRequest("Invaild product information");
            }

            bool IsBooking = ClsProduct.BookingProduct(dto,1);

            if (IsBooking)
            {
                return Ok(dto);
            }
            else
            {
                return StatusCode(500, "Failed booking product");
            }

        }

        [HttpPut("UpdateBookingProduct", Name = "UpdateBookingProduct")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ProductBookingDTO> UpdateBookingProduct(ProductBookingDTO dto)
        {
            if (dto == null || dto.ProductId < 1 || dto.Weight < 0 || dto.Quantity < 1)
            {

                return BadRequest("Invaild product information");
            }

            bool IsBooking = ClsProduct.UpdateBookingProduct(dto,1);

            if (IsBooking)
            {
                return Ok(dto);
            }
            else
            {
                return StatusCode(500, "Failed update booking product");
            }

        }

        [HttpPut("ReturnProduct", Name = "ReturnProduct")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ProductBookingDTO> ReturnProduct(ProductBookingDTO dto)
        {
            if (dto == null || dto.ProductId < 1 || dto.Weight < 0 || dto.Quantity < 1)
            {

                return BadRequest("Invaild product information");
            }

            bool IsBooking = ClsProduct.ReturnBooking(dto,1);

            if (IsBooking)
            {
                return Ok(dto);
            }
            else
            {
                return StatusCode(500, "Failed return this product");
            }

        }



        [HttpDelete("DeleteProduct", Name = "DeleteProduct")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult DeleteProduct(int ProductId)
        {
            if (ProductId < 1)
            {
                return BadRequest("Id is Invaild");

            }

            ClsProduct product = ClsProduct.FindProduct(ProductId);

            if (product == null)
            {
                return NotFound($"The product with {ProductId} is not found");
            }


            if (ClsProduct.DeleteProduct(ProductId))
            {
                return Ok("Delete Product is Suceefully");
            }
            else
            {
                return StatusCode(500, "Failed delete a product");
            }
        }

        [HttpGet("GetProductById", Name = "GetProductById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDTO> GetProductById(int ProductId)
        {

            if (ProductId < 1)
            {
                return BadRequest($"Not accepted Id :{ProductId}");
            }

            ClsProduct product = ClsProduct.FindProduct(ProductId);

            if (product == null)
            {
                return NotFound($"Product with id {ProductId} not found");
            }

            ProductDTO dto = product.product;

            return Ok(dto);

        }


        [HttpGet("IsProductExistById", Name = "IsProductExistById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsProductExistById(int ProductId)
        {

            if (ProductId < 1)
            {
                return BadRequest($"Not accepted Id :{ProductId}");
            }

           bool IsExist=ClsProduct.IsProductExist(ProductId);   

            if (!IsExist)
            {
                return NotFound($"Product with id {ProductId} not found");
            }


            return Ok(true);

        }


    }
}
