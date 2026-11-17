using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DataAccessLayer
{
    public class OrderDto
    {

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public double TotalAmount { get; set; }

        public OrderDto()
        {

        }
        public OrderDto(int orderId, int? customerId, DateTime orderDate, int orderStatus, double totalAmount)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            TotalAmount = totalAmount;
        }
    }

    public class ShortOrderDto
    {
        public int OrderId { get; set; }

        public double TotalAmount { get; set; }

        public ShortOrderDto()
        {

        }
        public ShortOrderDto(int orderId, double totalAmount)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
        }
    }

    public class PrductOrderDto
    {
        public int ProductId { get; set; } 
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public double TotalWeight { get; set; }

        public double TotalAmount { get; set; }

        public PrductOrderDto() { }

        public PrductOrderDto(int ProductId,int OrderId,int Quantity,double TotalWeight)
        {
            this.ProductId = ProductId;
            this.OrderId = OrderId;
            this.Quantity = Quantity;
            this.TotalWeight = TotalWeight;
        }

    }

    public class ClsOrderDataAccessLayer
    {
        static string connStr = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";

        public static int AddNewOrder(int? CustomerId)
        {
            int OrderId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = " DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_AddNewOrder] @CustomerId=@CustomerId " +
                        "SELECT 'Return Value' = @return_value";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        if (CustomerId ==null)
                        {
                            command.Parameters.AddWithValue("@CustomerId", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@CustomerId", CustomerId);

                        }


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            OrderId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return OrderId;

        }

        public static int AddPrductOrder(PrductOrderDto dto)
        {
            int OrderId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "DECLARE @return_value int" +
                        " EXEC @return_value = [dbo].[sp_AddNewProductOrder] @OrderId = @OrderId," +
                        "@ProuductId = @ProuductId, @Qualtity = @Qualtity, @Weight = @Weight " +
                        "SELECT 'Return Value' = @return_value";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@OrderId", dto.OrderId);
                        command.Parameters.AddWithValue("@ProuductId", dto.ProductId);
                        command.Parameters.AddWithValue("@Qualtity", dto.Quantity);
                        command.Parameters.AddWithValue("@Weight", dto.TotalWeight);



                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            OrderId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return OrderId;

        }

        //public static bool DeleteOrder(int OrderId)
        //{

        //    int RowEfficted = 0;

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connStr))
        //        {
        //            connection.Open();

        //            string quary = "EXEC [dbo].[sp_DeleteOrder] @OrderId=@OrderId; ";

        //            using (SqlCommand command = new SqlCommand(quary, connection))
        //            {

        //                command.Parameters.AddWithValue("@OrderId", OrderId);
        //                RowEfficted = command.ExecuteNonQuery();


        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

        //    }

        //    return RowEfficted > 0;
        //}

        public static OrderDto  FindOrderById(int OrderId)
        {

            OrderDto order = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindOrder] @OrderId=@OrderId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@OrderId", OrderId);


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                           order = new OrderDto();

                            order.OrderStatus = Convert.ToInt32(reader["OrderStatus"]);

                            order.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);

                            order.CustomerId = Convert.ToInt32(reader["CustomerId"]);


                        }


                    }
                }
            }

            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return order;
        }

        //public static bool IsExitOrdertById(int OrderId)
        //{

        //    bool IsFound = false;

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connStr))
        //        {
        //            connection.Open();

        //            string quary = "EXEC [dbo].[sp_IsOrderExist] @OrderId=@OrderId ";

        //            using (SqlCommand command = new SqlCommand(quary, connection))
        //            {

        //                command.Parameters.AddWithValue("@OrderId", OrderId);

        //                SqlDataReader reader = command.ExecuteReader();

        //                if (reader.HasRows)
        //                {

        //                    IsFound = true;

        //                }



        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

        //    }

        //    return IsFound;
        //}

        //public static DataTable GetAllOrders()
        //{

        //    DataTable table = new DataTable();

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connStr))
        //        {
        //            connection.Open();

        //            string quary = "EXEC [dbo].[sp_GetAllOrders] ";

        //            using (SqlCommand command = new SqlCommand(quary, connection))
        //            {


        //                SqlDataReader reader = command.ExecuteReader();

        //                if (reader.HasRows)
        //                {
        //                    table.Load(reader);

        //                }
        //                else
        //                {
        //                    table = null;
        //                }


        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

        //    }

        //    return table;
        //}


        public static bool UpdateOrder(OrderDto order)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_UpdateOrder] " +
                        "@OrderId =@OrderId , @TotalAmount = @TotalAmount,@OrderStatus=@OrderStatus";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@OrderId", order.OrderId);
                        command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        command.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                  

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

        public static bool UpdateProductOrder(PrductOrderDto dto)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_UpdateProductOrder] " +
                        "@OrderId =@OrderId,@ProuductId=@ProuductId,@Qualtity=@Qualtity,@Weight=@Weight";
                        

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@OrderId", dto.OrderId);
                        command.Parameters.AddWithValue("@ProuductId", dto.ProductId);
                        command.Parameters.AddWithValue("@Qualtity", dto.Quantity);
                        command.Parameters.AddWithValue("@Weight", dto.TotalWeight);


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

        public static bool UpdateOrderStatus(int OrderId,int OrderStatus)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_UpdateOrderStatus] " +
                        "@OrderId =@OrderId ,@OrderStatus=@OrderStatus";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@OrderId", OrderId);
                        command.Parameters.AddWithValue("@OrderStatus", OrderStatus);


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


    }

}

