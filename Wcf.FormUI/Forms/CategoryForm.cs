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
    public partial class CategoryForm : Form
    {        
        CategoryService categoryService = new CategoryService();
        Category entity = new Category();
        public CategoryForm()
        {
            InitializeComponent();          
        }
        void Clear()
        {
            txtName.Clear();
        }
        void FormLoad()
        {
            dataGridView1.DataSource = categoryService.GetAll();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            entity.Name = txtName.Text;
            entity.CreatedDate = DateTime.Now.ToLocalTime();

            categoryService.Add(entity);
            Clear();
            FormLoad();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormLoad();
            Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtName.Tag = row.Cells["Id"].Value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var categoryId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            entity = categoryService.Get(categoryId);

            entity.Name = txtName.Text;
            categoryService.Update(entity);
            Clear();
            FormLoad();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var categoryId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            entity = categoryService.Get(categoryId);

            categoryService.Delete(entity);
            Clear();
            FormLoad();
        }
    }
}
