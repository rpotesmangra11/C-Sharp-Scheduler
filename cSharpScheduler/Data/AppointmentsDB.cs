using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpScheduler
{
    public static class AppointmentsDB
    {
        public static DataTable GetAllAppointments()
        {
            string sql = @"
        SELECT 
            appointmentId,
            customerId,
            userId,
            title,
            description,
            location,
            contact,
            type,
            url,
            start,
            end
        FROM appointment";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }


        public static DataTable GetAppointmentsByCustomer(int customerId)
        {
            string sql = @"
        SELECT 
            appointmentId,
            title,
            description,
            location,
            type,
            start,
            end
        FROM appointment
        WHERE customerId = @customerId";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
