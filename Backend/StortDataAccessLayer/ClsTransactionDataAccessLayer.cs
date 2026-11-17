using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StortDataAccessLayer
{

    public class TransactionDTO {
        
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

        public TransationListDto(int transactionId, int orderId,string firstName,string lastName,string identity,string phoneNumber,double totalAmount, double paidAmount,
            double remaingAmount, DateTime transactionDate, string detailPaid)
        {


            TransactionId = transactionId;
            OrderId = orderId;
            

            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemaingAmount = remaingAmount;

            FirstName = firstName;
            LastName = lastName;
            Identity = identity;
            PhoneNumber = phoneNumber;

            TransactionDate = transactionDate;
            DetailsPaid = detailPaid;
        }

    }

    public class ClsTransactionDataAccessLayer
    {
        static string connStr = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";

        public static int AddNewTransaction(TransactionDTO dto)
        {
            int TransactionId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "DECLARE @return_value int" +
                        " EXEC @return_value = [dbo].[sp_AddNewTransaction] @OrderId = @OrderId," +
                        "@PaidAmount = @PaidAmount, @DetailsPaid = @DetailsPaid " +
                        "SELECT 'Return Value' = @return_value";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@OrderId", dto.OrderId);
                        command.Parameters.AddWithValue("@PaidAmount", dto.PaidAmount);

                        if (string.IsNullOrEmpty(dto.DetailsPaid))
                        {
                            command.Parameters.AddWithValue("@DetailsPaid", DBNull.Value);

                        }
                        else
                        {   

                            command.Parameters.AddWithValue("@DetailsPaid", dto.DetailsPaid);
                        }

               
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            TransactionId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return TransactionId;

        }

        public static List<TransationListDto> GetAllTransaction()
        {

            List<TransationListDto> list = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetAllTransaction] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            list = new List<TransationListDto>();
                        }

                        while (reader.Read())
                        {
                        
                            list.Add(
                                new TransationListDto(Convert.ToInt32(reader["TransactionId"]),
                                                   Convert.ToInt32(reader["OrderId"]),
                                                   reader["FirstName"].ToString(),
                                                   reader["LastName"].ToString(),
                                                   reader["N.o"].ToString(),
                                                   reader["PhoneNumber"].ToString(),
                                                   Convert.ToDouble(reader["TotalAmount"]),
                                                   Convert.ToDouble(reader["paidAmount"]),
                                                   Convert.ToDouble(reader["RemaingAmount"]),
                                                   Convert.ToDateTime(reader["Date"]),
                                                   reader["DetailsPaid"].ToString()));

                        }



                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return list;
        }


    }


}
