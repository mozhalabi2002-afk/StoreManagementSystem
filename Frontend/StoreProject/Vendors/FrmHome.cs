using StoreProject.Customers;
using StoreProject.Products;
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

namespace StoreProject
{
    public partial class FrmVendorHome : Form
    {

        public  delegate void CloseHomeDelegate();
        public static CloseHomeDelegate CloseHome;
        public FrmVendorHome()
        {
            InitializeComponent();
        }

        private void CallClose()
        {
            if (CloseHome != null)
            {
                CloseHome.Invoke();
            }
        }
        
        private void addNewVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditVendor vendor = new FrmAddEditVendor();
            vendor.OperationFinshed += () => { FrmVendorHome home = new FrmVendorHome(); home.Show(); };

            this.Close();
            vendor.Show();
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditCustomer customer = new FrmAddEditCustomer();

            customer.OperationFinshed += () => { FrmVendorHome home = new FrmVendorHome(); home.Show(); };

            this.Close();

            customer.Show();
        }

        private void vendorsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendorsManagement frm = new FrmVendorsManagement();
            this.Close();
            frm.Show();
        }

        private void customersManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerManagement frm = new FrmCustomerManagement();
            frm.CloseCurrentForm += () =>
            {
                FrmVendorHome Home = new FrmVendorHome();
                Home.Show();
            };
            this.Close();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            CallClose();
        }

        private void addNewPrductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditProduct frm = new FrmAddEditProduct();

            frm.FinshedUpdateProduct += () => { FrmVendorHome frm1 = new FrmVendorHome(); frm1.Show(); };
            this.Close();

            frm.Show();
        }

        private void showProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProductInfoForVendor frm=new ShowProductInfoForVendor  ();
            this.Close();
            frm.Show();
        }

        private async void transationSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransactionManagment frm = new FrmTransactionManagment();
            frm.Show();
            this.Close();
        }
    }
}
