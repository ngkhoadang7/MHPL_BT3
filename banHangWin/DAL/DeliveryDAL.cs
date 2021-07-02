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
    class DeliveryDAL
    {
        public static List<Delivery> getAllDelivery()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Delivery> data = new List<Delivery>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Delivery";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Delivery delivery = new Delivery();
                        delivery.id = reader.GetInt32(0);
                        delivery.bill_id = reader.GetInt32(1);
                        delivery.shipper = reader.GetString(2);
                        delivery.fullname = reader.GetString(3);
                        delivery.phone = reader.GetString(4);
                        delivery.address = reader.GetString(5);
                        delivery.date = reader.GetDateTime(6);
                        delivery.note = reader.GetString(7);

                        data.Add(delivery);
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

        public static bool addDelivery(Delivery delivery)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO Delivery(bill_id,shipper,fullname,phone,address,date,note) VALUES (@bill_id,@shipper,@fullname,@phone,@address,@date,@note)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@bill_id", delivery.bill_id);
                cmd.Parameters.AddWithValue("@shipper", delivery.shipper);
                cmd.Parameters.AddWithValue("@fullname", delivery.fullname);
                cmd.Parameters.AddWithValue("@phone", delivery.phone);
                cmd.Parameters.AddWithValue("@address", delivery.address);
                cmd.Parameters.AddWithValue("@date", delivery.date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@note", delivery.note);

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

        public static bool editDelivery(Delivery delivery)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "UPDATE Delivery SET " +
                "bill_id = @bill_id ," +
                "shipper = @shipper ," +
                "fullname = @fullname ," +
                "phone = @phone ," +
                "address = @address ," +
                "date = @date ," +
                "note = @note " +
                " WHERE id = @id";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@id", delivery.id);
                cmd.Parameters.AddWithValue("@bill_id", delivery.bill_id);
                cmd.Parameters.AddWithValue("@shipper", delivery.shipper);
                cmd.Parameters.AddWithValue("@fullname", delivery.fullname);
                cmd.Parameters.AddWithValue("@phone", delivery.phone);
                cmd.Parameters.AddWithValue("@address", delivery.address);
                cmd.Parameters.AddWithValue("@date", delivery.date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@note", delivery.note);

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

        public static bool deleteDelivery(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "DELETE FROM Delivery WHERE id = @id ";

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
