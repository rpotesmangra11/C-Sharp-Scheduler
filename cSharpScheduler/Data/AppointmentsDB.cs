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

        public static DataTable GetAppointmentTypesForMonthlyReport()
        {
            string sql = @"
        SELECT 
            type,
            start
        FROM appointment;
        ";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetAppointmentsByDate(DateTime date)
        {
            string sql = @"
        SELECT 
            customer.customerName AS Customer,
            appointment.type AS Type,
            appointment.location AS Location,
            appointment.contact AS Contact,
            appointment.start AS Start,
            appointment.end AS End
        FROM appointment
        INNER JOIN customer 
            ON appointment.customerId = customer.customerId
        WHERE DATE(appointment.start) = @date;
    ";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@date", date.Date);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetUpcomingAppointments(int userId)
        {
            string sql = @"
        SELECT appointmentId, customerId, type, start
        FROM appointment
        WHERE userId = @userId
        AND start BETWEEN UTC_TIMESTAMP() AND DATE_ADD(UTC_TIMESTAMP(), INTERVAL 15 MINUTE);
    ";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@userId", userId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public static void AddAppointment(int customerId, int userId,
     string title, string description, string location, string type,
     string contact, DateTime startUtc, DateTime endUtc)
        {
            string sql = @"
        INSERT INTO appointment
        (customerId, userId, title, description, location, contact, type, url,
         start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
        VALUES
        (@customerId, @userId, @title, @description, @location, @contact, @type, @url,
         @start, @end, NOW(), @createdBy, NOW(), @updatedBy);";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@url", ""); // blank URL
                cmd.Parameters.AddWithValue("@start", startUtc);
                cmd.Parameters.AddWithValue("@end", endUtc);
                cmd.Parameters.AddWithValue("@createdBy", "system");
                cmd.Parameters.AddWithValue("@updatedBy", "system");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateAppointment(int apptId, int customerId, int userId,
        string title, string description, string location, string type,
        string contact, DateTime startUtc, DateTime endUtc)
        {
            string sql = @"
        UPDATE appointment
        SET customerId = @customerId,
            userId = @userId,
            title = @title,
            description = @description,
            location = @location,
            contact = @contact,
            type = @type,
            url = @url,
            start = @start,
            end = @end,
            lastUpdate = NOW(),
            lastUpdateBy = @updatedBy
        WHERE appointmentId = @id;";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", apptId);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@url", "");
                cmd.Parameters.AddWithValue("@start", startUtc);
                cmd.Parameters.AddWithValue("@end", endUtc);
                cmd.Parameters.AddWithValue("@updatedBy", "system");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static bool HasOverlappingAppointment(int userId, DateTime startUTC, DateTime endUTC, int excludeApptId = -1)
        {
            string sql = @"
        SELECT COUNT(*) 
        FROM appointment
        WHERE userId = @userId
          AND appointmentId <> @excludeId
          AND (
                (start < @end AND end > @start)
              );
    ";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@start", startUTC);
                cmd.Parameters.AddWithValue("@end", endUTC);
                cmd.Parameters.AddWithValue("@excludeId", excludeApptId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }


        public static Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appt = null;

            string sql = @"
        SELECT 
            a.appointmentId,
            a.customerId,
            c.customerName,
            a.userId,
            a.title,
            a.description,
            a.location,
            a.contact,
            a.type,
            a.start,
            a.end
        FROM appointment a
        JOIN customer c ON a.customerId = c.customerId
        WHERE a.appointmentId = @appointmentId;
    ";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        appt = new Appointment
                        {
                            AppointmentId = reader.GetInt32("appointmentId"),
                            CustomerId = reader.GetInt32("customerId"),
                            CustomerName = reader.GetString("customerName"),
                            UserId = reader.GetInt32("userId"),
                            Title = reader.GetString("title"),
                            Description = reader.GetString("description"),
                            Location = reader.GetString("location"),
                            Contact = reader.GetString("contact"),
                            Type = reader.GetString("type"),
                            StartUTC = reader.GetDateTime("start"),
                            EndUTC = reader.GetDateTime("end")
                        };
                    }
                }
            }

            return appt;
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

        public static void DeleteAppointment(int appointmentId)
        {
            string sql = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
