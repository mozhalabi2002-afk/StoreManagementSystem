using StoreProject.People;
using StoreProject.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Products
{
    public class ClsBasket
    {
        public List<ProductBookingDTO> Basket = new List<ProductBookingDTO>();
        
        public async Task CleanBasket()
        {
            if (Basket.Count > 0)
            {
                foreach (ProductBookingDTO item in Basket)
                {
                    await ProductApi.ReturnProduct(item);
                }
            }

            Basket.Clear();
        }   
    }

  
    public class ProductDTO
    {
        public enum eSaleType1 { eSaleByQuantity = 1, eSaleByWeight = 2 }

        public eSaleType1 SaleType { get; set; } = eSaleType1.eSaleByQuantity;

        public int ProductId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        private int _Quantity = 1;
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value < 1 ? 1 : value; }
        }

        public double Price { get; set; }

        public string Image { get; set; }

        public double Weight { get; set; }

        public double Size { get; set; }

        public string Parcode { get; set; }

        public ProductDTO()
        {
        }

        public ProductDTO(int productId, string categoryName, string productName, int quantity,
            double price, string image, double weight, double size, string parcode, eSaleType1 saleType)
        {
            ProductId = productId;
            CategoryName = categoryName;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Image = image;
            Weight = weight;
            Size = size;
            Parcode = parcode;
            SaleType = saleType;
        }
    
    }

    public class ShortOrderDto
    {
        public int OrderId { get; set; }

        public double TotalAmount { get; set; }

        public ShortOrderDto()
        {

        }
        public ShortOrderDto(int orderId, double totalAmount)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
        }
    }

    public class ProductBookingDTO
    {
        public enum eSaleType1 { eSaleByQuantity = 1, eSaleByWeight = 2 }

        public eSaleType1 SaleType { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }
        public int OldQuantity { get; set; }

        public double OldWeight { get; set; }

        public ProductBookingDTO(int productId, int quantity, double weight, int oldQuantity,
            double oldWeight, eSaleType1 SaleType)
        {
            ProductId = productId;
            Quantity = quantity;
            Weight = weight;
            OldQuantity = oldQuantity;
            OldWeight = oldWeight;
            this.SaleType = SaleType;
        }

        public ProductBookingDTO() { }

    }

    internal class ProductApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<List<ProductDTO>> GetAllProducts()
        {
            try
            {
                var Product = await client.GetFromJsonAsync<List<ProductDTO>>("http://localhost:5125/api/Product/All");
                return Product ?? new List<ProductDTO>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new List<ProductDTO>();
        }

        public static async Task<List<ProductDTO>> GetProductsByCategoryName(string CategoryName)
        {

            try
            {
                CategoryName = CategoryName.Replace(" ", "%20").Replace("&", "%26");

                var response = await client.GetAsync($"http://localhost:5125/api/Product/GetProductsByCategoryName?CategoryName={CategoryName}");

                if (response.IsSuccessStatusCode)
                {

                    var Products = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
                    return Products ?? new List<ProductDTO>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new List<ProductDTO>();

        }
        public static async Task<int> AddNewProduct(ProductDTO dto)
        {

            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:5125/api/Product/CreateNewProduct", dto);

                if (response.IsSuccessStatusCode)
                {
                    dto = await response.Content.ReadFromJsonAsync<ProductDTO>();

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    dto.ProductId = -1;

                }



            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return dto.ProductId;
        }

        public static async Task<bool> UpdateProduct(ProductDTO dto)
        {
            bool IsSuccess = false;

            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/Product/UpdateProduct?ProductId={dto.ProductId}", dto);

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;
        }

        public static async Task<ProductDTO> FindProduct(int ProductId)
        {
            ProductDTO Product = null;

            try
            {


                var response = await client.GetAsync($"http://localhost:5125/api/Product/GetProductById?ProductId={ProductId}");

                if (response.IsSuccessStatusCode)
                {

                    Product = await response.Content.ReadFromJsonAsync<ProductDTO>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return Product;
        }
       public static async Task<bool> DeleteProductId(int ProductID)
        {
            bool IsSuccess = false;
            try
            {
                var response = await client.DeleteAsync($"http://localhost:5125/api/Product/DeleteProduct?ProductId={ProductID}");
                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return IsSuccess;
        }

        public static async Task<bool> IsProductExist(int ProductId)
        {
            bool IsExist = false;

            try
            {


                var response = await client.GetAsync($"http://localhost:5125/api/Product/IsProductExistById?ProductId={ProductId}");

                if (response.IsSuccessStatusCode)
                {

                   IsExist=true;

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsExist;
        }

        public static async Task<bool> BookingProduct(ProductBookingDTO dto)
        {
            bool IsSuccess = false;

            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/Product/BookingProduct", dto);

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;
        }

        public static async Task<ShortOrderDto> PayProducts(int? CustomerId)
        {
            ShortOrderDto order = new ShortOrderDto();

            try
            {

                var response = await client.GetAsync($"http://localhost:5125/api/Product/BuyProducts?CustomerId={CustomerId}");

                if (response.IsSuccessStatusCode)
                {

                    order = await response.Content.ReadFromJsonAsync<ShortOrderDto>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return order;
        }

        public static async Task<bool> UpdateBookingProduct(ProductBookingDTO dto)
        {
            bool IsSuccess = false;

            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/Product/UpdateBookingProduct", dto);

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;
        }

        public static async Task<bool> ReturnProduct(ProductBookingDTO dto)
        {
            bool IsSuccess = false;

            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/Product/ReturnProduct", dto);

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;
        }

        public static async Task<bool> CancelOrder(int OrderId)
        {
            bool IsSuccess = false;

            try
            {

                var response = await client.GetAsync(
            $"http://localhost:5125/api/Order/CancelOrder?OrderId={OrderId}");

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;


            
        }

        public static async Task<bool> CompleteOrder(int OrderId)
        {
            bool IsSuccess = false;

            try
            {

                var response = await client.GetAsync(
            $"http://localhost:5125/api/Order/CompleteOrder?OrderId={OrderId}");

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = true;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;



        }

      


    }
}
