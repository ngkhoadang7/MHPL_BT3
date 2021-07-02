using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using banHangWin.DTO;
using banHangWin.BLL;

namespace banHangWin.GUI
{
    public partial class SubComboForm : Form
    {
        List<Product> productList = new List<Product>();
        string mode;
        public SubComboForm()
        {
            InitializeComponent();
            mode = "add";
            numReduce.Maximum = Decimal.MaxValue;
            generateDataProduct();
        }

        public SubComboForm(int id, string mode)
        {
            InitializeComponent();
            this.mode = mode;
            Combo combo = ComboBLL.getComboById(id);
            numReduce.Maximum = Decimal.MaxValue;
            generateDataProduct();

            txtID.Text = combo.id.ToString();
            txtName.Text = combo.name;
            numReduce.Value = (decimal)combo.reduce;
            productList = ProductBLL.getAllProductsByIDsString(combo.products);
            generateDataGridView();
        }

        private void generateDataProduct()
        {
            List<Product> productsList = ProductBLL.getAllProduct();

            cmbProduct.DataSource = productsList;
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
        }

        private void generateDataGridView()
        {
            GridView1.DataSource = null;
            GridView1.Rows.Clear();
            GridView1.Refresh();

            GridView1.DataSource = productList;
            GridView1.Columns["id"].Visible = false;
            GridView1.Columns["catalog_id"].Visible = false;
            GridView1.Columns["quantity"].Visible = false;
            GridView1.Columns["price"].Visible = false;
            GridView1.Columns["detail"].Visible = false;
            GridView1.Columns["image"].Visible = false;
            GridView1.Columns["name"].HeaderText = "Tên sản phẩm";
            GridView1.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            float reduce = (float)numReduce.Value;
            if (mode == "add")
            {
                if (ComboBLL.addCombo(name, reduce, productList))
                {
                    MessageBox.Show("Thêm Combo thành công");
                    DialogResult = DialogResult.OK;
                }
            }
            if (mode == "edit")
            {
                int id = int.Parse(txtID.Text);
                if (ComboBLL.editCombo(id, name, reduce, productList))
                {
                    MessageBox.Show("Sửa Combo thành công");
                    DialogResult = DialogResult.OK;
                }
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.id = int.Parse(cmbProduct.SelectedValue.ToString());
            product.name = cmbProduct.Text;
            if(productList.Find(item => item.id == product.id) != null)
            {
                MessageBox.Show("Sản phẩm đã được thêm");
                return;
            }
            productList.Add(product);
            generateDataGridView();
        }

        private void GridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(GridView1.Rows.Count != 0)
            {
                GridView1.Rows[0].Selected = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn sản phẩm cần xóa");
                return;
            }

            int index = GridView1.SelectedRows[0].Index;
            productList.RemoveAt(index);
            generateDataGridView();
        }
    }

    class minProduct
    {
        public int id { get; set; }
        public string name {get; set;}
    }
}
