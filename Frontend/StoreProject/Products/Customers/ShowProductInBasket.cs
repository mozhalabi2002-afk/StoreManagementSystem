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
    public partial class ShowProductInBasket : UserControl
    {
        ProductDTO product;

        
        public delegate void DeteteItemDelegate();
        public DeteteItemDelegate DeleteItem;

        ProductBookingDTO Item=new ProductBookingDTO();
        public ShowProductInBasket()
        {
            InitializeComponent();
        }
    
        private void CallDeleteItem()
        {
            if (DeleteItem!=null)
            {
                DeleteItem.Invoke();
            }
        }

        private void ShowAccordingType()
        {
            if (Item.SaleType == ProductBookingDTO.eSaleType1.eSaleByQuantity)
            {
                Weight.Visible = false;
            }
            else
            {
                Quantity.Visible = false;
            }
        }

        public async Task LoadProductInfo(ProductBookingDTO item)
        {
            if (await ProductApi.IsProductExist(item.ProductId))
            {

                productInfo1.selectedProduct = (ProductDTO p) =>
                {
                    product = p;
                };
                
                productInfo1.LoadProductInfo(item.ProductId);

                this.Item = item;
                NUDQuantity.Value = Convert.ToDecimal(item.Quantity);
                TBWeight.Text = item.Weight.ToString();
                
                ShowAccordingType();
            }

        }
        private void ShowProductInBasket_Load(object sender, EventArgs e)
        {
            productInfo1.IsForVendor=false;
        }


        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            
           if(await ProductApi.ReturnProduct(Item))
            {
                CallDeleteItem();
            }
      
        }

        

        private void TBWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';

        }

      
        private async void button1_Click(object sender, EventArgs e)
        {
            int NewQuantity = Convert.ToInt32(NUDQuantity.Value);
            double NewWeight = Convert.ToDouble(TBWeight.Text);

            string Type = Item.SaleType == ProductBookingDTO.eSaleType1.eSaleByQuantity ? "Quantity" : "Weight";

            if (await ProductApi.UpdateBookingProduct(new
                ProductBookingDTO(Item.ProductId, NewQuantity, NewWeight, Item.Quantity, Item.Weight,
                Item.SaleType)))
            {
                Item.Weight = NewWeight;
                Item.Quantity = NewQuantity;
            }
            else
            {
                MessageBox.Show($"{Type} for this Product is not enugh for your order ");
            }
        }

    }
}
