using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace banHangWin.DAL
{
    class DAL
    {
        public static SqlConnection cnn;
        public static SqlConnection connectDB()
        {
            cnn = new SqlConnection("Data Source=VINNE-LAP\\SQLEXPRESS;Initial Catalog=banHang;Integrated Security=True");
            return cnn;
        }
    }
}
