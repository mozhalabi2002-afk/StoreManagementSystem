using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{

    public class ClsOrder
    {
        public enum eMode { AddNew = 1, Update = 2 }
        public eMode Mode = eMode.AddNew;
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public ClsCustomers Customer { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderDto order { get { return new OrderDto(OrderId, CustomerId, OrderDate, OrderStatus, totalAmount); } }
        public int OrderStatus { get; set; }
        public double totalAmount { get; set; }


        public ClsOrder()
        {
            OrderId = -1;
            CustomerId = 0;
            OrderStatus = 0;
            totalAmount = 0;
        }
        private ClsOrder(OrderDto order)
        {
            
            OrderId = order.OrderId;
            CustomerId = order.CustomerId ?? 0;
            Customer = ClsCustomers.FindCustomer(CustomerId);
            OrderStatus = order.OrderStatus;
            totalAmount = order.TotalAmount;
      
        }

        public static int AddNewOrder(int? CustomerId)
        {
            return ClsOrderDataAccessLayer.AddNewOrder(CustomerId);
        }

        public static int AddNewProductOrder(PrductOrderDto dto)
        {
            return ClsOrderDataAccessLayer.AddPrductOrder(dto);
        }
        public static bool UpdateOrder(OrderDto order)
        {
            return ClsOrderDataAccessLayer.UpdateOrder(order);
        }

        public static bool CancelOrder(int OrderId)
        {
            ClsProduct.CancelOrder(OrderId);

            return ClsOrderDataAccessLayer.UpdateOrderStatus(OrderId, 2);
        }

        public static bool CompleteOrder(int OrderId)
        {
            ClsProduct.CompleteOrder(OrderId);
            return ClsOrderDataAccessLayer.UpdateOrderStatus(OrderId, 3);
        }

        public static bool UpdateProductOrder(PrductOrderDto dto)
        {
            return ClsOrderDataAccessLayer.UpdateProductOrder(dto);
        }

        //public static bool DeleteOrder(int orderId)
        //{
        //    return ClsOrderDataAccessLayer.DeleteOrder(orderId);
        //}

        public static ClsOrder FindOrderByOrderId(int OrderId)
        {
            int CustomerId = -1;
            int orderStatus = 0;

            OrderDto order = ClsOrderDataAccessLayer.FindOrderById(OrderId);
            if (order!=null)
            {
                return new ClsOrder(order);
            }
            else
            {
                return null;
            }
        }

        //public static bool IsOrderExist(int OrderId)
        //{
        //    return ClsOrderDataAccessLayer.IsExitOrdertById(OrderId);
        //}

        //public static DataTable GetAllOrders()
        //{
        //    return ClsOrderDataAccessLayer.GetAllOrders();
        //}

    }

}