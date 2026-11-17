
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
    public partial class ShowProductsForCustomers : Form
    {


        public delegate void CloseFormDelegate();
        public CloseFormDelegate CloseForm;

        List<ProductDTO> Products = new List<ProductDTO>();

        ClsBasket Basket = new ClsBasket();

        int OrderId = -1;

        public ShowProductsForCustomers()
        {
            InitializeComponent();
        }

        private async Task FillCategoryBox()
        {
            List<CategoriesDTO> Categories =  await ClsCategoryApi.GetAllCategories();

            foreach (CategoriesDTO category in Categories)
            {

                CBCategoryName.Items.Add(category.CategoryName);

            }

            CBCategoryName.SelectedIndex = 0;

        }

        private void CallCloseForm()
        {

            if (CloseForm != null)
            {
                CloseForm.Invoke();
            }

        }
        private async Task GetProducts(string Filter = "All")
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

            if (Products == null)
                return;


            foreach (ProductDTO Product in Products)
            {

                ShowProductForCustomer productInfo = new ShowProductForCustomer();
                productInfo.Width = 459;
                productInfo.Height = 313;
                productInfo.Margin = new Padding(15, 15, 25, 10);
                productInfo.ItemIsReady += (ProductBookingDTO i) => { 
                    
                foreach(var p in Basket.Basket)
                    {

                        if (p.ProductId == i.ProductId)
                        {
                            return;
                        }
                    }    
                    
                    Basket.Basket.Add(i);
                };
                productInfo.LoadProductInfo(Product.ProductId);
                flowLayoutPanel1.Controls.Add(productInfo);

            }

        }

        private void CBCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProducts(CBCategoryName.Text);
        }

        private async void CanacelOrder()
        {
            if(OrderId<0)
            {
                return;
            }

            bool IsSucees = await ProductApi.CancelOrder(OrderId);
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CanacelOrder();
            Basket.CleanBasket();
            CallCloseForm();
            this.Close();
        
        }

        private void ShowProductsForCustomers_Load(object sender, EventArgs e)
        {
            FillCategoryBox();
            GetProducts();
        }

        private void PBBasket_Click(object sender, EventArgs e)
        {
            FrmShowProductInsideBasket frm=new FrmShowProductInsideBasket(Basket);
            frm.Show();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            FrmReceipt frm = new FrmReceipt(Basket);
            frm.ReturnOrderId += (int OrderId) => { this.OrderId = OrderId; };
            frm.CancelOrCompleteOrder += () => { Basket.Basket.Clear(); this.OrderId = -1; };
            frm.ShowDialog();
        }

        private void ShowProductsForCustomers_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("You are leaving the form, any uncompleted order will be canceled.");
        }
    }
}
