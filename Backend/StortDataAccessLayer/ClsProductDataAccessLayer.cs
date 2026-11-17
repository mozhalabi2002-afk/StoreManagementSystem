using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DataAccessLayer
{
    public class ProductDTO
    {
        public enum eSaleType { eSaleByQuantity = 1, eSaleByWeight=2 }

        public eSaleType SaleType { get; set; } = eSaleType.eSaleByQuantity;

        public int ProductId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        private int _Quantity = 1;
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value < 1 ? 1 : value; }
        }

        public double Price { get; set; }

        public string Image { get; set; }

        public double Weight { get; set; }

        public double Size { get; set; }

        public string Parcode { get; set; }
        public ProductDTO()
        {
        }
        public ProductDTO(int productId, string categoryName, string productName, int quantity,
            double price, string image, double weight, double size, string parcode, int saleType)
        {
            ProductId = productId;
            CategoryName = categoryName;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Image = image;
            Weight = weight;
            Size = size;
            Parcode = parcode;
            SaleType = (eSaleType)saleType;
        }
    }
    public class ProductBookingDTO
    {
        public enum eSaleType1 { eSaleByQuantity = 1, eSaleByWeight = 2 }

        public eSaleType1 SaleType { get; set; } 
        
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }
        public int OldQuantity { get; set; }

        public double OldWeight { get; set; }

        public ProductBookingDTO(int productId, int quantity, double weight, int oldQuantity,
            double oldWeight, eSaleType1 SaleType)
        {
            ProductId = productId;
            Quantity = quantity;
            Weight = weight;
            OldQuantity = oldQuantity;
            OldWeight = oldWeight;
            this.SaleType = SaleType;
        }

        public ProductBookingDTO() { }

    }

    public class ClsProductsDataAccess
    {


        static string connStr = "Server=localhost;Database=DBStore;User Id=sa;Password=123456; Encrypt=True;TrustServerCertificate=True;";

        public static int AddNewProduct(ProductDTO product)
        {
            int ProductId = -1;


            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = " DECLARE @return_value int " +
                        "EXEC @return_value = [dbo].[sp_AddNewProduct] @CategoryName=@CategoryName,@Name=@Name,@SaleType=@SaleType,@Identity=@Identity,@Price=@Price, " +
                        "@Image=@Image,@Wight=@Wight,@Size=@Size,@Parcode=@Parcode " +
                        "SELECT 'Return Value' = @return_value";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@CategoryName",product.CategoryName);
                        command.Parameters.AddWithValue("@Name", product.ProductName);
                        command.Parameters.AddWithValue("@SaleType", product.SaleType);
                        command.Parameters.AddWithValue("@Identity", product.Quantity);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Image", product.Image);

                        if (product.Weight == 0)
                        {
                            command.Parameters.AddWithValue("@Wight", System.DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Wight", product.Weight);
                        }

                        if (product.Size == 0)
                        {
                            command.Parameters.AddWithValue("@Size", System.DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Size", product.Size);

                        }

                        if (string.IsNullOrEmpty(product.Parcode))
                        {
                            command.Parameters.AddWithValue("@Parcode", System.DBNull.Value);

                        }
                        else
                        {

                            command.Parameters.AddWithValue("@Parcode", product.Parcode);
                        }




                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            ProductId = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return ProductId;

        }

        public static bool UpdateProduct(ProductDTO product)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_UpdateProduct] @ProductId=@ProductId ," +
                        " @CategoryName=@CategoryName, " +
                        "@Name=@Name,@SaleType=@SaleType,@Identity=@Identity,@Price=@Price, @Image=@Image,@Wight=@Wight,@Size=@Size, " +
                        "@Parcode=@Parcode";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@ProductId", product.ProductId);
                        command.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                        command.Parameters.AddWithValue("@Name", product.ProductName);
                        command.Parameters.AddWithValue("@SaleType", product.SaleType);
                        command.Parameters.AddWithValue("@Identity", product.Quantity);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Image", product.Image);

                        if (product.Weight == 0)
                        {
                            command.Parameters.AddWithValue("@Wight", System.DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Wight", product.Weight);
                        }

                        if (product.Size == 0)
                        {
                            command.Parameters.AddWithValue("@Size", System.DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Size", product.Size);

                        }

                        if (string.IsNullOrEmpty(product.Parcode))
                        {
                            command.Parameters.AddWithValue("@Parcode", System.DBNull.Value);

                        }
                        else
                        {

                            command.Parameters.AddWithValue("@Parcode", product.Parcode);
                        }

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

        public static bool BookingProduct(ProductBookingDTO product)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "DECLARE	@return_value int,@RetrunValue int" +
                        " EXEC  @return_value = [dbo].[sp_BookingProductId]   @ProductId = @ProductId," +
                        "	@Quantity = @Quantity,@Weight =@Wight," +
                        "@RetrunValue = @RetrunValue OUTPUT " +
                        " SELECT @RetrunValue as N'@RetrunValue'";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@ProductId", product.ProductId);


                        if (product.Quantity == 0)
                        {
                            command.Parameters.AddWithValue("@Quantity", System.DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        }

                        command.Parameters.AddWithValue("@Wight", product.Weight);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            RowEfficted = ID;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return RowEfficted > 0;
        }

        public static bool UpdateBookingProduct(ProductBookingDTO product)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_UpdateBookingProductId] @ProductId=@ProductId,@OldQuantity=@OldQuantity ," +
                        "@Quantity=@Quantity,@OldWeight=@OldWeight,@Weight=@Wight";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@ProductId", product.ProductId);


                        if (product.Quantity == 0)
                        {
                            command.Parameters.AddWithValue("@Quantity", System.DBNull.Value);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        }

                        command.Parameters.AddWithValue("@Wight", product.Weight);
                        command.Parameters.AddWithValue("@OldQuantity", product.OldQuantity);
                        command.Parameters.AddWithValue("@OldWeight", product.OldWeight);

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

        public static bool DeleteProduct(int ProductId)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_DeleteProduct] @ProductId=@ProductId; ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@ProductId", ProductId);
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

        public static ProductDTO FindPrductById(int ProductId)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_FindProduct] @ProductId=@ProductId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@ProductId", @ProductId);


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            return new ProductDTO(ProductId, (reader["CategoryName"]).ToString(),
                                                   reader["Name"].ToString(),
                                                   Convert.ToInt32(reader["IdentityOfProduct"]),
                                                   Convert.ToDouble((reader["Price"])),
                                                   reader["Image"].ToString(),
                                                   string.IsNullOrEmpty(reader["Wight"].ToString()) ? 0 : Convert.ToDouble((reader["Wight"])),
                                                   string.IsNullOrEmpty(reader["Size"].ToString()) ? 0 : Convert.ToDouble((reader["Size"])),
                                                   (reader["Parcode"]) == null ? " " : reader["Parcode"].ToString(),
                                                   Convert.ToInt32(reader["SaleType"]));

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

        public static bool IsExitProductById(int ProductId)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_IsProductExist] @ProductId=@ProductId ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {

                        command.Parameters.AddWithValue("@ProductId", ProductId);

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

        public static List<ProductDTO> GetAllProducts()
        {

            List<ProductDTO> products= new List<ProductDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetAllProducts] ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            products.Add(
                                new ProductDTO(Convert.ToInt32(reader["ProductId"]),(reader["CategoryName"]).ToString(),
                                                   reader["Name"].ToString(),
                                                   Convert.ToInt32(reader["IdentityOfProduct"]),
                                                   Convert.ToDouble((reader["Price"])),
                                                   reader["Image"].ToString(),
                                                   string.IsNullOrEmpty(reader["Wight"].ToString()) ? 0 : Convert.ToDouble((reader["Wight"])),
                                                   string.IsNullOrEmpty(reader["Size"].ToString()) ? 0 : Convert.ToDouble((reader["Size"])),
                                                   (reader["Parcode"]) == null ? " " : reader["Parcode"].ToString(),
                                                   Convert.ToInt32(reader["SaleType"]))

                                );
                        }
                        


                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return products;
        }

        public static List<ProductDTO> GetProductsByCateoryName(string CategoryName)
        {

            List<ProductDTO> products = new List<ProductDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_GetProductByCategory] @CategoryName=@CategoryName ";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            products.Add(
                                new ProductDTO(Convert.ToInt32(reader["ProductId"]), (reader["CategoryName"]).ToString(),
                                                   reader["Name"].ToString(),
                                                   Convert.ToInt32(reader["IdentityOfProduct"]),
                                                   Convert.ToDouble((reader["Price"])),
                                                   reader["Image"].ToString(),
                                                   string.IsNullOrEmpty(reader["Wight"].ToString()) ? 0 : Convert.ToDouble((reader["Wight"])),
                                                   string.IsNullOrEmpty(reader["Size"].ToString()) ? 0 : Convert.ToDouble((reader["Size"])),
                                                   (reader["Parcode"]) == null ? " " : reader["Parcode"].ToString(),
                                                   Convert.ToInt32(reader["SaleType"]))

                                );
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ClsSettings.SourceName, $"Error : {ex.Message}", EventLogEntryType.Error);

            }

            return products;
        }

        public static bool ReturnProduct(ProductBookingDTO product)
        {

            int RowEfficted = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    string quary = "EXEC [dbo].[sp_ReturnItems] @ProductId=@ProductId," +
                        "@Quantity=@Quantity,@Weight=@Wight";

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {


                        command.Parameters.AddWithValue("@ProductId",product.ProductId);

                        if (product.Quantity == 0)
                        {
                            command.Parameters.AddWithValue("@Quantity", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Quantity",product.Quantity);
                        }

                        command.Parameters.AddWithValue("@Wight",product.Weight);




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
