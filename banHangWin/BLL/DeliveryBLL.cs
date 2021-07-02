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
    class DeliveryBLL
    {
        public static List<Delivery> getAllDelivery()
        {
            return DeliveryDAL.getAllDelivery();
        }

        public static bool addDelivery(Delivery delivery)
        {
            if(delivery.fullname == "")
            {
                MessageBox.Show("Tên người nhận không được để trống");
                return false;
            }

            if (delivery.phone == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return false;
            }

            if (delivery.address == "")
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return false;
            }

            if(DateTime.Compare(DateTime.Now.Date, delivery.date.Date) > 0)
            {
                MessageBox.Show("Ngày giao không phù hợp");
                return false;
            }

            return DeliveryDAL.addDelivery(delivery);
        }

        public static bool editDelivery(Delivery delivery)
        {
            if (delivery.fullname == "")
            {
                MessageBox.Show("Tên người nhận không được để trống");
                return false;
            }

            if (delivery.phone == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return false;
            }

            if (delivery.address == "")
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return false;
            }

            return DeliveryDAL.editDelivery(delivery);
        }

        public static bool deleteDelivery(int id)
        {
            return DeliveryDAL.deleteDelivery(id);
        }
    }
}
