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
    class CatalogDAL
    {
        public static List<Catalog> getAllCatalog()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;
            SqlDataReader reader;
            List<Catalog> data = new List<Catalog>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Catalog";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Catalog catalog = new Catalog();
                        catalog.id = reader.GetInt32(0);
                        catalog.name = reader.GetString(1);
                        data.Add(catalog);
                    }
                    reader.NextResult();
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Can not open connection!");
            }
            return data;
        }

    }
}
