using StoreProject.Customers;
using StoreProject.Products.Apis;
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
    public partial class ShowProductInfoForVendor : Form
    {

        List<ProductDTO> Products=new List<ProductDTO>();

        public ShowProductInfoForVendor()
        {
            InitializeComponent();
        }
        private async Task FillCategoryBox()
        {
            List<CategoriesDTO> Categories = await ClsCategoryApi.GetAllCategories();

            foreach (CategoriesDTO category in Categories)
            {

                CBCategoryName.Items.Add(category.CategoryName);

            }

            CBCategoryName.SelectedIndex = 0;

        }
        private void ShowProductInfoForVendor_Load(object sender, EventArgs e)
        {
            FillCategoryBox();
            RefreshData();
        }

        private void RefreshData()
        {
            GetProducts();
        }



        private async Task GetProducts(string Filter="All")
        {
            if (Filter == "All")
            {
                Products = await ProductApi.GetAllProducts();
            }
            else
            {
                Products = await ProductApi.GetProductsByCategoryName(Filter);
            }

            ShowProducts();



        }



        private void ShowProducts()
        {

            flowLayoutPanel1.Controls.Clear();

            if (Products==null)
                return;


            foreach (ProductDTO Product in Products)
            {

                ProductInfoForVendor productInfo = new ProductInfoForVendor();
                productInfo.Width = 459;
                productInfo.Height = 313;
                productInfo.Margin = new Padding(15, 15, 25, 10);
                productInfo.LoadProductInfo(Product.ProductId);
                productInfo.CloseParentForm += CloseForm;
                productInfo.FinshedUpdateProduct += () => { ShowProductInfoForVendor frm =
                    new ShowProductInfoForVendor();
                    frm.Show();
                };
                productInfo.DeletedProduct += () => {
                    RefreshData();
                };
                flowLayoutPanel1.Controls.Add(productInfo);
            }

        }

        private void CBCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProducts(CBCategoryName.Text);
        }

        private void CloseForm()
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmVendorHome frm = new FrmVendorHome();
            this.Close();
            frm.Show();
        }
    }
}
