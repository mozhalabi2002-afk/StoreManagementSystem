using StoreProject.People;
using StoreProject.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject.Customers
{
    public partial class FrmCustomerManagement : Form
    {
        public delegate void CloseCurrentFormDelegate();
        public CloseCurrentFormDelegate CloseCurrentForm;
        
        DataTable CustomersTable = new DataTable();
        DataTable dtCustomers = new DataTable();
        public FrmCustomerManagement()
        {
            InitializeComponent();
        }

        private void CallCloseForm()
        {
            if (CloseCurrentForm != null)
            {
                CloseCurrentForm.Invoke();
            }
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            FrmAddEditCustomer customer = new FrmAddEditCustomer();

            customer.OperationFinshed += () => { FrmCustomerManagement frm = new FrmCustomerManagement(); frm.Show(); };

            this.Close();

            customer.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            CallCloseForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            CallCloseForm();
        }



        private void FormateDataGridView()
        {
            if (DGVCustomers.Rows.Count > 0)
            {

                DGVCustomers.Columns[0].HeaderText = "Customer ID";
                DGVCustomers.Columns[0].Width = 100;


                DGVCustomers.Columns[1].HeaderText = "Customer Name";
                DGVCustomers.Columns[1].Width = 120;

                DGVCustomers.Columns[2].HeaderText = "First Name";
                DGVCustomers.Columns[2].Width = 120;


                DGVCustomers.Columns[3].HeaderText = "Second Name";
                DGVCustomers.Columns[3].Width = 120;


                DGVCustomers.Columns[4].HeaderText = "Last Name";
                DGVCustomers.Columns[4].Width = 120;


                DGVCustomers.Columns[5].HeaderText = "N.O";
                DGVCustomers.Columns[5].Width = 100;

                DGVCustomers.Columns[6].HeaderText = "Phone Number";
                DGVCustomers.Columns[6].Width = 120;

            }
        }


        public async Task FillDataTable()
        {
            List<CustomerDTO> CustomersList = await CustomerApi.GetAllCustomers();

            CustomersTable.Rows.Clear();

            foreach (var item in CustomersList)
            {

                PeopleDto person = await PeopleApi.FindPerson(item.PersonId);

                if (person == null)
                {
                    EventLog.WriteEntry("Store", $"Error : person is null after searching person  " +
                        $"in customer managment ", EventLogEntryType.Error);

                    return;
                }
                CustomersTable.Rows.Add(

                    item.CustomerId,
                    item.CustomerName,
                    person.FirstName,
                    person.SecondName,
                    person.LastName,
                    person.No,
                    person.PhoneNumber

                );
            }

            dtCustomers = CustomersTable.DefaultView.ToTable(false, "CustomerId", "CustomerName", "FirstName", "SecondName",
                "LastName", "N.O", "PhoneNumber");
        }

        private void RefershDataGridView()
        {
            DGVCustomers.DataSource = null;
            DGVCustomers.DataSource = dtCustomers;
        }
        private async void RefershData()
        {

            await FillDataTable();
            RefershDataGridView();
            CBFilter.SelectedIndex = 0;
            LabRecord.Text = DGVCustomers.Rows.Count.ToString();
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
                case "Customer Id": FilterColumn = "CustomerId"; break;

                case "Customer Name": FilterColumn = "CustomerName"; break;
                case "First Name": FilterColumn = "FirstName"; break;
                case "Second Name": FilterColumn = "SecondName"; break;
                case "Last Name": FilterColumn = "LastName"; break;
                case "N.o": FilterColumn = "N.O"; break;
                case "Phone Number": FilterColumn = "PhoneNumber"; break;
                    
                default: FilterColumn = ""; break;


            }

            if (CBFilter.Text == "None" || TBFilter.Text == "")
            {
                dtCustomers.DefaultView.RowFilter = "";
                LabRecord.Text = DGVCustomers.Rows.Count.ToString();
                return;
            }

            else if (CBFilter.Text == "Customer Id"||CBFilter.Text=="N.o")
            {
                dtCustomers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, TBFilter.Text);
            }
            else
            {
                dtCustomers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, TBFilter.Text);

            }
            LabRecord.Text = DGVCustomers.Rows.Count.ToString();


        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TBFilter_TextChanged(null, null);
            }

            if (CBFilter.Text == "Customer Id" || CBFilter.Text == "N.o")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }

        private async Task DeleteCustomer(int CustomerId)
        {


            if (MessageBox.Show("Are you sure delete this Customer?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                bool IsSuccess = await CustomerApi.DeleteCustomerId(CustomerId);

                if (IsSuccess)
                {
                    MessageBox.Show("Deleted is successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefershData();
                }
                else
                {
                    MessageBox.Show("Deleted is not successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerId = Convert.ToInt32(DGVCustomers.CurrentRow.Cells[0].Value);

            FrmAddEditCustomer Customer = new FrmAddEditCustomer(CustomerId);

            Customer.OperationFinshed += () =>
            {
                FrmCustomerManagement frm = new FrmCustomerManagement(); frm.Show();
            };

            this.Close();
            Customer.Show();
        }


        private void CreateDataGridView()
        {
            CustomersTable.Columns.Add("CustomerId", typeof(int));
            CustomersTable.Columns.Add("CustomerName", typeof(string));
            CustomersTable.Columns.Add("FirstName", typeof(string));
            CustomersTable.Columns.Add("SecondName", typeof(string));
            CustomersTable.Columns.Add("LastName", typeof(string));
            CustomersTable.Columns.Add("N.O", typeof(int));
            CustomersTable.Columns.Add("PhoneNumber", typeof(string));


        }

        private async void FrmVendorsManagement_Load(object sender, EventArgs e)
        {
            CreateDataGridView();
            RefershData();


        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerId = Convert.ToInt32(DGVCustomers.CurrentRow.Cells[0].Value);
            DeleteCustomer(CustomerId);

        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditCustomer customer = new FrmAddEditCustomer();

            customer.OperationFinshed += () => { FrmCustomerManagement frm = new FrmCustomerManagement(); frm.Show(); };

            this.Close();

            customer.Show();
        }
    }
}
