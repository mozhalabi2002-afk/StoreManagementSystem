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

namespace StoreProject.Products.Apis
{
    public class CategoriesDTO
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public CategoriesDTO() { }

        public CategoriesDTO(int CategoryId, string CategoryName)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
        }
    }
    public class ClsCategoryApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<List<CategoriesDTO>> GetAllCategories()
        {
            try
            {
                var categories = await client.GetFromJsonAsync<List<CategoriesDTO>>("http://localhost:5125/api/CategoryApi/GetAllCategories");
                return categories ?? new List<CategoriesDTO>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new List<CategoriesDTO>();
        }

    }
}
