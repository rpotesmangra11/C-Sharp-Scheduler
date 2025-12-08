using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using cSharpScheduler.Models;


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

        public static void AddCustomer(string name, string address, string address2, string postal, string phone)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
               
                string sqlAddress = @"
                INSERT INTO address 
                (address, address2, postalCode, phone, cityId, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@address, @address2, @postal, @phone, 1, NOW(), 'test', NOW(), 'test');
                SELECT LAST_INSERT_ID();";

                long addressId;

                using (MySqlCommand cmd = new MySqlCommand(sqlAddress, conn))
                {
                    cmd.Parameters.AddWithValue("@address", address);
                    if (string.IsNullOrWhiteSpace(address2))
                        cmd.Parameters.AddWithValue("@address2", "");
                    else
                        cmd.Parameters.AddWithValue("@address2", address2);
                    cmd.Parameters.AddWithValue("@postal", postal);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    addressId = Convert.ToInt64(cmd.ExecuteScalar());

                }

                string sqlCustomer = @"
                INSERT INTO customer 
                (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@name, @addressId, 1, NOW(), 'test', NOW(), 'test');";

                using (MySqlCommand cmd = new MySqlCommand(sqlCustomer, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Customer GetCustomerById(int customerId)
        {
            string sql = @"
        SELECT c.customerId, c.customerName, 
               a.address, a.address2, a.postalCode, a.phone
        FROM customer c
        JOIN address a ON c.addressId = a.addressId
        WHERE c.customerId = @id";

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", customerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerId = reader.GetInt32("customerId"),
                                Name = reader.GetString("customerName"),
                                Address = reader.GetString("address"),
                                Address2 = reader.GetString("address2"),
                                PostalCode = reader.GetString("postalCode"),
                                Phone = reader.GetString("phone")
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static bool DeleteCustomer(int customerId)
        {
            string sql = @"DELETE FROM customer WHERE customerId = @customerId";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public static void UpdateCustomer(int customerId, string name, string address, string address2, string postal, string phone)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string getAddressSql = "SELECT addressId FROM customer WHERE customerId = @custId";
                int addressId;

                using (var cmd = new MySqlCommand(getAddressSql, conn))
                {
                    cmd.Parameters.AddWithValue("@custId", customerId);
                    addressId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string updateCustomerSql = @"
                UPDATE customer
                SET customerName = @name,
                    lastUpdate = NOW(),
                    lastUpdateBy = 'test'
                WHERE customerId = @custId";

                using (var cmd = new MySqlCommand(updateCustomerSql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@custId", customerId);
                    cmd.ExecuteNonQuery();
                }

                string updateAddressSql = @"
                UPDATE address
                SET address = @address,
                    address2 = @address2,
                    postalCode = @postal,
                    phone = @phone,
                    lastUpdate = NOW(),
                    lastUpdateBy = 'test'
                WHERE addressId = @id";

                using (var cmd = new MySqlCommand(updateAddressSql, conn))
                {
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@address2", address2 ?? "");
                    cmd.Parameters.AddWithValue("@postal", postal);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@id", addressId);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }


}
