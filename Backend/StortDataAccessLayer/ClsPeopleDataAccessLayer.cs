using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Xml.Linq;
using System.Diagnostics;

namespace DataAccessLayer
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

        public PeopleDto(int PersonId,string FirstName,
            string SecondName,string LastName,int No,int PhoneNumber)
        {
            this.PersonId = PersonId;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.No = No;
            this.PhoneNumber = PhoneNumber;
        }


    }


    public class ClsPeopleDataAccessLayer
    {
        
        static string connStr = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";

        public static int AddNewPerson(PeopleDto person)
        {
            int PersonId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = " DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_AddNewPerson] @Firstname = @Firstname,@Secondname=@Secondname,@Lastname=@Lastname " +
                        ",@No=@No,@PhoneNumber=@PhoneNumber " +
                        "SELECT @return_value as N'@RetrunValue'";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@Firstname", person.FirstName);
                        command.Parameters.AddWithValue("@Secondname", person.SecondName);
                        command.Parameters.AddWithValue("@Lastname", person.LastName);
                        command.Parameters.AddWithValue("@No", person.No);
                        command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                        

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            PersonId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return PersonId;
        }

        public static bool UpdatePerson(PeopleDto Person)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_UpdatePerson] @PersonId=@PersonId, @Firstname = @Firstname,@Secondname=@Secondname,@Lastname=@Lastname " +
                        ",@No=@No,@PhoneNumber=@PhoneNumber";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@PersonId", Person.PersonId);
                        command.Parameters.AddWithValue("@Firstname", Person.FirstName);
                        command.Parameters.AddWithValue("@Secondname", Person.SecondName);
                        command.Parameters.AddWithValue("@Lastname", Person.LastName);
                        command.Parameters.AddWithValue("@No", Person.No);
                        command.Parameters.AddWithValue("@PhoneNumber", Person.PhoneNumber);
                        
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

        public static bool DeletePerson(int PersonId)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_DeletePerson] @PersonId=@PersonId; ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@PersonId", PersonId);
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

        public static PeopleDto FindPersonById(int PersonId)
        {

            PeopleDto dto = null;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindPerson] @PersonId=@PersonId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@PersonId", PersonId);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            dto = new PeopleDto();
                            dto.PersonId = PersonId;
                            dto.FirstName = reader["FirstName"].ToString();
                            dto.SecondName = reader["SecondName"].ToString();
                            dto.LastName = reader["LastName"].ToString();
                            dto.No = Convert.ToInt32(reader["N.o"]);
                            dto.PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]);
                            
                        }



                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return dto;
        }

        public static bool IsExitPersonById(int PersonId)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_IsExitPerson] @PersonId=@PersonId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@PersonId", PersonId);

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

        public static List<PeopleDto> GetAllPeople()
        {

            List<PeopleDto> list = null;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetAllPeople] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        SqlDataReader reader = command.ExecuteReader();

                        list = new List<PeopleDto>();
                        while (reader.Read())
                        {
                            list.Add(new PeopleDto (Convert.ToInt32(reader["personId"]), reader["FirstName"].ToString(),
                                reader["SecondName"].ToString(), reader["LastName"].ToString(), Convert.ToInt32(reader["N.o"]),
                                Convert.ToInt32(reader["PhoneNumber"])));
                        
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

        public static List<string> GetAllNo()
        {

            List<string> list = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetAllNo] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        list = new List<string>();

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(reader["N.o"].ToString());

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
