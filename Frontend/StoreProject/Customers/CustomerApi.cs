using StoreProject.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StoreProject.Customers
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public PeopleDto person { get; set; }

        public string Password { get; set; }
        public int PersonId { get; set; }

        public CustomerDTO()
        {

            person = new PeopleDto();

        }

        public CustomerDTO(int CustomerId, string CustomerName, string Password, int PersonId)
        {

            this.CustomerId = CustomerId;
            this.CustomerName = CustomerName;
            this.Password = Password;
            this.PersonId = PersonId;


        }

    }

    internal class CustomerApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<List<CustomerDTO>> GetAllCustomers()
        {
            try
            {

                var customers = await client.GetFromJsonAsync<List<CustomerDTO>>("http://localhost:5125/api/CustomerApi/All");
                return customers;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public static async Task<int> AddNewCustomer(CustomerDTO dto)
        {

            try
                
            {
                var response = await client.PostAsJsonAsync("http://localhost:5125/api/CustomerApi/CreateNewCustomer", dto);

                if (response.IsSuccessStatusCode)
                {
                    dto = await response.Content.ReadFromJsonAsync<CustomerDTO>();

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    dto.CustomerId = -1;

                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }


            return dto.CustomerId;
        }

        public static async Task<bool> UpdateCustomer(CustomerDTO dto)
        {
            bool IsSuccess = false;

            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/CustomerApi/UpdateCustomer?CustomerId={dto.CustomerId}", dto);

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

        public static async Task<CustomerDTO> FindCustomer(int CustomerId)
        {
            CustomerDTO customer = null;

            try
            {

                var response = await client.GetAsync($"http://localhost:5125/api/CustomerApi/GetCustomerById?CustomerId={CustomerId}");

                if (response.IsSuccessStatusCode)
                {

                    customer = await response.Content.ReadFromJsonAsync<CustomerDTO>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return customer;
        }

        public static async Task<bool> DeleteCustomerId(int CustomerId)
        {
            bool IsSuccess = false;
            try
            {
                var response = await client.DeleteAsync($"http://localhost:5125/api/CustomerApi/DeleteCustomer?CustomerId={CustomerId}");

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

        public static async Task<CustomerDTO> FindCustomerByCustomerNameAndPassword(string CustomerName, string Password)
        {
            CustomerDTO customer = null;

            try
            {

                var response = await client.GetAsync($"http://localhost:5125/api/CustomerApi/GetCustomerByNameAndPassword?CustomerName={CustomerName}&Password={Password}");

                if (response.IsSuccessStatusCode)
                {

                    customer = await response.Content.ReadFromJsonAsync<CustomerDTO>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return customer;
        }


    }
}
