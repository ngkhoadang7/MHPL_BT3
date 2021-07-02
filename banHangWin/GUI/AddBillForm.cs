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
    public partial class AddBillForm : Form
    {
        List<Product> productList;
        List<BillDetail> billDetailList = new List<BillDetail>();
        public AddBillForm()
        {
            InitializeComponent();
            generateComboBoxProduct();
            generateCustomerData();
        }

        private void generateCustomerData()
        {
            List<Customer> customerList = CustomerBLL.getAllCustomer();
            Customer customer = new Customer();
            customer.id = 0;
            customerList.Insert(0, customer);

            cmbCustomer.DataSource = customerList;
            cmbCustomer.DisplayMember = "id";
            cmbCustomer.ValueMember = "id";
        }

        private void generateComboBoxProduct()
        {
            productList = ProductBLL.getAllProduct();
            
            cmbProduct.DataSource = productList;
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
        }

        private void generateDataGridView()
        {
            GridView1.DataSource = null;
            GridView1.Rows.Clear();
            GridView1.Refresh();

            GridView1.DataSource = billDetailList;
            GridView1.Columns["bill_id"].Visible = false;
            GridView1.Columns["product_id"].Visible = false;
            GridView1.Columns["product_name"].HeaderText = "Tên sản phẩm";
            GridView1.Columns["quantity"].HeaderText = "Số lượng";
            GridView1.Columns["price"].HeaderText = "Giá tiền";
            GridView1.Columns["price"].DefaultCellStyle.Format = "N0";
            GridView1.Columns["product_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            float total = 0;
            int quantity = 0;
            foreach (BillDetail item in billDetailList)
            {
                total += (item.quantity * item.price);
                quantity += item.quantity;
            }

            txtQuantity.Text = quantity.ToString();
            txtTotal.Text = total.ToString("N0");

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbProduct.SelectedIndex;
            Product temp = productList[index];
            txtRemain.Text = temp.quantity.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(numQuantity.Value == 0)
            {
                MessageBox.Show("Nhập số lượng sản phẩm muốn thêm");
                return;
            }
            if (numQuantity.Value > int.Parse(txtRemain.Text))
            {
                MessageBox.Show("Vượt quá số lượng hàng còn trong kho");
                return;
            }
            int id = int.Parse(cmbProduct.SelectedValue.ToString());
            if(billDetailList.FirstOrDefault(item => item.product_id == id) != null)
            {
                MessageBox.Show("Sản phẩm đã được thêm vào hóa đơn");
                return;
            }
            Product product = productList.FirstOrDefault(item => item.id == id);
            BillDetail billDetail = new BillDetail();
            billDetail.product_id = product.id;
            billDetail.product_name = product.name;
            billDetail.quantity = int.Parse(numQuantity.Value.ToString());
            billDetail.price = product.price;
            billDetailList.Add(billDetail);
            generateDataGridView();
            numQuantity.Value = 0;
        }

        private void GridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridView1.Rows[0].Selected = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn sản phẩm cần xóa");
                return;
            }

            int index = GridView1.SelectedRows[0].Index;
            billDetailList.RemoveAt(index);
            generateDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.customer_id = int.Parse(cmbCustomer.SelectedValue.ToString());
            bill.combo_id = 0;
            bill.quantity = int.Parse(txtQuantity.Text);
            bill.reduce = 0;
            bill.total = float.Parse(txtTotal.Text);
            bill.money = float.Parse(txtTotal.Text);

            if(BillBLL.addBill(bill, billDetailList))
            {
                MessageBox.Show("Thêm hóa đơn thành công");
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
