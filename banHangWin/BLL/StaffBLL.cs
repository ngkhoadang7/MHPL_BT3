using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using banHangWin.DTO;
using banHangWin.DAL;

namespace banHangWin.BLL
{
    class StaffBLL
    {
        public static bool Login(Staff staff) 
        { 
            if(staff.userName == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return false;
            }

            if (staff.password == "")
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return false;
            }

            return StaffDAL.Login(staff);
        }
    }
}
