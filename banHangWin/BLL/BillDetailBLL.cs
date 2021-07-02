using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DTO;
using banHangWin.DAL;

namespace banHangWin.BLL
{
    class BillDetailBLL
    {
        public static List<BillDetail> createBillDetailComboList(List<Product> productList)
        {
            List<BillDetail> result = new List<BillDetail>();
            foreach(Product item in productList)
            {
                BillDetail billDetail = new BillDetail();
                billDetail.product_id = item.id;
                billDetail.product_name = item.name;
                billDetail.price = item.price;
                billDetail.quantity = 1;
                result.Add(billDetail);
            }
            return result;
        }

        public static List<BillDetail> createBillDetailList(List<BillDetail> billDetailList)
        {
            List<Product> products = ProductDAL.getAllProduct();
            foreach(BillDetail item in billDetailList)
            {
                foreach(Product itm in products)
                {
                    if(itm.id == item.product_id)
                    {
                        item.product_name = itm.name;
                        break;
                    }
                }
            }
            return billDetailList;
        }

        public static List<BillDetail> getAllBillDetailByBillId(int id)
        {
            return BillDetailDAL.getAllBillDetailByBillId(id);
        }
    }
}
