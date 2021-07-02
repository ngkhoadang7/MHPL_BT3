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
    class ShipperDAL
    {
        public static List<Shipper> getAllShipper()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Shipper> data = new List<Shipper>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Shipper";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Shipper shipper = new Shipper();
                        shipper.username = reader.GetString(0);
                        shipper.password = reader.GetString(1);
                       
                        data.Add(shipper);
                    }
                    reader.NextResult();
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return data;
        }
    }
}
