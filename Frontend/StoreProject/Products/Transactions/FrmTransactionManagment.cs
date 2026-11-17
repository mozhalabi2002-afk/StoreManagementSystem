using StoreProject.People;
using StoreProject.Vendors;
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
    public partial class FrmTransactionManagment : Form
    {
        DataTable TransationsTable = new DataTable();
        DataTable dtTranstions = new DataTable();
        public FrmTransactionManagment()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            FrmVendorHome frm = new FrmVendorHome();
            frm.Show();
            this.Close();
        }

        private void FormateDataGridView()
        {
            if (DGVTransactions.Rows.Count > 0)
            {

                DGVTransactions.Columns[0].HeaderText = "Transaction ID";
                DGVTransactions.Columns[0].Width = 100;


                DGVTransactions.Columns[1].HeaderText = "Order ID";
                DGVTransactions.Columns[1].Width = 100;


                DGVTransactions.Columns[2].HeaderText = "First Name";
                DGVTransactions.Columns[2].Width = 120;

                DGVTransactions.Columns[3].HeaderText = "Last Name";
                DGVTransactions.Columns[3].Width = 120;

                DGVTransactions.Columns[4].HeaderText = "Identity";
                DGVTransactions.Columns[4].Width = 100;
                
                DGVTransactions.Columns[5].HeaderText = "Phone Number";
                DGVTransactions.Columns[5].Width = 120;

                DGVTransactions.Columns[6].HeaderText = "Total Amount";
                DGVTransactions.Columns[6].Width = 100;
                
                DGVTransactions.Columns[7].HeaderText = "Paid Amount";
                DGVTransactions.Columns[7].Width = 100;

                DGVTransactions.Columns[8].HeaderText = "Remaining Amount";
                DGVTransactions.Columns[8].Width = 100;
                
                DGVTransactions.Columns[9].HeaderText = "Transaction Date";
                DGVTransactions.Columns[9].Width = 120;

                DGVTransactions.Columns[10].HeaderText = "Details Paid";
                DGVTransactions.Columns[10].Width = 120;

            }
        }


        public async Task FillDataTable()
        {
            List<TransationListDto> TransactionsList = await TransactionApi.GetAllTransation();

            TransationsTable.Rows.Clear();

            foreach (var item in TransactionsList)
            {
                TransationsTable.Rows.Add(

                    item.TransactionId,
                    item.OrderId,
                    item.FirstName,
                    item.LastName,
                    item.Identity,
                    item.PhoneNumber ,
                    item.TotalAmount,
                    item.RemaingAmount,
                    item.PaidAmount,
                    item.TransactionDate,
                    item.DetailsPaid
                    
                   
                );
            }

            dtTranstions = TransationsTable.DefaultView.ToTable(false, "TransactionId", "OrderId", "FirstName", "LastName", "No","PhoneNumber",
                "TotalAmount", "RemaingAmount", "PaidAmount", "TransactionDate", "DetailsPaid");
        }

        private void RefershDataGridView()
        {
            DGVTransactions.DataSource = null;
            DGVTransactions.DataSource = dtTranstions;
        }
        private async void RefershData()
        {

            await FillDataTable();
            RefershDataGridView();
            CBFilter.SelectedIndex = 0;
            LabRecord.Text = DGVTransactions.Rows.Count.ToString();
            FormateDataGridView();

        }
        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFilter.Text != "None")
            {
                TBFilter.Visible = true;
                TBFilter.Clear();
                TBFilter.Focus();
            }
            else
                TBFilter.Visible = false;


        }

        private void TBFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (CBFilter.Text)
            {
                case "Transaction Id": FilterColumn = "TransactionId"; break;
                case "Order Id": FilterColumn = "OrderId"; break;
                case "First Name": FilterColumn = "FirstName"; break;
                case "Last Name": FilterColumn = "LastName"; break;
                case "N.o": FilterColumn = "No"; break;
                case "Phone Number": FilterColumn = "PhoneNumber"; break;
                case "Total Amount": FilterColumn = "TotalAmount"; break;
                case "Remaing Amount": FilterColumn = "RemaingAmount"; break;
                case "Paid Amount": FilterColumn = "PaidAmount"; break;

                default: FilterColumn = ""; break;


            }

            if (CBFilter.Text == "None" || TBFilter.Text == "")
            {
                dtTranstions.DefaultView.RowFilter = "";
                LabRecord.Text = DGVTransactions.Rows.Count.ToString();
                return;
            }

            else if (CBFilter.Text == "Transaction Id"|| CBFilter.Text == "Order Id" || CBFilter.Text == "N.o"||
                CBFilter.Text=="Total Amount"||CBFilter.Text== "Remaing Amount"||CBFilter.Text== "Paid Amount")
                
            {
                dtTranstions.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, TBFilter.Text);
            }
            else
            {
                dtTranstions.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, TBFilter.Text);

            }
            LabRecord.Text = DGVTransactions.Rows.Count.ToString();


        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TBFilter_TextChanged(null, null);
            }

            if (CBFilter.Text == "Transaction Id" || CBFilter.Text == "Order Id" || CBFilter.Text == "N.o")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            FrmVendorHome home = new FrmVendorHome();

            this.Close();

            home.Show();


        }

        private void CreateDataGridView()
        {
            TransationsTable.Columns.Add("TransactionId", typeof(int));
            TransationsTable.Columns.Add("OrderId", typeof(int));
            TransationsTable.Columns.Add("FirstName", typeof(string));
            TransationsTable.Columns.Add("LastName", typeof(string));
            TransationsTable.Columns.Add("No", typeof(int));
            TransationsTable.Columns.Add("PhoneNumber", typeof(string));
            TransationsTable.Columns.Add("TotalAmount", typeof(double));
            TransationsTable.Columns.Add("RemaingAmount", typeof(double));
            TransationsTable.Columns.Add("PaidAmount", typeof(double));
            
            TransationsTable.Columns.Add("TransactionDate", typeof(DateTime));
            TransationsTable.Columns.Add("DetailsPaid", typeof(string));


        }

     
        private void FrmTransactionManagment_Load(object sender, EventArgs e)
        {
            CreateDataGridView();
            RefershData();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmVendorHome home = new FrmVendorHome();

            this.Close();

            home.Show();
        }
    }
}
