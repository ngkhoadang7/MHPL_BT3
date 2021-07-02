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
    class CustomerDAL
    {
        public static List<Customer> getAllCustomer()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Customer> data = new List<Customer>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Customer";


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.id = reader.GetInt32(0);
                    customer.fullname = reader.GetString(1);
                    customer.phone = reader.GetString(2);
                    customer.address = reader.GetString(3);
                    customer.gender = reader.GetString(4);
                    customer.birthDate = reader.GetDateTime(5);
                    customer.username = reader.GetString(6);
                    customer.password = reader.GetString(7);
                    data.Add(customer);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }

        public static Customer getCustomerById(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            Customer customer = new Customer();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM Customer WHERE ID = " + id;

            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    customer.id = reader.GetInt32(0);
                    customer.fullname = reader.GetString(1);
                    customer.phone = reader.GetString(2);
                    customer.address = reader.GetString(3);
                    customer.gender = reader.GetString(4);
                    customer.birthDate = reader.GetDateTime(5);
                    customer.username = reader.GetString(6);
                    customer.password = reader.GetString(7);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return customer;
        }
    }
}
