using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DAL;
using banHangWin.DTO;

namespace banHangWin.BLL
{
    class ShipperBLL
    {
        public static List<Shipper> getAllShipper()
        {
            return ShipperDAL.getAllShipper();
        }
    }
}
