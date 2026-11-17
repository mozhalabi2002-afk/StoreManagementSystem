using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuisnessLayer
{
    public partial class ClsProduct
    {
        public enum eMode { eAddNew = 1, eUpdate = 2 }
        public eMode _Mode = eMode.eAddNew;

        public enum eSaleType { eSaleByQuantity = 1, eSaleByWeight }
        public eSaleType SaleType = eSaleType.eSaleByQuantity;

        public static List<ClsProduct> Clients=new List<ClsProduct>();
        public static List<short> ClientNumbers = new List<short>();

        public int ProductId { get; set; }

        public ProductDTO product { get {
                return new ProductDTO(ProductId, CategoryName, ProductName, Quantity
            , Price, Image, Weight, Size, Parcode, (int)SaleType);
            } }
        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        private int _Quantity = 1;
        public int Quantity
        {
            get { return _Quantity; }
            set { if (value < 1) value = 1; _Quantity = value; }
        }

        public double Price { get; set; }

        public string Image { get; set; }

        public double Weight { get; set; }
        public double Size { get; set; }

        public string Parcode { get; set; }

      

        
        public static ShortOrderDto BuyProducts(int? CustomerId,int BookingId) 
        {
            ClsProduct product= IsClientExist(BookingId);

            int OrderId = 0;

            if (product.OrderId < 1)
            {
                OrderId = ClsOrder.AddNewOrder(CustomerId);
            }
            else
            {
                OrderId = product.OrderId;
            }

            return product.CalculateReceipe(OrderId);

        }

        public ClsProduct(ProductDTO product,eMode Mode=eMode.eAddNew)
        {

            _Mode = Mode;
            ProductId = product.ProductId;
            CategoryName = product.CategoryName;
            ProductName = product.ProductName;
            this.SaleType = (eSaleType)product.SaleType;
            Quantity = product.Quantity;
            Price = product.Price;
            Image = product.Image;
            Weight = product.Weight;
            Size = product.Size;
            Parcode = product.Parcode;
      
        }

        private bool _AddNewProduct()
        {
            ProductId = ClsProductsDataAccess.AddNewProduct(product);

            return ProductId != -1;
        }

        private bool _UpdateProduct()
        {

            return ClsProductsDataAccess.UpdateProduct(product);

        }

        public static bool DeleteProduct(int ProductId)
        {
            return ClsProductsDataAccess.DeleteProduct(ProductId);
        }

        public static void CancelOrder(int OrderId)
        {
            int Counter = 0;
            bool IsFound = false;

            foreach(var Order in Clients)
            {
                if (Order.OrderId == OrderId) { IsFound = true; break; }
                Counter++;

            }

            if (IsFound)
            {
                Clients[Counter].CancelOrder();

                Clients.RemoveAt(Counter);
            }



        }

        public static void CompleteOrder(int OrderId)
        {
            foreach (var Product in Clients)
            {
                if (Product.OrderId == OrderId)
                {
                    Product.IsOrderComplete = true;
                    Clients.Remove(Product);
                    return;
                }

            }
        }

        private static bool BookingProductInDataBase(ProductBookingDTO product)
        {
            return ClsProductsDataAccess.BookingProduct(product);

        }

        private static bool UpdateBookingInDataBase(ProductBookingDTO product)
        {
            return ClsProductsDataAccess.UpdateBookingProduct(product);
        }

        private static bool RemoveBookingFromDataBase(ProductBookingDTO product)
        {
            return ClsProductsDataAccess.ReturnProduct(product);
        }
    
        static ClsProduct  IsClientExist(int BookingId)
        {
            foreach(var i in Clients)
            {
                if (i.BookingId == BookingId)
                    return i;
            }

            ClsProduct product = new ClsProduct(BookingId);
            Clients.Add(product);

            return product;
        }

        public static bool BookingProduct(ProductBookingDTO dto,int ClientId)
        {
            bool IsSuccess= BookingProductInDataBase(dto);
           
            if(IsSuccess)
            {
                ClsProduct product = IsClientExist(ClientId);
               
                product.AddToBasket(dto);
                
                return true;


            }
            else
            {
                return false;
            }
        }

        public static bool UpdateBookingProduct(ProductBookingDTO dto, int ClientId)
        {

            bool IsSuccess= UpdateBookingInDataBase(dto);

            if (!IsSuccess)
            {
                return false;
            }

            ClsProduct product = IsClientExist(ClientId);
            
            product.UpdateBasket(dto);

            return true;
        }

        public static bool ReturnBooking(ProductBookingDTO dto, int ClientId)
        {
            bool IsSuccess=RemoveBookingFromDataBase(dto);

            if (IsSuccess)
            {
                ClsProduct product = IsClientExist(ClientId);
                product.RemoveFromBasket(dto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<ProductDTO> GetAllProducts()
        {
            return ClsProductsDataAccess.GetAllProducts();
        }

        public static List<ProductDTO> GetProductsByCateoryName(string CategoryName)
        {
            return ClsProductsDataAccess.GetProductsByCateoryName(CategoryName);
        }
        public static ClsProduct FindProduct(int ProductId)
        {
            int identity = 0, saleType = 0;
            string categoryName = "", productName = "", image = "", parCode = "";
            double price = 0, wight = 0, size = 0;

            ProductDTO product = ClsProductsDataAccess.FindPrductById(ProductId);


            if (product!=null)
            {

                return new ClsProduct(product,eMode.eUpdate);
            }
            else
            {
                return null;
            }
        }

        public static bool IsProductExist(int ProductId)
        {
            return ClsProductsDataAccess.IsExitProductById(ProductId);
        }

        public bool Save()
        {
            if (_Mode == eMode.eAddNew)
            {
                if (_AddNewProduct())
                {
                    _Mode = eMode.eUpdate;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return _UpdateProduct();
            }
        }



    }

    public partial class ClsProduct
    {
        private short Timer3 = 0;

         public bool IsOrderComplete { get; set; }
        private int OrderId { get; set; }
        public int BookingId { get; set; }

        private List<bool> IsItemOrdered = new List<bool>();

        public ClsProduct(int BookingId)
        {
            this.BookingId = BookingId;
            IsTimerActive = true;

            Thread thread = new Thread(() => ActivateTimer());
            thread.Start();

        }

        public bool IsTimerActive = false;

        private List<ProductBookingDTO> _Basket = new List<ProductBookingDTO>();

        private List<int> CounterPerItem = new List<int>();

        private async Task ActivateTimer()
        {
            while (IsTimerActive)
            {

                foreach (var item in _Basket)
                {
                    ActivateTimer(item);
                }

                await Task.Delay(30000);

                if (_Basket.Count == 0)
                {
                    IsTimerActive = false;
                    return;
                }
            }

        }

        private async void ActivateTimer(ProductBookingDTO Item)
        {

            int Number = _Basket.IndexOf(Item);
            CounterPerItem[Number]++;
            if (CounterPerItem[Number] == 60)
            {
                ReturnBooking(Item, BookingId);
            }
        }

        private void RemoveEmptyItem()
        {
            int Counter = 0;

            List<int> Numbers = new List<int>();

            foreach (var product in _Basket)
            {
                if ((product.Quantity <= 0 && product.SaleType == ProductBookingDTO.eSaleType1.eSaleByQuantity)
                       || (product.Weight <= 0 && product.SaleType == ProductBookingDTO.eSaleType1.eSaleByWeight))
                {
                    int Index = _Basket.IndexOf(product);
                    Numbers.Add(Index);
                    IsItemOrdered.RemoveAt(Counter);

                }
                Counter++;
            }

            foreach (var item in Numbers)
            {
                _Basket.RemoveAt(item);
                CounterPerItem.RemoveAt(item);

            }

        }
        private void UpdateBasket(ProductBookingDTO Item)
        {
            int Counter = 0;

            foreach (var product in _Basket)
            {

                if (product.ProductId == Item.ProductId)
                {
                    product.Quantity += Item.Quantity;
                    product.Weight += Item.Weight;
                    product.Quantity -= Item.OldQuantity;
                    product.Weight -= Item.OldWeight;

                    if (IsItemOrdered[Counter])
                    {
                        ClsOrder.UpdateProductOrder(new PrductOrderDto(product.ProductId, OrderId, product.Quantity, product.Weight));
                    }

                    RemoveEmptyItem();
                    return;
                }

                Counter++;
            }

        }

        public void AddToBasket(ProductBookingDTO Item)
        {
            int Counter = 0;

            foreach (var product in _Basket)
            {

                if (product.ProductId == Item.ProductId)
                {
                    product.Quantity += Item.Quantity;
                    product.Weight += Item.Weight;
                    if (IsItemOrdered[Counter])
                    {
                        ClsOrder.UpdateProductOrder(new PrductOrderDto(product.ProductId, OrderId, product.Quantity, product.Weight));
                    }

                    return;
                }

                Counter++;
            }

            _Basket.Add(Item);
            CounterPerItem.Add(0);
            IsItemOrdered.Add(false);
        }

        private void RemoveFromBasket(ProductBookingDTO Item)
        {
            int Count = 0;
            foreach (var product in _Basket)
            {

                if (product.ProductId == Item.ProductId)
                {
                    product.Quantity -= Item.Quantity;
                    product.Weight -= Item.Weight;

                    if (IsItemOrdered[Count])
                    {
                        ClsOrder.UpdateProductOrder(new PrductOrderDto(product.ProductId, OrderId, product.Quantity, product.Weight));
                    }
                }
                Count++;
            }
            RemoveEmptyItem();
        }

        private void CancelOrder()
        {
            foreach (var product in _Basket)
            {
                if (!RemoveBookingFromDataBase(product))
                    return;
            }

            _Basket.Clear();

        }

        private ShortOrderDto CalculateReceipe(int OrderId)
        {
            if (_Basket.Count == 0)
            { 
                if (OrderId > 0)
                {
                    return new ShortOrderDto(OrderId, 0);
                }
                    
                return null; 
            }

            this.OrderId = OrderId;
            double TotalAmount = 0;
            int Count = 0;

            foreach (var Item in _Basket)
            {
                if (!IsItemOrdered[Count])

                    ClsOrder.AddNewProductOrder(new PrductOrderDto(Item.ProductId,
                         OrderId, Item.Quantity, Item.Weight));

                IsItemOrdered[Count] = true;
                Count++;
            }

            TotalAmount = ClsOrder.FindOrderByOrderId(OrderId).totalAmount;

            return new ShortOrderDto(OrderId, TotalAmount);
        }


        ~ClsProduct()
        {
            if(!IsOrderComplete)
            {
                CancelOrder();
            }
        }

    }

}
