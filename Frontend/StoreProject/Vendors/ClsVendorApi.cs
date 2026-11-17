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

namespace StoreProject.Vendors
{
	public class DTOVendor
	{
		public int VendorId { get; set; }
		public int PersonId { get; set; }
		public string VendorName { get; set; }
		public string Password { get; set; }
		public string ShiftTimeStarted { get; set; }
		public string ShiftTimeFinshed { get; set; }
		public double SalaryPerHour { get; set; }
		public int Permission { get; set; }


		public DTOVendor() { }
		public DTOVendor(int VendorId, int PersonId, string VendorName, string Password, string ShiftTimeStarted,
			string ShiftTimeFinshed, double SalaryPerHour, int Permission)
		{
			this.VendorId = VendorId;
			this.PersonId = PersonId;
			this.VendorName = VendorName;
			this.Password = Password;
			this.ShiftTimeStarted = ShiftTimeStarted;
			this.ShiftTimeFinshed = ShiftTimeFinshed;
			this.SalaryPerHour = SalaryPerHour;
			this.Permission = Permission;
		}



	}


	internal class ClsVendorApi
	{
		static readonly HttpClient client = new HttpClient();

	  public  static async Task<List<DTOVendor>> GetAllVendors()
		{
			try
			{

				var vendors = await client.GetFromJsonAsync<List<DTOVendor>>("http://localhost:5125/api/VendorApi/All");
				return vendors;

			}
			catch (HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");
				Console.WriteLine("Message :{0} ", e.Message);
			}

			return null;
		}

	  public static async Task<int> AddNewVenor(DTOVendor dto)
		{

			try
			{


				var response = await client.PostAsJsonAsync("http://localhost:5125/api/VendorApi/CreateNewVendor", dto);

				if (response.IsSuccessStatusCode)
				{
                    dto = await response.Content.ReadFromJsonAsync<DTOVendor>();

				}
				else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
				{
                    dto.VendorId = -1;

				}

			}
			catch (HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");
				Console.WriteLine("Message :{0} ", e.Message);
			}


			return dto.VendorId;
		}

		public static async Task<bool> UpdateVedor(DTOVendor dto)
		{
            bool IsSuccess = false;

            try
            {
                var response = await client.PutAsJsonAsync(
            $"http://localhost:5125/api/VendorApi/UpdateVendor?VendorId={dto.VendorId}", dto);

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

		public static async Task<DTOVendor> FindVedor(int VendorId)
		{
			DTOVendor vendor = null;

			try
			{

                var response = await client.GetAsync($"http://localhost:5125/api/VendorApi/GetVendorById?Vendord={VendorId}");

                if (response.IsSuccessStatusCode)
				{

					vendor = await response.Content.ReadFromJsonAsync<DTOVendor>();

				}
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");
				Console.WriteLine("Message :{0} ", e.Message);
			}

			return vendor;
		}

        public static async Task<bool> DeleteVendorId(int VendorId)
        {
            bool IsSuccess = false;
            try
            {
                var response = await client.DeleteAsync($"http://localhost:5125/api/VendorApi/DeleteVendor?VendorId={VendorId}");
               
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

        public static async Task<DTOVendor> FindVedorByVendorNameAndPassword(string VendorName,string Password)
        {
            DTOVendor vendor = null;

            try
            {

                var response = await client.GetAsync($"http://localhost:5125/api/VendorApi/GetVendorByNameAndPassword?VendorName={VendorName}&Password={Password}");

                if (response.IsSuccessStatusCode)
                {

                    vendor = await response.Content.ReadFromJsonAsync<DTOVendor>();

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return vendor;
        }

    }
}
