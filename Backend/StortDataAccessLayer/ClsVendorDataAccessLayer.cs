using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DataAccessLayer
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
        public DTOVendor(int VendorId, int PersonId, string VendorName,string Password,string ShiftTimeStarted,
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



    public class ClsVendorDataAccessLayer
    {
         static  string connStrVendor = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";
    
        public static int AddNewVendor(DTOVendor vendor)
        {
            int VendorId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = " DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_AddNewVendor] @PersonId=@PersonId,@VendorName=@VendorName,@Password=@Password, " +
                        "@ShiftTimeStarted=@ShiftTimeStarted,@ShiftTimeFinshed=@ShiftTimeFinshed,@SalaryPerHour=@SalaryPerHour,@Permission=@Permission " +
                        "SELECT 'Return Value' = @return_value";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@PersonId", vendor.PersonId);
                        command.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                        command.Parameters.AddWithValue("@Password", vendor.Password);
                        command.Parameters.AddWithValue("@ShiftTimeStarted", vendor.ShiftTimeStarted);
                        command.Parameters.AddWithValue("@ShiftTimeFinshed", vendor.ShiftTimeFinshed);
                        command.Parameters.AddWithValue("@SalaryPerHour", vendor.SalaryPerHour);
                        command.Parameters.AddWithValue("@Permission", vendor.Permission);


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            VendorId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return VendorId;

        }

        public static bool UpdateVendor(DTOVendor vendor)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_UpdateVendor] @VendorId=@VendorId,  @PersonId=@PersonId,@VendorName=@VendorName,@Password=@Password, " +
                        "@ShiftTimeStarted=@ShiftTimeStarted,@ShiftTimeFinshed=@ShiftTimeFinshed,@SalaryPerHour=@SalaryPerHour,@Permission=@Permission";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@VendorId", vendor.VendorId);
                        command.Parameters.AddWithValue("@PersonId", vendor.PersonId);
                        command.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                        command.Parameters.AddWithValue("@Password", vendor.Password);
                        command.Parameters.AddWithValue("@ShiftTimeStarted",    vendor.ShiftTimeStarted);
                        command.Parameters.AddWithValue("@ShiftTimeFinshed", vendor.ShiftTimeFinshed);
                        command.Parameters.AddWithValue("@SalaryPerHour", vendor.SalaryPerHour);
                        command.Parameters.AddWithValue("@Permission",  vendor.Permission);

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

        public static bool DeleteVendor(int VendorId)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_DeleteVendor] @VendorId=@VendorId; ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@VendorId", VendorId);
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

        public static DTOVendor FindVendorById(int VendorId)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindVendor] @VendorId=@VendorId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@VendorId", VendorId);


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                          return new DTOVendor(
                              VendorId,
                            Convert.ToInt32(reader["PersonId"]),
                             reader["VendorName"].ToString(),
                             reader["Password"].ToString()
                             ,(reader["ShiftTimeStarted"]).ToString(),
                             (reader["ShiftTimeFinshed"]).ToString(),
                            Convert.ToDouble(reader["SalaryPerHour"]),
                             Convert.ToInt32(reader["Permission"])
                            );

                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return null;
        }

        public static DTOVendor FindVendorByVendorNameAndPassword(string VendorName,string Password)
        {

            
            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindVendorByUserNameAndPassword] @UserName=@VendorName,@Password=@Password ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@VendorName",VendorName);
                        command.Parameters.AddWithValue("@Password", Password);


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            return new DTOVendor(
                            Convert.ToInt32(reader["VendorId"]),
                             Convert.ToInt32(reader["PersonId"]),
                             VendorName,Password,
                             (reader["ShiftTimeStarted"]).ToString(),
                             (reader["ShiftTimeFinshed"].ToString()),
                             Convert.ToDouble(reader["SalaryPerHour"]),
                            Convert.ToInt32(reader["Permission"]));

                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return null;
        }


        public static bool IsExitVendorById(int VendorId)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_IsExistVendor] @VendorId=@VendorId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@VendorId", @VendorId);

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

        public static List<DTOVendor> GetAllVendors()
        {

            List<DTOVendor> Vendors = new List<DTOVendor>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connStrVendor))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetAllVendors] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Vendors.Add(new DTOVendor(

                                 Convert.ToInt32(reader["VendorId"]),
                            Convert.ToInt32(reader["PersonId"]),
                            (reader["VendorName"]).ToString(),
                            (reader["Password"]).ToString(),
                             (reader["ShiftTimeStarted"]).ToString(),
                             (reader["ShiftTimeFinshed"].ToString()),
                            Convert.ToDouble(reader["SalaryPerHour"]),
                                Convert.ToInt32(reader["Permission"])));

                        }
                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return Vendors;
        }
   
    
    }
}
