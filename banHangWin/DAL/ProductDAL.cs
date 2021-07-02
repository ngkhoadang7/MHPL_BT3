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
    class ProductDAL
    {
        public static List<Product> getAllProduct()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Product> data = new List<Product>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Product";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.id = reader.GetInt32(0);
                        product.name = reader.GetString(1);
                        product.catalog_id = reader.GetInt32(2);
                        product.quantity = reader.GetInt32(3);
                        product.price = (float)reader.GetDouble(4);
                        product.detail = reader.GetString(5);
                        product.image = reader.GetString(6);
                        data.Add(product);
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

        public static bool addProduct(Product product)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO Product(name,catalog_id,quantity,price,detail,Image) VALUES (@name,@catalog_id,@quantity,@price,@detail,@Image)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@catalog_id", product.catalog_id);
                cmd.Parameters.AddWithValue("@quantity", product.quantity);
                cmd.Parameters.AddWithValue("@price", product.price);
                cmd.Parameters.AddWithValue("@detail", product.detail);
                cmd.Parameters.AddWithValue("@Image", product.image);

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

        public static bool editProduct(Product product, bool haveImage)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "UPDATE Product SET " +
                "name = @name ," +
                "catalog_id = @catalog_id ," +
                "quantity = @quantity ," +
                "price = @price ," +
                "detail = @detail";
            if (haveImage) {
                sql += ", image = @image";
            }
            sql += " WHERE id = @id";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@id", product.id);
                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@catalog_id", product.catalog_id);
                cmd.Parameters.AddWithValue("@quantity", product.quantity);
                cmd.Parameters.AddWithValue("@price", product.price);
                cmd.Parameters.AddWithValue("@detail", product.detail);
                if (haveImage)
                {
                    cmd.Parameters.AddWithValue("@image", product.image);
                }

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

        public static bool deleteProduct(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "DELETE FROM Product WHERE id = @id ";
             
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
