using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpScheduler.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void btnUserSchedules_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = Reports.GetUserSchedules();
            FormatReportsGrid();
        }

        private void btnTotalMeetingsByCustomer_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = Reports.GetTotalCustomerMeetings();
            FormatReportsGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNumApptTypes_Click(object sender, EventArgs e)
        {
            var report = Reports.GetAppointmentTypesByMonth();
            dgvReports.DataSource = report;
            FormatReportsGrid();
        }
        private void FormatReportsGrid()
        {
            if (dgvReports.Columns.Count == 0)
                return;

            dgvReports.RowHeadersVisible = false; // remove first blank column

            dgvReports.AllowUserToAddRows = false;
            dgvReports.ReadOnly = true;

            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.MultiSelect = false;

            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font(dgvReports.Font, FontStyle.Bold);

            dgvReports.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvReports.EnableHeadersVisualStyles = false;

            dgvReports.ClearSelection();
        }


    }
}

