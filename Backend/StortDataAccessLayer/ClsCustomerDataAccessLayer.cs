using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DataAccessLayer
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public PeopleDto person { get; set; }

        public string Password { get; set; }
        public int PersonId { get; set; }
        
        public CustomerDTO() {

            person = new PeopleDto();

        }

        public CustomerDTO(int CustomerId,string CustomerName,string Password,int PersonId)
        {

            this.CustomerId = CustomerId;
            this.CustomerName = CustomerName;
            this.Password = Password;
            this.PersonId = PersonId;


        }

    }
    public class ClsCustomersDataAccessLayer
    {
        static string connStr = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";

        public static int AddNewCustomer(CustomerDTO cutomer)
        {
            int CustomerId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = " DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_AddNewCustomer] @PersonId=@PersonId, @CustomerName=@CustomerName, @Password=@Password " +
                        "SELECT 'Return Value' = @return_value";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        command.Parameters.AddWithValue("@PersonId",cutomer.PersonId);
                        command.Parameters.AddWithValue("@CustomerName", cutomer.CustomerName);
                        command.Parameters.AddWithValue("@Password", cutomer.Password);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            CustomerId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return CustomerId;

        }

        public static bool UpdateCustomer(CustomerDTO cutomer)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_UpdateCustomer] @CustomerId=@CustomerId, @PersonId=@PersonId ,@CustomerName=@CustomerName, @Password=@Password";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@CustomerId", cutomer.CustomerId);
                        command.Parameters.AddWithValue("@PersonId", cutomer.PersonId);
                        command.Parameters.AddWithValue("@CustomerName", cutomer.CustomerName);
                        command.Parameters.AddWithValue("@Password", cutomer.Password);

                        RowEfficted = command.ExecuteNonQuery();


                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return RowEfficted > 0;
        }

        public static bool DeleteCustomer(int CustomerId)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_DeleteCustomer] @CustomerId=@CustomerId; ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        RowEfficted = command.ExecuteNonQuery();


                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return RowEfficted > 0;
        }

        public static CustomerDTO FindCustomerById(int CustomerId)
        {
            CustomerDTO customer = null;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindCustomer] @CustomerId=@CustomerId ";

                    customer = new CustomerDTO();

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                       

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                            customer.PersonId = Convert.ToInt32(reader["PersonId"]);
                            customer.CustomerName = reader["CustomerName"].ToString();
                            customer.Password = reader["Password"].ToString();

                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return customer;
        }

        public static CustomerDTO FindCustomerByUserNameAndPassword( string CustomerName, string Password)
        {

            CustomerDTO customer = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindCustomerByUserNameAndPassword] @UserName=@CustomerName,@Password=@Password ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerName", CustomerName);
                        command.Parameters.AddWithValue("@Password", Password);


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            customer = new CustomerDTO();

                            customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                            customer.PersonId = Convert.ToInt32(reader["PersonId"]);
                            customer.CustomerName = reader["CustomerName"].ToString();
                            customer.Password = reader["Password"].ToString();

                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return customer;
        }

        public static bool IsExitCustomerById(int CustomerId)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_IsExistCustomer] @CustomerId=@CustomerId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@CustomerId", CustomerId);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {

                            IsFound = true;

                        }



                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return IsFound;
        }

        public static List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> customers = null; 

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    customers=new List<CustomerDTO>();

                    string quary = "EXEC [dbo].[sp_GetAllCustomers] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            customers.Add(new CustomerDTO(Convert.ToInt32(reader["CustomerId"]),
                                reader["CustomerName"].ToString(), reader["Password"].ToString(), Convert.ToInt32(reader["PersonId"])));
                        }
                        

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return customers;
        }


    }
}
