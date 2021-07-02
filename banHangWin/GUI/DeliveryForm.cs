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
    public partial class DeliveryForm : Form
    {
        List<Bill> billList;
        List<Delivery> deliveryList;
        List<Shipper> shipperList;
        public DeliveryForm()
        {
            InitializeComponent();
            generateComboBoxBill();
            generateComboBoxShipper();
            generateGridViewData();
        }

        private void generateGridViewData()
        {
            GridView1.DataSource = null;
            GridView1.Rows.Clear();
            GridView1.Refresh();

            deliveryList = DeliveryBLL.getAllDelivery();
            GridView1.DataSource = deliveryList;
            GridView1.Columns["id"].Visible = false;
            GridView1.Columns["bill_id"].HeaderText = "Mã HĐ";
            GridView1.Columns["shipper"].HeaderText = "Mã NVGH";
            GridView1.Columns["fullname"].HeaderText = "Tên người nhận";
            GridView1.Columns["phone"].HeaderText = "Số ĐT";
            GridView1.Columns["address"].HeaderText = "Địa chỉ";
            GridView1.Columns["date"].HeaderText = "Ngày giao";
            GridView1.Columns["note"].HeaderText = "Ghi chú";
            GridView1.Columns["address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void generateComboBoxShipper()
        {
            shipperList = ShipperBLL.getAllShipper();

            cmbShipper.DataSource = shipperList;
            cmbShipper.DisplayMember = "username";
            cmbShipper.ValueMember = "username";
        }

        private void generateComboBoxBill()
        {
            billList = BillBLL.getAllBillDontHaveDelivery();

            cmbBill.DataSource = billList;
            cmbBill.DisplayMember = "id";
            cmbBill.ValueMember = "id";
        }

        private void DeliveryForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnCombo_Click(object sender, EventArgs e)
        {
            ComboForm form = new ComboForm();
            form.Show();
            Hide();
        }

        private void GridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(GridView1.Rows.Count > 0)
            {
                GridView1.Rows[0].Selected = false;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.bill_id = int.Parse(cmbBill.SelectedValue.ToString());
            delivery.shipper = cmbShipper.SelectedValue.ToString();
            delivery.fullname = txtFullName.Text;
            delivery.phone = txtPhone.Text;
            delivery.address = txtAddress.Text;
            delivery.date = dateTimePicker1.Value.Date;
            delivery.note = txtNote.Text;
            if (DeliveryBLL.addDelivery(delivery))
            {
                generateGridViewData();
                btnRefresh_Click(sender,e);
                MessageBox.Show("Thêm phiếu giao hàng thành công");
            }
            //MessageBox.Show(delivery.date.ToString("yyyy-MM-dd"));
        }

        private void cmbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbBill.SelectedIndex;
            Bill temp = billList[index];
            if (temp.customer_id != 0)
            {
                Customer customer = CustomerBLL.getCustomerById(temp.customer_id);
                txtFullName.Text = customer.fullname;
                txtPhone.Text = customer.phone;
                txtAddress.Text = customer.address;
            }
            else
            {
                txtFullName.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            generateComboBoxBill();
            generateComboBoxShipper();
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtNote.Text = "";
            cmbBill.Enabled = true;
            txtID.Text = "";
        }

        private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = GridView1.SelectedRows[0].Index;
            Delivery temp = deliveryList[index];
            cmbShipper.SelectedValue = shipperList.Single(item => item.username == temp.shipper).username;

            Bill bill = new Bill();
            bill.id = temp.bill_id;
            billList = new List<Bill>();
            billList.Add(bill);
            cmbBill.DataSource = billList;
            cmbBill.DisplayMember = "id";
            cmbBill.ValueMember = "id";
            cmbBill.Enabled = false;

            txtFullName.Text = temp.fullname;
            txtPhone.Text = temp.phone;
            txtAddress.Text = temp.address;
            txtNote.Text = temp.note;

            dateTimePicker1.Value = temp.date;

            txtID.Text = temp.id.ToString();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn phiếu giao hàng cần sửa");
                return;
            }

            Delivery delivery = new Delivery();
            delivery.id = int.Parse(txtID.Text);
            delivery.bill_id = int.Parse(cmbBill.SelectedValue.ToString());
            delivery.shipper = cmbShipper.SelectedValue.ToString();
            delivery.fullname = txtFullName.Text;
            delivery.phone = txtPhone.Text;
            delivery.address = txtAddress.Text;
            delivery.date = dateTimePicker1.Value.Date;
            delivery.note = txtNote.Text;
            if (DeliveryBLL.editDelivery(delivery))
            {
                generateGridViewData();
                btnRefresh_Click(sender, e);
                MessageBox.Show("Sửa phiếu giao hàng thành công");
            }

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn phiếu giao hàng cần xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa phiếu giao hàng này", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (DeliveryBLL.deleteDelivery(int.Parse(txtID.Text)))
                {
                    generateGridViewData();
                    btnRefresh_Click(sender, e);
                    MessageBox.Show("Xóa phiếu giao hàng thành công");
                }
            }
        }
    }
}
