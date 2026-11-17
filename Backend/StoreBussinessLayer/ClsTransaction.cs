using BuisnessLayer;
using DataAccessLayer;
using StortDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBussinessLayer
{
    public class ClsTransaction
    {
        public int TransactionId { get; set; }

        public int OrderId { get; set; }

        public int? CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public TransactionDTO TransactionDTO { get { return new TransactionDTO(TransactionId, OrderId,
            CustomerId, TotalAmount, PaidAmount, RemaingAmount, TransactionDate, DetailsPaid); } }
        public double RemaingAmount { get; set; }   
        public DateTime TransactionDate { get; set; }
        public string DetailsPaid { get; set; }

        public static bool AddNewTransaction(TransactionDTO dto)
        {
            dto.TransactionId= ClsTransactionDataAccessLayer.AddNewTransaction(dto);

            if (dto.TransactionId <= 0)
                return false;



            ClsProduct.CompleteOrder(dto.OrderId);


            return true;

        }

        public static List<TransationListDto> GetAllTransationList()
        {
            return ClsTransactionDataAccessLayer.GetAllTransaction();
        }


    }
}
