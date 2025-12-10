using cSharpScheduler;
using cSharpScheduler.Forms;
using cSharpScheduler.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpScheduler
{
    public partial class MainForm : Form
    {
        private int _userId;

        public MainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            CheckUpcomingAppointments(_userId);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();         
            LoadAllAppointments();   

            dgvCustomers.ClearSelection();
            dgvAppts.ClearSelection();
            dgvCustomers.CurrentCell = null;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvAppts.RowHeadersVisible = false;
            dgvAppts.AllowUserToAddRows = false;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            dgvCustomers.Columns["customerId"].HeaderText = "Customer ID";
            dgvCustomers.Columns["customerName"].HeaderText = "Customer Name";
            dgvCustomers.Columns["address"].HeaderText = "Address";
            dgvCustomers.Columns["postalCode"].HeaderText = "Postal Code";
            dgvCustomers.Columns["phone"].HeaderText = "Phone";
            dgvCustomers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCustomers.Font, FontStyle.Bold);
            dgvCustomers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor;
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor;
            dgvCustomers.EnableHeadersVisualStyles = false;


            //Appointment
            dgvAppts.Columns["url"].Visible = false;
            dgvAppts.Columns["appointmentId"].HeaderText = "Appointment ID";
            dgvAppts.Columns["customerId"].HeaderText = "Customer ID";
            dgvAppts.Columns["userId"].HeaderText = "User ID";
            dgvAppts.Columns["title"].HeaderText = "Title";
            dgvAppts.Columns["description"].HeaderText = "Description";
            dgvAppts.Columns["location"].HeaderText = "Location";
            dgvAppts.Columns["contact"].HeaderText = "Contact";
            dgvAppts.Columns["type"].HeaderText = "Type";
            dgvAppts.Columns["start"].HeaderText = "Start Date";
            dgvAppts.Columns["end"].HeaderText = "End Date";
            dgvAppts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAppts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAppts.Font, FontStyle.Bold);
            dgvAppts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAppts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAppts.ScrollBars = ScrollBars.Both;
            dgvAppts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppts.MultiSelect = false;
            dgvAppts.ReadOnly = true;
            dgvAppts.AllowUserToAddRows = false;
            dgvAppts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAppts.Columns["start"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
            dgvAppts.Columns["end"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
            dgvAppts.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvAppts.ColumnHeadersDefaultCellStyle.BackColor;
            dgvAppts.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgvAppts.ColumnHeadersDefaultCellStyle.ForeColor;
            dgvAppts.EnableHeadersVisualStyles = false;
            dgvAppts.AllowUserToAddRows = false;

        }



        private void LoadCustomers()
        {
            DataTable dt = CustomerDB.GetAllCustomers();
            dgvCustomers.DataSource = dt;

        }

        private void LoadAllAppointments()
        {
            var dt = AppointmentsDB.GetAllAppointments();

            foreach (DataRow row in dt.Rows)
            {
                row["start"] = ((DateTime)row["start"]).ToLocalTime();
                row["end"] = ((DateTime)row["end"]).ToLocalTime();
            }

            dgvAppts.DataSource = dt;

        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int customerId = Convert.ToInt32(
                dgvCustomers.Rows[e.RowIndex].Cells["customerId"].Value
            );

            LoadAppointmentsByCustomer(customerId);
        }

        private void LoadAppointmentsByCustomer(int customerId)
        {
            DataTable dt = AppointmentsDB.GetAppointmentsByCustomer(customerId);
            dgvAppts.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (var form = new AddModifyCustomerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {                   
                    LoadCustomers();
                    dgvCustomers.ClearSelection();
                }
            }
        }

        private void btnModCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["customerId"].Value);

            using (var form = new AddModifyCustomerForm(customerId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        private void btnDelCustomer_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["customerId"].Value);

            if (MessageBox.Show("Are you sure you want to delete this customer?",
                                "Confirm Deletion",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = CustomerDB.DeleteCustomer(customerId);

                if (success)
                    MessageBox.Show("Customer successfully deleted.");
                else
                    MessageBox.Show("Problem deleting customer.");

                LoadCustomers();
            }
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            using (var form = new CalendarForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        private void CheckUpcomingAppointments(int userId)
        {
            DataTable upcoming = AppointmentsDB.GetUpcomingAppointments(userId);

            if (upcoming.Rows.Count == 0)
            {
                MessageBox.Show("You have no appointments within the next 15 minutes.");
                return;
            }

            StringBuilder alert = new StringBuilder();
            alert.AppendLine("Upcoming appointments within 15 minutes:");

            foreach (DataRow row in upcoming.Rows)
            {
                DateTime utcStart = (DateTime)row["start"];
                DateTime localStart = utcStart.ToLocalTime();

                alert.AppendLine(
                    $"• Appointment ID {row["appointmentId"]}, starts at {localStart:MM/dd/yyyy hh:mm tt}"
                );
            }

            MessageBox.Show(alert.ToString(), "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAddAppt_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["customerId"].Value);
            string customerName = dgvCustomers.CurrentRow.Cells["customerName"].Value.ToString();

            AddModifyAppointmentForm addForm = new AddModifyAppointmentForm(_userId, customerId, customerName);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllAppointments();
            }
        }

        private void btnModAppt_Click(object sender, EventArgs e)
        {
            if (dgvAppts.CurrentRow == null)
            {
                MessageBox.Show("Please select an appointment to modify.");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppts.CurrentRow.Cells["appointmentId"].Value);

            AddModifyAppointmentForm modifyForm =
                new AddModifyAppointmentForm(appointmentId, _userId, true);

            if (modifyForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllAppointments();   // refresh dgv
                MessageBox.Show("Appointment updated successfully.");
            }
        }

        private void btnDeleteAppt_Click(object sender, EventArgs e)
        {
            if (dgvAppts.CurrentRow == null)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppts.CurrentRow.Cells["appointmentId"].Value);
            string apptType = dgvAppts.CurrentRow.Cells["type"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this appointment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            AppointmentsDB.DeleteAppointment(appointmentId);

            LoadAllAppointments();

            MessageBox.Show($"Appointment deleted.");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm form = new ReportsForm();
            form.Show();
        }
    }
}


