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
    class BillDAL
    {
        public static List<Bill> getAllBill()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Bill> data = new List<Bill>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Bill";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bill bill = new Bill();
                        bill.id = reader.GetInt32(0);
                        bill.customer_id = reader.GetInt32(1);
                        bill.combo_id = reader.GetInt32(2);
                        bill.quantity = reader.GetInt32(3);
                        bill.reduce = (float)reader.GetDouble(4);
                        bill.total = (float)reader.GetDouble(5);
                        bill.money = (float)reader.GetDouble(6);
                        data.Add(bill);
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

        public static List<Bill> getAllBillDontHaveDelivery()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Bill> data = new List<Bill>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Bill WHERE id NOT IN (SELECT bill_id FROM Delivery)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bill bill = new Bill();
                        bill.id = reader.GetInt32(0);
                        bill.customer_id = reader.GetInt32(1);
                        bill.combo_id = reader.GetInt32(2);
                        bill.quantity = reader.GetInt32(3);
                        bill.reduce = (float)reader.GetDouble(4);
                        bill.total = (float)reader.GetDouble(5);
                        bill.money = (float)reader.GetDouble(6);
                        data.Add(bill);
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


        public static bool addBill(Bill bill, List<BillDetail> billDetailList)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            int id = 0;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO Bill(customer_id,combo_id,quantity,reduce,total,money) VALUES (@customer_id,@combo_id,@quantity,@reduce,@total,@money)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@customer_id", bill.customer_id);
                cmd.Parameters.AddWithValue("@combo_id", bill.combo_id);
                cmd.Parameters.AddWithValue("@quantity", bill.quantity);
                cmd.Parameters.AddWithValue("@reduce", bill.reduce);
                cmd.Parameters.AddWithValue("@total", bill.total);
                cmd.Parameters.AddWithValue("@money", bill.money);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return false;
            }

            sql = "SELECT TOP 1 ID FROM bill ORDER BY ID DESC";

            try
            {
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.NextResult();
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return false;
            }

            foreach(BillDetail billDetail in billDetailList)
            {
                sql = "INSERT INTO BillDetail(bill_id,product_id,quantity,price) VALUES (@bill_id,@product_id,@quantity,@price)";
                billDetail.bill_id = id;
                try
                {
                    cmd = new SqlCommand(sql, cnn);

                    cmd.Parameters.AddWithValue("@bill_id", billDetail.bill_id);
                    cmd.Parameters.AddWithValue("@product_id", billDetail.product_id);
                    cmd.Parameters.AddWithValue("@quantity", billDetail.quantity);
                    cmd.Parameters.AddWithValue("@price", billDetail.price);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                    return false;
                }
            }

            
            cnn.Close();
            return true;
        }

        public static bool deleteBill(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "DELETE FROM Bill WHERE id = @id ";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
