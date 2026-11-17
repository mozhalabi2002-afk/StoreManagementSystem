using StoreProject.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject.Products
{
    public partial class FrmReceipt : Form
    {
        ClsBasket basket1 = new ClsBasket();

        public delegate void CancelOrCompleteOrderDelegate();
        public CancelOrCompleteOrderDelegate CancelOrCompleteOrder;

        public Action<int>ReturnOrderId;


        int OrderId = 0;
        public FrmReceipt(ClsBasket basket)
        {
            InitializeComponent();
            basket1 = basket;
        }

        private void CallCancelOrCompleteOrderDelegate()
        {
            if (CancelOrCompleteOrder != null)
            {
                CancelOrCompleteOrder.Invoke();
            }
        }

        private void CallReturnOrderId()
        {
            if (ReturnOrderId != null)
                ReturnOrderId.Invoke(OrderId);
        }
        private async Task ShowProducts()
        {

            flowLayoutPanel1.Controls.Clear();

            ShortOrderDto order = await ProductApi.PayProducts(ClsCustomerGlobal.Customer.CustomerId);

            if (basket1.Basket == null)
                return;

            LabTotalAmount.Text = order.TotalAmount.ToString();

            OrderId = order.OrderId;
            CallReturnOrderId();
            foreach (var Product in basket1.Basket)
            {

                Item item = new Item();
                item.Width = 550;
                item.Height = 80;
                item.Margin = new Padding(15, 15, 25, 10);
                item.LoadItem(Product);
                flowLayoutPanel1.Controls.Add(item);
            }

        }
        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            if(basket1.Basket.Count == 0)
            {
                MessageBox.Show("Basket is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            ShowProducts();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void BtnCanecl_Click(object sender, EventArgs e)
        {
            bool IsSucees = await ProductApi.CancelOrder(OrderId);
            if (IsSucees)
            {
                MessageBox.Show("Cancel Order", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CallCancelOrCompleteOrderDelegate();
                this.Close();
            }
            else
            {
                MessageBox.Show("Cancel Order is fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private TransactionDTO FillIReceipt()
        {
            TransactionDTO transaction = new TransactionDTO();

            transaction.OrderId = OrderId;

            if (!string.IsNullOrEmpty(TBPaidAmount.Text))
                transaction.PaidAmount = Convert.ToDouble(TBPaidAmount.Text);

            transaction.DetailsPaid = TBDetailPaid.Text;

            return transaction;
        }

        private async void BtnPay_Click(object sender, EventArgs e)
        {


            bool IsSucees = await TransactionApi.AddNewTransactio(FillIReceipt());
            
            if (IsSucees)
            {
                MessageBox.Show("Complete Order", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CallCancelOrCompleteOrderDelegate();
                this.Close();
            }
            else
            {
                MessageBox.Show("Complete Order is fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TBPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }


    }
}

