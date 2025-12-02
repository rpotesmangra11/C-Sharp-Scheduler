using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace cSharpScheduler
{
    public static class CustomerDB
    {
        public static DataTable GetAllCustomers()
        {
            string sql = @"
        SELECT 
            c.customerId,
            c.customerName,
            a.address,
            a.postalCode,
            a.phone
        FROM customer c
        JOIN address a ON c.addressId = a.addressId";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static void AddCustomer(string name, string address, string postal, string phone)
        {
            string sql = "INSERT INTO customer (name, address, postalCode, phone) VALUES (@name, @address, @postal, @phone)";

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@postal", postal);
                cmd.Parameters.AddWithValue("@phone", phone);

                cmd.ExecuteNonQuery();
            }
        }

    }


}
