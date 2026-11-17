using Knowlage_Sword_Game;
using StoreProject.Products.Apis;
using StoreProject.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace StoreProject.Products
{
    public partial class FrmAddEditProduct : Form
    {
        public delegate void FinshedUpdateProductDelegate();
        public FinshedUpdateProductDelegate FinshedUpdateProduct;
        enum eMode { AddNew=1,Update=2}
        eMode _Mode = eMode.AddNew;
        
        ProductDTO product;
        int ProductId = 0;
        public FrmAddEditProduct()
        {
            InitializeComponent();

            _Mode=eMode.AddNew;
            product = new ProductDTO();

        }

        public FrmAddEditProduct(int ProductId)
        {
            InitializeComponent();
            _Mode = eMode.Update;
            this.ProductId = ProductId;
        }

        private void CallFinshedUpdateEvent()
        {
            if (FinshedUpdateProduct!=null)
            {
                this.Close();
                FinshedUpdateProduct.Invoke();
            }
        }
        private async Task LoadProduct()
        {
           

            LabAddress.Text = "Update Product";

            product =  await ProductApi.FindProduct(ProductId);

            if (product == null)
            {
                return;
            }

            TBProductName.Text = product.ProductName;
            CBCategoryName.Text = product.CategoryName;
            TBWeight.Text = product.Weight.ToString();
            TBSize.Text=product.Size.ToString();
            TBPrice.Text = product.Price.ToString();
            NUDQuantity.Value = product.Quantity;

            if (product.SaleType == ProductDTO.eSaleType1.eSaleByQuantity)
            {
                CBSaleType.SelectedText = "Quantity";
            }
            else
            {
                CBSaleType.Text = "Weight";

            }


            if (product.Image != "")
            {
                PbProductImage.ImageLocation = product.Image;
            }
            
            if (product.Parcode != "")
            {
                PbBarCode.ImageLocation = product.Parcode;
            }

        }
        private void FillProductInfo()
        {

            product.ProductName = TBProductName.Text;
            product.CategoryName = CBCategoryName.Text;

            if (CBSaleType.Text == "Quantity")
            {
                product.SaleType = ProductDTO.eSaleType1.eSaleByQuantity;
            }
            else
            {
                product.SaleType = ProductDTO.eSaleType1.eSaleByWeight;

            }

            if (string.IsNullOrEmpty(TBWeight.Text))
            {
                product.Weight = 0;

            }
            else
            {
                product.Weight = Convert.ToDouble(TBWeight.Text);
            } 
            
            product.Price = Convert.ToDouble(TBPrice.Text);

            if (string.IsNullOrEmpty(TBSize.Text))
            {
                product.Size = 0;
            }
            else
            {
                product.Size = Convert.ToDouble(TBSize.Text);
            }

            product.Quantity = Convert.ToInt32(NUDQuantity.Value);
            HandleImage();

            product.Image = PbProductImage.ImageLocation;
            product.Parcode = PbBarCode.ImageLocation;
        }

        private void TB_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';

        }

        private void TextValidating(TextBox text, CancelEventArgs e)
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
            TextValidating((TextBox)sender, e);
        }


        private void HandleImage()
        {
            HandleImage(product.Image, PbProductImage);
            HandleImage(product.Parcode, PbBarCode);
        }

        private bool HandleImage(string FilePath,PictureBox Image)
        {

            if (FilePath != Image.ImageLocation)
            {
                if (FilePath != "" && FilePath != null)
                {
                    try
                    {
                        File.Delete(FilePath);
                    }
                    catch (IOException) { }
                }


                if (Image.ImageLocation != "" && Image.ImageLocation != null)
                {
                    string SourceImageFile = Image.ImageLocation.ToString();

                    if (ClsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {

                        Image.ImageLocation = SourceImageFile;

                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
   

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            bool IsSuccess = false;

            if (!ValidateChildren()){
                return;
            }

            FillProductInfo();

            if (_Mode == eMode.AddNew)
            {
                ProductId = await ProductApi.AddNewProduct(product);
                IsSuccess = ProductId != -1;
            }
            else
            {

                IsSuccess = await ProductApi.UpdateProduct(product);

            }

            if (IsSuccess)
            {
                _Mode = eMode.Update;
                MessageBox.Show("Saved product is  successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                LoadProduct();

                CallFinshedUpdateEvent();
            }
            else
            {
                MessageBox.Show("Saved product is not successfully","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private async Task FillCategoryBox()
        {
            List<CategoriesDTO> Categories = await ClsCategoryApi.GetAllCategories();

            foreach (CategoriesDTO category in Categories)
            {

                CBCategoryName.Items.Add(category.CategoryName);

            }

            CBCategoryName.SelectedIndex = 1;

        }


        private void FrmAddEditProduct_Load(object sender, EventArgs e)
        {
            FillCategoryBox();
            CBSaleType.SelectedIndex = 0;
            
            if (_Mode == eMode.Update)
            {
                LoadProduct();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            CallFinshedUpdateEvent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                PbProductImage.Load(selectedFilePath);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                PbBarCode.Load(selectedFilePath);
            }
        }

        private void PbProductImage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(PbProductImage.ImageLocation))
            {

                e.Cancel = true;
                linkLabel1.Focus();
                errorProvider1.SetError(PbProductImage, "You must select picture ");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(PbProductImage, "");

            }
        }

        private void PbBarCode_Click(object sender, EventArgs e)
        {

        }
    }
}
