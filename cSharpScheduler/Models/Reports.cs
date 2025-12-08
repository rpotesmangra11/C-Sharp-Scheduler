using cSharpScheduler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public static class Reports
{
    public static DataTable GetAppointmentTypesByMonth()
    {
        DataTable appts = AppointmentsDB.GetAllAppointments();

        var query =
            from row in appts.AsEnumerable()
            let type = row.Field<string>("type")
            let start = row.Field<DateTime>("start")
            where !string.IsNullOrWhiteSpace(type)
            group row by new { Month = start.ToString("MMMM"), Type = type } into g
            select new
            {
                Month = g.Key.Month,
                Type = g.Key.Type,
                Count = g.Count()
            };

        return ToDataTable(query);
    }

    public static DataTable GetUserSchedules()
    {
        DataTable appts = AppointmentsDB.GetAllAppointments();

        var query =
            from row in appts.AsEnumerable()
            let userId = row.Field<int>("userId")
            let start = row.Field<DateTime>("start")
            let end = row.Field<DateTime>("end")
            select new
            {
                UserId = userId,
                Start = start.ToLocalTime(),
                End = end.ToLocalTime(),
                Type = row.Field<string>("type")
            };

        return ToDataTable(query);
    }

    public static DataTable GetTotalCustomerMeetings()
    {
        DataTable appts = AppointmentsDB.GetAllAppointments();  
        DataTable customers = CustomerDB.GetAllCustomers();       

        Dictionary<int, string> custNames = customers.AsEnumerable()
            .ToDictionary(r => r.Field<int>("customerId"),
                          r => r.Field<string>("customerName"));

        DataTable result = new DataTable();
        result.Columns.Add("Customer Name");
        result.Columns.Add("Meetings", typeof(int));

        var groups = appts.AsEnumerable()
            .GroupBy(r => r.Field<int>("customerId"))
            .Select(g => new
            {
                CustomerId = g.Key,
                Count = g.Count()
            });

        foreach (var g in groups)
        {
            string name = custNames.ContainsKey(g.CustomerId) ? custNames[g.CustomerId] : "Unknown";

            result.Rows.Add(name, g.Count);
        }

        return result;
    }

    private static DataTable ToDataTable<T>(IEnumerable<T> items)
    {
        var dt = new DataTable();
        var props = typeof(T).GetProperties();

        foreach (var p in props)
            dt.Columns.Add(p.Name);

        foreach (var item in items)
        {
            var row = dt.NewRow();
            foreach (var p in props)
                row[p.Name] = p.GetValue(item) ?? DBNull.Value;
            dt.Rows.Add(row);
        }

        return dt;
    }

}
