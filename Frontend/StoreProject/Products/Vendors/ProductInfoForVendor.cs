using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject.Products
{
    public partial class ProductInfoForVendor : UserControl
    {
        public delegate void CloseParentFormDelegate();
        public CloseParentFormDelegate CloseParentForm;

        public delegate void FinshedUpdateProductDelegate();
        public FinshedUpdateProductDelegate FinshedUpdateProduct;

        public delegate void DelegateDeletedProduct();
        public DelegateDeletedProduct DeletedProduct;

        int ProductId = -1;
        public ProductInfoForVendor()
        {
            InitializeComponent();
        }

        private void CallCloseForm()
        {
            if (CloseParentForm != null)
            {
                CloseParentForm.Invoke();
            }
        }

        public  async Task LoadProductInfo(int ProductId)
        {


            if (await ProductApi.IsProductExist(ProductId))
            {
                this.ProductId = ProductId;
                productInfo1.LoadProductInfo(ProductId);
            }

        }

        private void CallParentFormAfterDelete()
        {
            if (DeletedProduct != null)
            {
                DeletedProduct.Invoke();
            }
        }
        private void CallParentFormAfterUpdate()
        {
            if (FinshedUpdateProduct != null)
            {
                FinshedUpdateProduct.Invoke();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            FrmAddEditProduct frm = new FrmAddEditProduct(ProductId);
            frm.FinshedUpdateProduct += CallParentFormAfterUpdate;
            CallCloseForm();

            frm.Show();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want to delete this product", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                bool IsSuccess = await ProductApi.DeleteProductId(ProductId);

                if (IsSuccess)
                {
                    MessageBox.Show("Deleted operation is successfully",
                        "Informatiom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    CallParentFormAfterDelete();
                }
                else
                {
                    MessageBox.Show("Deleted operation is not successfully",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


    }
}
