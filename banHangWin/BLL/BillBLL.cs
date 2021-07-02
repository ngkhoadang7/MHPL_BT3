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
    class BillBLL
    {
        public static List<Bill> getAllBill()
        {
            return BillDAL.getAllBill();
        }

        public static List<Bill> getAllBillDontHaveDelivery()
        {
            return BillDAL.getAllBillDontHaveDelivery();
        }

        public static bool addBill(Bill bill, List<BillDetail> billDetailList)
        {
            if(billDetailList.Count == 0)
            {
                MessageBox.Show("Thêm sản phẩm cho hóa đơn");
                return false;
            }
            return BillDAL.addBill(bill, billDetailList);
        }

        public static bool deleteBill(int id)
        {
            
            return BillDAL.deleteBill(id);
        }

    }
}
