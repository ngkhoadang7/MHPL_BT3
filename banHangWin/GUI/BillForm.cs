using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using banHangWin.BLL;
using banHangWin.DTO;

namespace banHangWin.GUI
{
    public partial class BillForm : Form
    {
        List<Bill> billList;
        int selectedBillID;
        public BillForm()
        {
            InitializeComponent();
            generateMainDataGridView();
        }
        
        private void generateMainDataGridView()
        {
            mainGridView.DataSource = null;
            mainGridView.Rows.Clear();
            mainGridView.Refresh();

            billList = BillBLL.getAllBill();
            mainGridView.DataSource = billList;
            mainGridView.Columns["id"].HeaderText = "Mã hóa đơn";
            mainGridView.Columns["customer_id"].HeaderText = "Mã khách hàng";
            mainGridView.Columns["combo_id"].HeaderText = "Mã Combo";
            mainGridView.Columns["quantity"].HeaderText = "Số lượng";
            mainGridView.Columns["reduce"].HeaderText = "Số tiền giảm";
            mainGridView.Columns["reduce"].DefaultCellStyle.Format = "N0";
            mainGridView.Columns["total"].HeaderText = "Tổng tiền";
            mainGridView.Columns["total"].DefaultCellStyle.Format = "N0";
            mainGridView.Columns["money"].HeaderText = "Thành tiền";
            mainGridView.Columns["money"].DefaultCellStyle.Format = "N0";
            mainGridView.Columns["money"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void generateDataSubGridView()
        {
            subGridView.DataSource = null;
            subGridView.Rows.Clear();
            subGridView.Refresh();

            int index = mainGridView.SelectedRows[0].Index;
            Bill temp = billList[index];

            List<BillDetail> billDetailList = BillDetailBLL.createBillDetailList(BillDetailBLL.getAllBillDetailByBillId(temp.id));
            subGridView.DataSource = billDetailList;
            subGridView.Columns["bill_id"].Visible = false;
            subGridView.Columns["product_id"].Visible = false;
            subGridView.Columns["product_name"].HeaderText = "Tên sản phẩm";
            subGridView.Columns["quantity"].HeaderText = "Số lượng";
            subGridView.Columns["price"].HeaderText = "Giá tiền";
            subGridView.Columns["price"].DefaultCellStyle.Format = "N0";
            subGridView.Columns["product_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BillForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
            this.Hide();
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            ComboForm form = new ComboForm();
            form.Show();
            this.Hide();
        }
        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (mainGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn hóa đơn cần xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = mainGridView.SelectedRows[0].Index;
                if (BillBLL.deleteBill(billList[index].id))
                {
                    generateMainDataGridView();

                    subGridView.DataSource = null;
                    subGridView.Rows.Clear();
                    subGridView.Refresh();

                    MessageBox.Show("Xóa hóa đơn thành công");
                }
            }
            
        }

        private void btnAddComboBill_Click(object sender, EventArgs e)
        {
            AddComboBillForm form = new AddComboBillForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                generateMainDataGridView();
            }
        }

        private void mainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(mainGridView.Rows.Count > 0) 
            {
                mainGridView.Rows[0].Selected = false;
            }
        }

        private void mainGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = mainGridView.SelectedRows[0].Index;
            Bill temp = billList[index];
            selectedBillID = temp.id;
            generateDataSubGridView();
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            AddBillForm form = new AddBillForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                generateMainDataGridView();
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
