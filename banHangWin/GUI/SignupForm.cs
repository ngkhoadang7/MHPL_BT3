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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.userName = txtUsername.Text;
            staff.password = txtPassword.Text;
            if (StaffBLL.Login(staff))
            {
                MessageBox.Show("Đăng nhập thành công");
                ProductForm productForm = new ProductForm();
                productForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
