using StoreProject.People;
using System;
using System.Collections;
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
    public partial class FrmVendorsManagement : Form
    {
        DataTable VendorsTable = new DataTable();
        DataTable dtVendors =new DataTable();
        public FrmVendorsManagement()
        {
            InitializeComponent();
        }


        private void FormateDataGridView()
        {
            if (DGVVendors.Rows.Count > 0)
            {

                DGVVendors.Columns[0].HeaderText = "Vendor ID";
                DGVVendors.Columns[0].Width = 100;


                DGVVendors.Columns[1].HeaderText = "Vendor Name";
                DGVVendors.Columns[1].Width = 120;

                DGVVendors.Columns[2].HeaderText = "First Name";
                DGVVendors.Columns[2].Width = 120;
              
                
                DGVVendors.Columns[3].HeaderText = "Second Name";
                DGVVendors.Columns[3].Width = 120;
                

                DGVVendors.Columns[4].HeaderText = "Last Name";
                DGVVendors.Columns[4].Width = 120;
                

                DGVVendors.Columns[5].HeaderText = "N.O";
                DGVVendors.Columns[5].Width = 100;
                

                DGVVendors.Columns[6].HeaderText = "Shift Time Started";
                DGVVendors.Columns[6].Width = 130;
               
                
                DGVVendors.Columns[7].HeaderText = "Shift Time Finshed";
                DGVVendors.Columns[7].Width = 130;


                DGVVendors.Columns[8].HeaderText = "Phone Number";
                DGVVendors.Columns[8].Width = 120;

            }
        }


        public async Task FillDataTable()
        {
            List<DTOVendor> vendorsList = await ClsVendorApi.GetAllVendors();

            VendorsTable.Rows.Clear();

            foreach (var item in vendorsList)
            {

                PeopleDto person=await PeopleApi.FindPerson(item.PersonId);

                VendorsTable.Rows.Add(

                    item.VendorId,
                    item.VendorName,
                    person.FirstName,
                    person.SecondName,
                    person.LastName,
                    person.No,
                    item.ShiftTimeStarted.ToString(),
                    item.ShiftTimeFinshed.ToString(),
                    person.PhoneNumber.ToString()

                );
            }

            dtVendors = VendorsTable.DefaultView.ToTable(false, "VendorId", "VendorName", "FirstName", "SecondName",
                "LastName", "No", "ShiftTimeStarted", "ShiftTimeFinshed", "PhoneNumber");
        }
        
        private void RefershDataGridView()
        {
            DGVVendors.DataSource=null;
            DGVVendors.DataSource = dtVendors;
        }
        private async void RefershData()
        {

            await FillDataTable();
            RefershDataGridView();
            CBFilter.SelectedIndex = 0;
            LabRecord.Text = DGVVendors.Rows.Count.ToString();
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
                case "Vendor Id": FilterColumn = "VendorId"; break;

                case "Vendor Name": FilterColumn = "VendorName"; break;
                case "First Name": FilterColumn = "FirstName"; break;
                case "Second Name": FilterColumn = "SecondName"; break;
                case "Last Name": FilterColumn = "LastName"; break;
                case "N.o": FilterColumn = "No"; break;
                case "Shift Time Started": FilterColumn = "ShiftTimeStarted"; break;
                case "Shift Time Finshed": FilterColumn = "ShiftTimeFinshed"; break;
                case "Phone Number": FilterColumn = "PhoneNumber"; break;

                default: FilterColumn = ""; break;


            }

            if (CBFilter.Text == "None" || TBFilter.Text == "")
            {
                dtVendors.DefaultView.RowFilter = "";
                LabRecord.Text = DGVVendors.Rows.Count.ToString();
                return;
            }

            else if (CBFilter.Text == "Vendor Id" ||CBFilter.Text== "N.o")
            {
                dtVendors.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, TBFilter.Text);
            }else
            {
                dtVendors.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, TBFilter.Text);

            }
            LabRecord.Text = DGVVendors.Rows.Count.ToString();


        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TBFilter_TextChanged(null, null);
            }

            if (CBFilter.Text == "Vendor Id"||CBFilter.Text== "N.o")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmVendorHome home = new FrmVendorHome();

            this.Close();

            home.Show();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            FrmAddEditVendor vendor = new FrmAddEditVendor();

            vendor.OperationFinshed += () =>
            {
                FrmVendorsManagement frm = new FrmVendorsManagement(); frm.Show();
            };

            this.Close();
            vendor.Show();
        }

        private void addNewVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditVendor vendor = new FrmAddEditVendor();

            vendor.OperationFinshed += () =>
            {
                FrmVendorsManagement frm = new FrmVendorsManagement(); frm.Show();
            };

            this.Close();
            vendor.Show();
        }

        private async Task DeleteVendor(int VendorId)
        {


            if (MessageBox.Show("Are you sure delete this vendor?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                bool IsSuccess = await ClsVendorApi.DeleteVendorId(VendorId);

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

        private void updateVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int VendorId = Convert.ToInt32(DGVVendors.CurrentRow.Cells[0].Value);

            FrmAddEditVendor vendor = new FrmAddEditVendor(VendorId);

            vendor.OperationFinshed += () =>
            {
                FrmVendorsManagement frm = new FrmVendorsManagement(); frm.Show();
            };

            this.Close();
            vendor.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            FrmVendorHome home = new FrmVendorHome();

            this.Close();

            home.Show();


        }

        private void CreateDataGridView()
        {
            VendorsTable.Columns.Add("VendorId", typeof(int));
            VendorsTable.Columns.Add("VendorName", typeof(string));
            VendorsTable.Columns.Add("FirstName", typeof(string));
            VendorsTable.Columns.Add("SecondName", typeof(string));
            VendorsTable.Columns.Add("LastName", typeof(string));
            VendorsTable.Columns.Add("No", typeof(int));
            VendorsTable.Columns.Add("ShiftTimeStarted", typeof(string));
            VendorsTable.Columns.Add("ShiftTimeFinshed", typeof(string));
            VendorsTable.Columns.Add("PhoneNumber", typeof(string));


        }

        private async void FrmVendorsManagement_Load(object sender, EventArgs e)
        {
            CreateDataGridView();
            RefershData();
          

        }

        private void deleteVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int VendorId = Convert.ToInt32(DGVVendors.CurrentRow.Cells[0].Value);
            DeleteVendor(VendorId);

        }
    
    
    }
}
