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
    public partial class AddComboBillForm : Form
    {
        List<Combo> comboList;
        List<BillDetail> billDetailList;
        public AddComboBillForm()
        {
            InitializeComponent();
            generateComboData();
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

        private void generateComboData()
        {
            comboList = ComboBLL.getAllCombo();

            cmbCombo.DataSource = comboList;
            cmbCombo.DisplayMember = "name";
            cmbCombo.ValueMember = "id";
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.customer_id = int.Parse(cmbCustomer.SelectedValue.ToString());
            bill.combo_id = int.Parse(cmbCombo.SelectedValue.ToString());
            bill.quantity = int.Parse(txtQuantity.Text);
            bill.reduce = float.Parse(txtReduce.Text);
            bill.total = float.Parse(txtTotal.Text);
            bill.money = float.Parse(txtMoney.Text);
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

        private void cmbCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = cmbCombo.SelectedIndex;
            Combo combo = comboList[index];
            txtReduce.Text = combo.reduce.ToString("N0");
            List<Product> productList = ProductBLL.getAllProductsByIDsString(combo.products);
            billDetailList = BillDetailBLL.createBillDetailComboList(productList);
            float total = 0;
            int quantity = 0;
            foreach (BillDetail item in billDetailList)
            {
                total += (item.quantity * item.price);
                quantity += item.quantity;
            }
            float money = total - combo.reduce;

            txtQuantity.Text = quantity.ToString();
            txtTotal.Text = total.ToString("N0");
            txtMoney.Text = money.ToString("N0");
            generateDataGridView();
        }
    }
}
