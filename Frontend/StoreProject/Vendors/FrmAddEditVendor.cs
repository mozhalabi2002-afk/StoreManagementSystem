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
    public partial class FrmAddEditVendor : Form
    {
        enum eMode { eAddNewVendor = 1, eEditVendor = 2 }
        eMode _Mode= eMode.eAddNewVendor;

        public delegate void OperationFinshedDelegate();
        public OperationFinshedDelegate OperationFinshed;

        int VendorId = -1;
        DTOVendor vendor;
        public FrmAddEditVendor()
        {
            InitializeComponent();
            vendor=new DTOVendor();
            _Mode = eMode.eAddNewVendor;

        }

        public FrmAddEditVendor(int VendorId)
        {
            InitializeComponent();
            this.VendorId = VendorId;
            _Mode = eMode.eEditVendor;
        }

        private void FillVendor()
        {

            vendor.VendorName = TBVendorName.Text;
            vendor.Password = TBPasssword.Text;
            vendor.ShiftTimeStarted =ShiftStarted.Value.ToString();
            vendor.ShiftTimeFinshed = ShiftFinshed.Value.ToString();
            vendor.SalaryPerHour = Convert.ToDouble(NUDSalary.Value);
        
        }
        private void CallOperationFinshed()
        {
            if (OperationFinshed != null)
            {
                OperationFinshed.Invoke();
            }


        }
        private async Task LoadVendorInfo()
        {
            vendor = await ClsVendorApi.FindVedor(VendorId);
            if (vendor == null)
            {
                return;
            }

            addOrEditPerson1.LoadPersonId(vendor.PersonId);
            LabVendorId.Text= vendor.VendorId.ToString();
            TBVendorName.Text = vendor.VendorName;
            TBPasssword.Text=vendor.Password;
            ShiftStarted.Value = TimeSpan.Parse(vendor.ShiftTimeStarted);
            ShiftFinshed.Value=TimeSpan.Parse(vendor.ShiftTimeFinshed);
            NUDSalary.Value = Convert.ToDecimal(vendor.SalaryPerHour);

        }
        private void FrmAddEditVendor_Load(object sender, EventArgs e)
        {
            ShiftStarted.GetDefault();
            ShiftFinshed.GetDefault();

            addOrEditPerson1.PersonFilled += MoveToCustomerPage;

            if (_Mode==eMode.eEditVendor)
            {
                LoadVendorInfo();

            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CallOperationFinshed();
            Close();
        }

        public void MoveToCustomerPage(int PersonId)
        {
            vendor.PersonId = PersonId;
            tabControl1.SelectedTab = VendorInfo;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            bool IsSuccess = false;

            if (!this.ValidateChildren())
            {
                return;
            }

            FillVendor();

            if (_Mode == eMode.eAddNewVendor)
            {
                VendorId= await ClsVendorApi.AddNewVenor(vendor);
                IsSuccess = VendorId != -1;
            }
            else
            {

                IsSuccess = await ClsVendorApi.UpdateVedor(vendor);

            }
            if (IsSuccess)
            {
                _Mode = eMode.eEditVendor;
               
                LoadVendorInfo();
                MessageBox.Show("Saved is successfully");

            }
            else
            {
                MessageBox.Show("Saved is not successfully");

            }

        }

        private void TextValidating(TextBox text,CancelEventArgs e)
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
            TextValidating((TextBox)sender,e);
        }

        private void addOrEditPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
