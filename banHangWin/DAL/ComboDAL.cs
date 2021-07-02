using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using banHangWin.DTO;

namespace banHangWin.DAL
{
    class ComboDAL
    {
        public static List<Combo> getAllCombo()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Combo> data = new List<Combo>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Combo";


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Combo combo = new Combo();
                    combo.id = reader.GetInt32(0);
                    combo.name = reader.GetString(1);
                    combo.products = reader.GetString(2);
                    combo.reduce = (float)reader.GetDouble(3);
                    data.Add(combo);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }

        public static Combo getComboById(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            Combo combo = new Combo();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Combo WHERE id = " + id;

            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    combo.id = reader.GetInt32(0);
                    combo.name = reader.GetString(1);
                    combo.products = reader.GetString(2);
                    combo.reduce = (float)reader.GetDouble(3);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return combo;
        }

        public static bool addCombo(Combo combo )
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO Combo(name,products,reduce) VALUES (@name,@products,@reduce)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@name", combo.name);
                cmd.Parameters.AddWithValue("@products", combo.products);
                cmd.Parameters.AddWithValue("@reduce", combo.reduce);

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

        public static bool editCombo(Combo combo)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "UPDATE Combo SET " +
                "name = @name ," +
                "products = @products ," +
                "reduce = @reduce " +
                " WHERE id = @id";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@name", combo.name);
                cmd.Parameters.AddWithValue("@products", combo.products);
                cmd.Parameters.AddWithValue("@reduce", combo.reduce);
                cmd.Parameters.AddWithValue("@id", combo.id);

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

        public static bool deleteCombo(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "DELETE FROM Combo WHERE id = @id ";

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
