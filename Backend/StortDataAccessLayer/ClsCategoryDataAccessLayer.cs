using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DataAccessLayer
{
    public class CategoriesDTO{

        public int CategoryId {  get; set; }
        public string CategoryName {  get; set; }

        public CategoriesDTO() { }

        public CategoriesDTO(int CategoryId, string CategoryName)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
        }
    }
    public class ClsCategoryDataAccessLayer
    {
        static string connStr = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";

        public static List<CategoriesDTO> GetAllCategories()
        {

            List<CategoriesDTO> table = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetAllCategories] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        SqlDataReader reader = command.ExecuteReader();

                        table=new List<CategoriesDTO>();

                        while(reader.Read())
                        {
                            table.Add(new CategoriesDTO(Convert.ToInt32(reader["CategoryId"]), reader["CategoryName"].ToString()));
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return table;
        }

    }
}