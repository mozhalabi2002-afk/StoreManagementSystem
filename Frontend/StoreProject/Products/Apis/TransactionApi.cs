using StoreProject.Customers;
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
    public class TransactionDTO
    {

        public int TransactionId { get; set; }

        public int OrderId { get; set; }

        public int? CustomerId { get; set; }
        public double TotalAmount { get; set; }

        public double PaidAmount { get; set; }

        public double RemaingAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DetailsPaid { get; set; }

        public TransactionDTO() { }

        public TransactionDTO(int transactionId, int orderId, int? customerId, double totalAmount, double paidAmount, double remaingAmount, DateTime transactionDate, string detailPaid)
        {
            TransactionId = transactionId;
            OrderId = orderId;
            CustomerId = customerId;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemaingAmount = remaingAmount;
            TransactionDate = transactionDate;
            DetailsPaid = detailPaid;
        }
    }


    public class TransationListDto
    {
        public int TransactionId { get; set; }

        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Identity { get; set; }
        public string PhoneNumber { get; set; }

        public double TotalAmount { get; set; }

        public double PaidAmount { get; set; }

        public double RemaingAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DetailsPaid { get; set; }

        public TransationListDto()
        {

        }

        public TransationListDto(int transactionId, int orderId, string firstName, string lastName, string identity, string phoneNumber, double totalAmount, double paidAmount,
            double remaingAmount, DateTime transactionDate, string detailPaid)
        {


            TransactionId = transactionId;
            OrderId = orderId;


            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemaingAmount = remaingAmount;

            firstName = FirstName;
            lastName = LastName;
            identity = Identity;
            phoneNumber = PhoneNumber;

            TransactionDate = transactionDate;
            DetailsPaid = detailPaid;
        }

    }


    public class TransactionApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<bool> AddNewTransactio(TransactionDTO dto)
        {
            bool IsSuccess = false;

            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:5125/api/Transaction/AddNewTransaction", dto);

                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = await response.Content.ReadFromJsonAsync<bool>();

                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return IsSuccess;
        }

        public static async Task<List<TransationListDto>> GetAllTransation()
        {
            try
            {
                var Product = await client.GetFromJsonAsync<List<TransationListDto>>("http://localhost:5125/api/Transaction/GetTransactionList");
                return Product ?? new List<TransationListDto>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new List<TransationListDto>();
        }

    }

}
