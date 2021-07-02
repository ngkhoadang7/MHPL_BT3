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
    public partial class ComboForm : Form
    {
        List<Combo> comboList;
        int selectedComboID;
        public ComboForm()
        {
            InitializeComponent();
            generateDataMainGridView();
        }

        private void generateDataMainGridView()
        {
            mainGridView.DataSource = null;
            mainGridView.Rows.Clear();
            mainGridView.Refresh();

            comboList = ComboBLL.getAllCombo();
            mainGridView.DataSource = comboList;
            mainGridView.Columns["id"].Visible = false;
            mainGridView.Columns["products"].Visible = false;
            mainGridView.Columns["name"].HeaderText = "Tên Combo";
            mainGridView.Columns["reduce"].HeaderText = "Số tiền giảm";
            mainGridView.Columns["reduce"].DefaultCellStyle.Format = "N0";
            mainGridView.Columns["reduce"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mainGridView.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void generateDataSubGridView()
        {
            subGridView.DataSource = null;
            subGridView.Rows.Clear();
            subGridView.Refresh();

            int index = mainGridView.SelectedRows[0].Index;
            Combo temp = comboList[index];

            List<Product> productsList = ProductBLL.getAllProductsByIDsString(temp.products);
            subGridView.DataSource = productsList;
            subGridView.Columns["id"].Visible = false;
            subGridView.Columns["catalog_id"].Visible = false;
            subGridView.Columns["quantity"].Visible = false;
            subGridView.Columns["price"].Visible = false;
            subGridView.Columns["detail"].Visible = false;
            subGridView.Columns["image"].Visible = false;
            subGridView.Columns["name"].HeaderText = "Tên sản phẩm";
            subGridView.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ComboForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.Show();
            Hide();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            BillForm form = new BillForm();
            form.Show();
            Hide();
        }

        private void mainGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            generateDataSubGridView();
        }

        private void mainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainGridView.Rows[0].Selected = false;
        }

        private void subGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            subGridView.Rows[0].Selected = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SubComboForm form = new SubComboForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                generateDataMainGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (mainGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn Combo cần sửa");
                return;
            }

            int index = mainGridView.SelectedRows[0].Index;
            Combo temp = comboList[index];

            SubComboForm form = new SubComboForm(temp.id, "edit");
            if (form.ShowDialog() == DialogResult.OK)
            {
                generateDataMainGridView();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (mainGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn Combo cần xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Combo này", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = mainGridView.SelectedRows[0].Index;
                Combo temp = comboList[index];
                if (ComboBLL.deleteCombo(temp.id))
                {
                    generateDataMainGridView();
                    subGridView.DataSource = null;
                    subGridView.Rows.Clear();
                    subGridView.Refresh();
                    MessageBox.Show("Xóa Combo thành công");
                }
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            DeliveryForm form = new DeliveryForm();
            form.Show();
            Hide();
        }
    }
}
