using StoreProject.People;
using StoreProject.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace StoreProject.Customers
{
    public partial class FrmAddEditCustomer : Form
    {
        public delegate void OperationFinshedDelegate();
        public OperationFinshedDelegate OperationFinshed;

        public Action<CustomerDTO> SendCustomerInfoBack;

        int CustomerId = -1;
        CustomerDTO customer;

        enum eMode { eAddNewCustomer=1,eUpdateCustomer=2}
        eMode _Mode = eMode.eAddNewCustomer;
        public FrmAddEditCustomer()
        {
            InitializeComponent();
            customer = new CustomerDTO();
            _Mode = eMode.eAddNewCustomer;
        }

        public FrmAddEditCustomer(int CustomerId)
        {
            InitializeComponent();
            this.CustomerId = CustomerId;
            _Mode = eMode.eUpdateCustomer;
        }


        public void CallSendcustomerInfoBack()
        {

            if (SendCustomerInfoBack != null)
            {
                this.Close();
                SendCustomerInfoBack(customer);
            }

        }

        private void FillCustomer()
        {
            customer.CustomerName = TBCustomerName.Text;
            customer.Password = TBPassword.Text;

        }
        private void CallOperationFinshed()
        {
            if (OperationFinshed != null)
            {
                OperationFinshed.Invoke();
            }


        }
        private async Task LoadCustomerInfo()
        {
            customer = await CustomerApi.FindCustomer(CustomerId);

            if (customer == null)
            {
                return;
            }

            addOrEditPerson1.LoadPersonId(customer.PersonId);
            LabCustomerId.Text = customer.CustomerId.ToString();
            TBCustomerName.Text = customer.CustomerName;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CallOperationFinshed();
            Close();
        }

        public void MoveToCustomerPage(PeopleDto person)
        
        {
            customer.PersonId = person.PersonId;
            customer.person = person;
            tabControl1.SelectedTab = CustomerInfo;
        }


        private void FrmAddEditCustomer_Load(object sender, EventArgs e)
        {
            addOrEditPerson1.FullPersonFilled += MoveToCustomerPage;

            if (_Mode==eMode.eUpdateCustomer)
                LoadCustomerInfo();
        }

        private void PBClose_Click(object sender, EventArgs e)
        {
            CallOperationFinshed();
            Close();
        }

        private void TextValidating(TextBox text, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(text.Text))
            {

                e.Cancel = true;
                text.Focus();
                errorProvider1.SetError(text, "You must fill text");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(text, "");

            }

        }

        private void TB_Validating(object sender, CancelEventArgs e)
        {
            TextValidating((TextBox)sender, e);
        }

        private void TBPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPasswordConfirm.Text))
            {

                e.Cancel = true;
                TBPasswordConfirm.Focus();
                errorProvider1.SetError(TBPasswordConfirm, "You must fill text");

            }
            else if (TBPasswordConfirm.Text != TBPassword.Text)
            {
                e.Cancel = true;
                TBPasswordConfirm.Focus();
                errorProvider1.SetError(TBPasswordConfirm, "You must Enter This Text equal Password");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBPasswordConfirm, "");

            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            bool IsSuccess = false;
            if (!this.ValidateChildren())
            {
                return;
            }

            FillCustomer();

            if (_Mode == eMode.eAddNewCustomer)
            {
                CustomerId = await CustomerApi.AddNewCustomer(customer);
                IsSuccess = CustomerId != -1;
            }
            else
            {

                IsSuccess = await CustomerApi.UpdateCustomer(customer);

            }
            if (IsSuccess)
            {
                _Mode = eMode.eUpdateCustomer;

                LoadCustomerInfo();
                MessageBox.Show("Saved is successfully");
                CallSendcustomerInfoBack();
            }
            else
            {
                MessageBox.Show("Saved is not successfully");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallOperationFinshed();
            Close();
        }
    }

}
