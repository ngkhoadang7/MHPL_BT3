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
using System.IO;

namespace banHangWin.GUI
{
    public partial class ProductForm : Form
    {
        List<Product> productsList;
        List<Catalog> catalogsList;

        string picturePath, oldImage;
        public ProductForm()
        {
            InitializeComponent();

            generateDataCatalog();
            generateDataGridView();

            numPrice.Maximum = Decimal.MaxValue;
            numQuantity.Maximum = Decimal.MaxValue;
        }

        private void generateDataGridView()
        {
            GridView1.DataSource = null;
            GridView1.Rows.Clear();
            GridView1.Refresh();

            productsList = ProductBLL.getAllProduct();
            GridView1.DataSource = productsList;
            GridView1.Columns["id"].Visible = false;
            GridView1.Columns["image"].Visible = false;
            GridView1.Columns["name"].HeaderText = "Tên sản phẩm";
            GridView1.Columns["catalog_id"].HeaderText = "Danh mục";
            GridView1.Columns["quantity"].HeaderText = "Số lượng";
            GridView1.Columns["price"].HeaderText = "Giá tiền";
            GridView1.Columns["price"].DefaultCellStyle.Format = "N0";
            GridView1.Columns["detail"].HeaderText = "Thông tin chi tiết";
            GridView1.Columns["detail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void generateDataCatalog() 
        {
            catalogsList = CatologBLL.getAllCatalog();

            cmbCatalog.DataSource = catalogsList;
            cmbCatalog.DisplayMember = "name";
            cmbCatalog.ValueMember = "id";
        }
        

        private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = GridView1.SelectedRows[0].Index;
            Product temp = productsList[index];
            txtID.Text = temp.id.ToString();
            txtProductName.Text = temp.name;
            cmbCatalog.SelectedValue = catalogsList.First(item => item.id == temp.catalog_id).id;
            numQuantity.Value = temp.quantity;
            numPrice.Value = (decimal)temp.price;
            txtDetail.Text = temp.detail;
            oldImage = temp.image;
            picturePath = "..\\..\\Images\\" + temp.image;
            pictureBox1.Image = GetCopyImage(picturePath);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.name = txtProductName.Text;
            product.catalog_id = int.Parse(cmbCatalog.SelectedValue.ToString());
            product.quantity = (int)numQuantity.Value;
            product.price = (float)numPrice.Value;
            product.detail = txtDetail.Text;
            product.image = ProductBLL.GenerateNameFile(Path.GetFileName(picturePath));
            if (ProductBLL.addProduct(product))
            {
                File.Copy(picturePath, "..\\..\\Images\\" + product.image);
                generateDataGridView();
                btnRefresh_Click(sender,e);
                MessageBox.Show("Thêm sản phẩm thành công");
            }
        }


        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn sản phẩm cần xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này","", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ProductBLL.deleteProduct(int.Parse(txtID.Text)))
                {
                    if (File.Exists("..\\..\\Images\\" + oldImage))
                    {
                        File.Delete("..\\..\\Images\\" + oldImage);
                    }
                    generateDataGridView();
                    btnRefresh_Click(sender, e);
                    MessageBox.Show("Xóa sản phẩm thành công");
                }
            }
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn sản phẩm cần sửa");
                return;
            }

            bool haveImage = false;

            Product product = new Product();
            product.id = int.Parse(txtID.Text);
            product.name = txtProductName.Text;
            product.catalog_id = int.Parse(cmbCatalog.SelectedValue.ToString());
            product.quantity = (int)numQuantity.Value;
            product.price = (float)numPrice.Value;
            product.detail = txtDetail.Text;
            product.image = ProductBLL.GenerateNameFile(Path.GetFileName(picturePath));
            if (oldImage != Path.GetFileName(picturePath))
            {
                haveImage = true;
            }
            if (ProductBLL.editProduct(product, haveImage))
            {
                if (haveImage)
                {
                    if (File.Exists("..\\..\\Images\\" + oldImage))
                    {
                        File.Delete("..\\..\\Images\\" + oldImage);
                    }
                    File.Copy(picturePath, "..\\..\\Images\\" + product.image);
                }
                
                generateDataGridView();
                btnRefresh_Click(sender, e);
                MessageBox.Show("Sửa sản phẩm thành công");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtProductName.Text = "";
            cmbCatalog.SelectedValue = 1;
            numQuantity.Value = 0;
            numPrice.Value = 0;
            txtDetail.Text = "";
            picturePath = "";
            pictureBox1.Image = null;
            oldImage = "";
            if(GridView1.SelectedRows.Count != 0) { 
                GridView1.SelectedRows[0].Selected = false;
            }
        }

        private void GridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridView1.Rows[0].Selected = false;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *png)|*.jpg; *.jpeg; *.bmp; *png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                picturePath = open.FileName;
            }
        }

        private void ProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnBill_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.Show();
            this.Hide();
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            ComboForm form = new ComboForm();
            form.Show();
            this.Hide();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            DeliveryForm form = new DeliveryForm();
            form.Show();
            Hide();
        }

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
    }
}
