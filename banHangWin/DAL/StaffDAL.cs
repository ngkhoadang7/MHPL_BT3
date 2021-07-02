using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DTO;

namespace banHangWin.DAL
{
    class StaffDAL
    {
        public static bool Login(Staff staff)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Staff WHERE UserName='" + staff.userName + "' AND Password='" + staff.password + "'";

            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                cmd.Dispose();
                cnn.Close();
                return false;
            }
            else
            {
                reader.Close();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
        }

    }
}
