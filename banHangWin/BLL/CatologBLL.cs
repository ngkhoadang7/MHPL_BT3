using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DTO;
using banHangWin.DAL;

namespace banHangWin.BLL
{
    class CatologBLL
    {
        public static List<Catalog> getAllCatalog() 
        {
            return CatalogDAL.getAllCatalog();
        }
    }
}
