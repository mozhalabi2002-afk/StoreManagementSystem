using StoreProject.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.People
{
    public class PeopleDto
    {

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public int PhoneNumber { get; set; }

        public PeopleDto() { }

        public PeopleDto(int PersonId, string FirstName,
            string SecondName, string LastName, int No, int PhoneNumber)
        {
            this.PersonId = PersonId;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.No = No;
            this.PhoneNumber = PhoneNumber;
        }


    }



    internal class PeopleApi
    {
        static readonly HttpClient client = new HttpClient();
        static PeopleApi()
        {
            client.BaseAddress = new Uri("http://localhost:5125/api/PeopleApi/");
        }

        public static async Task<List<PeopleDto>> GetAllPeople()
        {
            try
            {
                var people = await client.GetFromJsonAsync<List<PeopleDto>>("http://localhost:5125/api/PeopleApi/All");
                return people ?? new List<PeopleDto>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new List<PeopleDto>();
        }

        public static async Task<List<string>> GetAllPeopleNo()
        {
            try
            {
                var people = await client.GetFromJsonAsync<List<string>>("http://localhost:5125/api/PeopleApi/GetAllPeopleNo");
                return people ?? null;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }
        public static async Task<int> AddNewPerson(PeopleDto dto)
        {


            try
            {


                var response = await client.PostAsJsonAsync("http://localhost:5125/api/PeopleApi/CreateNewPerson", dto);

                if (response.IsSuccessStatusCode)
                {
                    dto = await response.Content.ReadFromJsonAsync<PeopleDto>();

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    dto.PersonId = -1;

                }



            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return dto.PersonId;
        }

        public static async Task<bool> UpdatePerson(PeopleDto dto)
        {
            bool IsSuccess = false;
           
            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/PeopleApi/UpdatePerson?id={dto.PersonId}", dto);

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

        public static async Task<PeopleDto> FindPerson(int PersonId)
        {
            PeopleDto People = null;

            try
            {


                var response = await client.GetAsync($"http://localhost:5125/api/PeopleApi/GetPersonById?PersonId={PersonId}");

                if (response.IsSuccessStatusCode)
                {

                    People = await response.Content.ReadFromJsonAsync<PeopleDto>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return People;
        }


        static async Task<bool> DeletePeopleId(int PersonId)
        {
            bool IsSuccess = false;
            try
            {
                var response = await client.DeleteAsync($"http://localhost:5125/api/PeopleApi/DeletePerson?PersonId{PersonId}");
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
   
    }
}
