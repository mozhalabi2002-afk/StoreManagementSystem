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
    public partial class ShowProductForCustomer : UserControl
    {
        public Action<ProductBookingDTO> ItemIsReady;

        ProductBookingDTO item = new ProductBookingDTO();
        ProductBookingDTO Olditem = new ProductBookingDTO();
        //bool IsFirstCall = false;

        ProductDTO product;
        int ProductId = -1;
        public ShowProductForCustomer()
        {
            InitializeComponent();
        }

        private void CallItemIsReady()
        {
            if (ItemIsReady != null)
            {
                
                ItemIsReady.Invoke(item);
            }
        }

        private bool FillItem()
        {
            if (NUDQuantity.Value <= 0&&product.SaleType==ProductDTO.eSaleType1.eSaleByQuantity)
            {
                MessageBox.Show("You must select quantity of product", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDouble(TBWeight.Text) <= 0 && product.SaleType == ProductDTO.eSaleType1.eSaleByWeight)
            {
                MessageBox.Show("You must select weight of product", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            Olditem.Quantity = item.Quantity;
            Olditem.Weight = item.Weight;
            item.Quantity = Convert.ToInt32(NUDQuantity.Value);
            item.ProductId = ProductId;
            item.Weight = Convert.ToDouble(TBWeight.Text);
            item.SaleType = (ProductBookingDTO.eSaleType1)product.SaleType;
            return true;
        }

        public async Task LoadProductInfo(int ProductId)
        {
            if (await ProductApi.IsProductExist(ProductId))
            {
                this.ProductId = ProductId;
             
                productInfo1.selectedProduct = (ProductDTO p) =>
                {

                    product = p;
                    if (p.SaleType == ProductDTO.eSaleType1.eSaleByQuantity)
                    {

                        Weight.Visible = false;
                    }
                    else
                    {

                        Quantity.Visible = false;

                    }
                };
                productInfo1.LoadProductInfo(ProductId);
            }

        }

     

        private void productInfo1_Load(object sender, EventArgs e)
        {
            productInfo1.IsForVendor = false;
        }

        private void TBWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';

        }

        private void HandleProduct()
        {
            item.Quantity += Olditem.Quantity;
            item.Weight += Olditem.Weight;

        }

        private async void BtnAddToBasket_Click(object sender, EventArgs e)
        {
            if (!FillItem())
                return;

            bool IsBooking = await ProductApi.BookingProduct(item);

            if (!IsBooking)
            {
                MessageBox.Show("We Can not add item to basket");
                item.Weight = Olditem.Weight;
                item.Quantity = Olditem.Quantity;
            }
            else
            {
                NUDQuantity.Value = 1;
                TBWeight.Text = (1).ToString();
                HandleProduct();
                CallItemIsReady();

            }
        }
    }
}
