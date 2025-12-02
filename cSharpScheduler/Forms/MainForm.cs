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

            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvAppts.RowHeadersVisible = false;
            dgvAppts.AllowUserToAddRows = false;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
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
    }
}
