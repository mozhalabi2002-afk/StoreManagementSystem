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
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public async void LoadItem(ProductBookingDTO dto)
        {
            ProductDTO product = await ProductApi.FindProduct(dto.ProductId);

            if (product.SaleType == ProductDTO.eSaleType1.eSaleByQuantity)
            {
                LabType.Text = "Quantity";
                Type.Text= dto.Quantity.ToString();
                TotalAmount.Text = (product.Price*dto.Quantity).ToString();

            }
            else
            {
                LabType.Text = "Weight";
                Type.Text = dto.Weight.ToString();
                TotalAmount.Text = (product.Price * dto.Weight).ToString();

            }

            LabProductName .Text = product.ProductName;
            LabPrice.Text = product.Price.ToString();
        
        }

    }
}
