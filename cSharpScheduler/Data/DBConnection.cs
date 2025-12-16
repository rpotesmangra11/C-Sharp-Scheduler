using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace cSharpScheduler
{
    public static class DBConnection
    {
        private const string connString =
            "server=127.0.0.1;user id=sqlUser;password=Passw0rd!;database=client_schedule;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }

}
