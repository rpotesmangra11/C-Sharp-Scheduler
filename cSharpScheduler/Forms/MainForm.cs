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
using MySql.Data.MySqlClient;

namespace cSharpScheduler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            dgvAppts.Columns["appointmentId"].HeaderText = "Appointment ID";
            dgvAppts.Columns["customerId"].HeaderText = "Customer ID";
            dgvAppts.Columns["userId"].HeaderText = "User ID";
            dgvAppts.Columns["title"].HeaderText = "Title";
            dgvAppts.Columns["description"].HeaderText = "Description";
            dgvAppts.Columns["location"].HeaderText = "Location";
            dgvAppts.Columns["contact"].HeaderText = "Contact";
            dgvAppts.Columns["type"].HeaderText = "Type";
            dgvAppts.Columns["url"].HeaderText = "URL";
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
            DataTable dt = AppointmentsDB.GetAllAppointments();
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
    }
}
