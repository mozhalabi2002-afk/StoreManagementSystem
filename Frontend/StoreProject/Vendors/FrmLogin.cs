using Knowlage_Sword_Game.clsGlobal;
using StoreProject.Customers;
using StoreProject.GlobalClasses;
using StoreProject.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject.Vendors
{
    public partial class FrmLogin : Form
    {


        public FrmLogin()
        {
            InitializeComponent();
        }

        bool IsLeft = false;

        public void FillLabalTime()
        {
            LabDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LabTime.Text = DateTime.Now.ToString("h:m tt");

        }

     
        private bool IsUserNameOrPasswordEmpty()
        {
            return string.IsNullOrEmpty(TBUserName.Text) || string.IsNullOrEmpty(TBPassword.Text);
        }

        private void LogUserNameAndPasswordInLogs(string UserName, string Password)
        {
            if (CHBRememberMe.Checked)
            {
                ClsVendorGlobal.RememberUsernameAndaPasswordByRegistry(UserName.Trim(), Password.Trim());
            }
            else
            {
                ClsVendorGlobal.RememberUsernameAndaPasswordByRegistry("", "");

            }
        }

        private void BtnLogin_Enter(object sender, EventArgs e)
        {
            if (IsUserNameOrPasswordEmpty())
            {
                BtnLogin.Enabled = false;
            }


        }

        private async Task<DTOVendor> IsVendorExist(string UserName, string Password)
        {
            DTOVendor vendor = await ClsVendorApi.FindVedorByVendorNameAndPassword(UserName, Password);

            return vendor;

        }

        private async Task<CustomerDTO> IsCustomerExist(string UserName, string Password)
        {
            CustomerDTO customer = await CustomerApi.FindCustomerByCustomerNameAndPassword(UserName, Password);

            return customer;

        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string UserName = TBUserName.Text;
            string Password = TBPassword.Text;


            DTOVendor vendor = await IsVendorExist(UserName, Password);

            if (vendor != null)
            {

                LogUserNameAndPasswordInLogs(UserName, Password);
                this.Hide();
                ClsVendorGlobal.Vendor = vendor;
                FrmVendorHome frm = new FrmVendorHome();
                FrmVendorHome.CloseHome += () => { this.Show(); };
                frm.Show();

            }
            else
            {
                CustomerDTO customer = await IsCustomerExist(UserName, (Password));
                if (customer != null)
                {

                    LogUserNameAndPasswordInLogs(UserName, Password);

                    this.Hide();
                    ShowProductsForCustomers frm = new ShowProductsForCustomers();
                    ClsCustomerGlobal.Customer = customer;
                    frm.CloseForm += () => { this.Show(); };
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("User Name or Password is wrong,try again");
                }

            }

        }

        private void BtnLogin_Leave(object sender, EventArgs e)
        {
            BtnLogin.Enabled = true;
        }

        //private void LinkSign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    this.Hide();
        //    FrmAddEditCustomer frm = new FrmAddEditCustomer();
        //    frm.VisableLevelAndIsActive(false);
        //    frm.FinshFromForm += () => { this.Show(); };
        //    frm.Show();
        //}

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TBUserName.Focus();
            timer1.Enabled = true;

            string UserName = "", Password = "";
            if (ClsVendorGlobal.GetStoredCredentialByRegistry(ref UserName, ref Password))
            {
                TBUserName.Text = UserName;
                TBPassword.Text = Password;
                CHBRememberMe.Checked = true;

            }
            else
            {
                CHBRememberMe.Checked = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FillLabalTime();
            
        }

        private void SendBackForCustomerInfo(CustomerDTO customer)
        {
            this.Show();
            TBUserName.Text = customer.CustomerName;
            TBPassword.Text = customer.Password;
        }

        private void LinkSignupUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditCustomer frm = new FrmAddEditCustomer();

            frm.SendCustomerInfoBack += SendBackForCustomerInfo;
            this.Hide();
            frm.Show();
        }
    }
}
