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
    class BillDetailDAL
    {
        public static List<BillDetail> getAllBillDetailByBillId(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<BillDetail> data = new List<BillDetail>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM BillDetail WHERE bill_id = "+ id;

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BillDetail billDetail = new BillDetail();
                        billDetail.bill_id = reader.GetInt32(0);
                        billDetail.product_id = reader.GetInt32(1);
                        billDetail.quantity = reader.GetInt32(2);
                        billDetail.price = (float)reader.GetDouble(3);
                        data.Add(billDetail);
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
