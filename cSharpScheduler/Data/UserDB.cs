using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpScheduler.Data
{
    public static class UserDB
    {
        public static bool ValidateLogin(string username, string password)
        {
            string sql = "SELECT COUNT(*) FROM user WHERE username = @user AND password = @pass";

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
        }

        public static int GetUserId(string username)
        {
            string sql = "SELECT userId FROM user WHERE userName = @user LIMIT 1";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                conn.Open();

                object result = cmd.ExecuteScalar();

                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

    }

}

