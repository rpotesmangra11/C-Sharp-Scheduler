using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpScheduler
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
            this.Load += CalendarForm_Load;
        }

        private void CalendarForm_Load(object sender, EventArgs e)
        {
            FormatCalendarColumns();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadAppointmentsForDay(e.Start);
        }

        private void FormatCalendarColumns()
        {
            SetHeaderIfExists("Customer", "Customer Name");
            SetHeaderIfExists("Type", "Type");
            SetHeaderIfExists("Location", "Location");
            SetHeaderIfExists("Contact", "Contact");
            SetHeaderIfExists("Start", "Start Date");
            SetHeaderIfExists("End", "End Date");

            if (dgvCalendar.Columns.Contains("Start"))
                dgvCalendar.Columns["Start"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";

            if (dgvCalendar.Columns.Contains("End"))
                dgvCalendar.Columns["End"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";

            dgvCalendar.ReadOnly = true;
            dgvCalendar.MultiSelect = false;
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendar.AllowUserToAddRows = false;

            dgvCalendar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCalendar.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCalendar.Font, FontStyle.Bold);
            dgvCalendar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCalendar.ScrollBars = ScrollBars.Both;

            dgvCalendar.EnableHeadersVisualStyles = false;

            dgvCalendar.ClearSelection();
            dgvCalendar.CurrentCell = null;
            dgvCalendar.RowHeadersVisible = false;

        }


        private void SetHeaderIfExists(string columnName, string headerText)
        {
            if (dgvCalendar.Columns.Contains(columnName))
                dgvCalendar.Columns[columnName].HeaderText = headerText;
        }

        private void LoadAppointmentsForDay(DateTime date)
        {
            DataTable appointments = AppointmentsDB.GetAppointmentsByDate(date);
            dgvCalendar.DataSource = appointments;

            FormatCalendarColumns();

            if (appointments.Rows.Count == 0)
            {
                dgvCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                txtCalendarDesc.Text = "No appointments for this day.";
            }
            else
            {
                dgvCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                txtCalendarDesc.Text = $"{appointments.Rows.Count} appointment(s) found for this day.";
            }

            dgvCalendar.ClearSelection();
            dgvCalendar.CurrentCell = null;
        }



        private void btnCalendarBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
