using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DTO;
using banHangWin.DAL;

namespace banHangWin.BLL
{
    class CustomerBLL
    {
        public static List<Customer> getAllCustomer()
        {
            return CustomerDAL.getAllCustomer();
        }

        public static Customer getCustomerById(int id)
        {
            return CustomerDAL.getCustomerById(id);
        }
    }
}
