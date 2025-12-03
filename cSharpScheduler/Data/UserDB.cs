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
    }

}

