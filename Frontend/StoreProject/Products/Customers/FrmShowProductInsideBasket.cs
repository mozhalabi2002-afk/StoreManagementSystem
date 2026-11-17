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
    public partial class FrmShowProductInsideBasket : Form
    {
        ClsBasket basket1 = new ClsBasket();
        public FrmShowProductInsideBasket(ClsBasket basket)
        {
            InitializeComponent();
            basket1 = basket;
        }

        public void LoadProductInsideBasket(ClsBasket basket)
        {
            
            foreach(ProductBookingDTO Item in basket.Basket)
            {
                ShowProducts(Item);
            }
        }


        private void ShowProducts(ProductBookingDTO Item)
        {

            if (Item == null)
                return;

            ShowProductInBasket productInfo = new ShowProductInBasket();
            productInfo.Width = 480;
            productInfo.Height = 347;
            productInfo.Margin = new Padding(15, 15, 25, 10);
            productInfo.DeleteItem += () =>
            {
                Item.Quantity = 0;
                Item.Weight = 0;
                basket1.Basket.Remove(Item);
                flowLayoutPanel1.Controls.Remove(productInfo);

                if(basket1.Basket.Count == 0)
                {
                    MessageBox.Show("Basket is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }   

                //RefershScreen();
            };
            productInfo.LoadProductInfo(Item);
            flowLayoutPanel1.Controls.Add(productInfo);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IsBasketEmpty(ClsBasket basket)
        {
            if (basket.Basket.Count == 0)
            {
                MessageBox.Show("Basket is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void RefershScreen()
        {
            flowLayoutPanel1.Controls.Clear();
            IsBasketEmpty(basket1);            
            LoadProductInsideBasket(basket1);
        }

        private void FrmShowProductInsideBasket_Load(object sender, EventArgs e)
        {
            RefershScreen();
        }
   
    
    }
}
