using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wcf.Entities.Concrete;
using Wcf.Services;

namespace Wcf.FormUI.Forms
{
    public partial class ProductForm : Form
    {
        ProductService productService = new ProductService();
        Product entity = new Product();
        public ProductForm()
        {
            InitializeComponent();
        }
        void Clear()
        {
            txtName.Clear();
            txtPrice.Clear();
            numQuantity.Value = 0;
            cmbCategory.SelectedValue = "";
        }
        void FillComboBox()
        {
            cmbCategory.DataSource = productService.GetCategoryForProduct();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";
        }
        void FormLoad()
        {
            FillComboBox();
            dtGridProduct.DataSource = productService.GetAll();            
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            entity.Name = txtName.Text;
            entity.Price = Convert.ToDecimal(txtPrice.Text);
            entity.Quantity = (int)numQuantity.Value;
            entity.CategoryId = (int)cmbCategory.SelectedValue;
            entity.CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            productService.Add(entity);
            Clear();
            FormLoad();
        }

        private void dtGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridProduct.CurrentRow;
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtName.Tag = row.Cells["Id"].Value;
            txtPrice.Text = Convert.ToDecimal(row.Cells["Price"].Value).ToString();
            numQuantity.Value = (int)row.Cells["Quantity"].Value;
            cmbCategory.SelectedValue = row.Cells["CategoryId"].Value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var productId = (int)dtGridProduct.CurrentRow.Cells["Id"].Value;
            entity = productService.Get(productId);

            entity.Name = txtName.Text;
            entity.Price = Convert.ToDecimal(txtPrice.Text);
            entity.Quantity = (int)numQuantity.Value;
            entity.CategoryId = (int)cmbCategory.SelectedValue;

            productService.Update(entity);
            Clear();
            FormLoad();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var productId = (int)dtGridProduct.CurrentRow.Cells["Id"].Value;
            entity = productService.Get(productId);

            productService.Delete(entity);
            Clear();
            FormLoad();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            FormLoad();            
        }
    }
}
