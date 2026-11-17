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
    public partial class ProductInfo : UserControl
    {
        public Action<ProductDTO> selectedProduct;

        private ProductDTO Product;
        
        public bool IsForVendor
        {
            set
            {
                Quantity.Visible = value;
                SaleBy.Visible = value;
            }

        }
        
        public ProductInfo()
        {
            InitializeComponent();
        }

        private void SelectedProduct()
        {
            if (selectedProduct != null)
            {
                selectedProduct.Invoke(Product);
            }
        }

        

        public async Task LoadProductInfo(int productId)
        {
             Product = await ProductApi.FindProduct(productId);

            if (Product != null)
            {
                SelectedProduct();
                LabProductName.Text = Product.ProductName;
                LabCategory.Text = Product.CategoryName;
                LabPrice.Text = Product.Price.ToString();
                
                if (Product.SaleType == ProductDTO.eSaleType1.eSaleByQuantity)
                {
                    LabSalType.Text = "Quantity";
                }
                else
                {
                    LabSalType.Text = "Weight";
                }
                if (Product.Weight == 0)
                {
                    Weight.Enabled = false;
                }
                else
                {
                    LabWeight.Text = Product.Weight.ToString();

                }
                if (Product.Size == 0)
                {
                    LabSize.Enabled = false;
                    label6.Enabled = false;
                }
                else
                {
                    LabSize.Text = Product.Size.ToString();
                }

                
                LabQuantity.Text = Product.Quantity.ToString();

                if (!string.IsNullOrEmpty(Product.Image))
                {
                    PBProductImage.Load(Product.Image);
                }

                if (!string.IsNullOrEmpty(Product.Parcode))
                {
                    PBBarCode.Load(Product.Parcode);
                }
            
           
            }
        
        
        }


    }
}
