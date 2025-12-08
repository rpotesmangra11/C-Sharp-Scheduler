using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpScheduler
{
    public partial class AddModifyAppointmentForm : Form
    {
        private int _userId;
        private int _customerId;
        private string _customerName;
        private int _appointmentId;
        private bool _isModify;

        public AddModifyAppointmentForm(int userId, int customerId, string customerName)
        {
            InitializeComponent();
            _userId = userId;
            _customerId = customerId;
            _customerName = customerName;
            _isModify = false;

            LoadCustomerInfo();
            ConfigureDateTimePickers();
        }

        public AddModifyAppointmentForm(int appointmentId, int userId, bool isModify)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _userId = userId;
            _isModify = isModify;

            txtName.Enabled = false;
            txtName.TabStop = false;

            LoadAppointmentInfo();
            ConfigureDateTimePickers();
        }

        private void LoadCustomerInfo()
        {
            txtName.Text = _customerName;
            txtName.Enabled = false;
            txtName.TabStop = false;
        }

        private void LoadAppointmentInfo()
        {
            var appt = AppointmentsDB.GetAppointmentById(_appointmentId);

            _customerId = appt.CustomerId;
            _customerName = appt.CustomerName;

            txtName.Text = appt.CustomerName;
            txtTitle.Text = appt.Title;
            txtDescription.Text = appt.Description;
            txtLocation.Text = appt.Location;
            txtType.Text = appt.Type;
            txtContact.Text = appt.Contact;

            dtpStart.Value = appt.StartUTC.ToLocalTime();
            dtpEnd.Value = appt.EndUTC.ToLocalTime();
        }

        private void ConfigureDateTimePickers()
        {
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpStart.ShowUpDown = true;

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpEnd.ShowUpDown = true;

            if (!_isModify)
            {
                DateTime now = DateTime.Now;
                DateTime rounded = now.AddMinutes(30 - (now.Minute % 30));

                dtpStart.Value = rounded;
                dtpEnd.Value = rounded.AddMinutes(30);

                dtpStart.MinDate = DateTime.Now.Date;
                dtpEnd.MinDate = DateTime.Now.Date;
            }
        }

        private void btnApptSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtType.Text))
            {
                MessageBox.Show("Title and Type are required.");
                return;
            }

            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string location = txtLocation.Text.Trim();
            string type = txtType.Text.Trim();
            string contact = txtContact.Text.Trim();

            if (string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Contact is required.");
                return;
            }

            DateTime localStart = dtpStart.Value;
            DateTime localEnd = dtpEnd.Value;

            if (localStart >= localEnd)
            {
                MessageBox.Show("Start time must be earlier than end time.");
                return;
            }

            if (!ApptVerify.IsWithinBusinessHours(localStart, localEnd))
            {
                MessageBox.Show("Appointment must be between 9 AM and 5 PM EST, Monday–Friday.");
                return;
            }

            DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(localStart);
            DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(localEnd);

            if (_isModify)
            {
                if (AppointmentsDB.HasOverlappingAppointment(_userId, utcStart, utcEnd, _appointmentId))
                {
                    MessageBox.Show("This appointment overlaps with an existing appointment.");
                    return;
                }

                AppointmentsDB.UpdateAppointment(
                    _appointmentId, _customerId, _userId,
                    title, description, location, contact, type,
                    utcStart, utcEnd);

                MessageBox.Show("Appointment updated successfully.");
            }
            else
            {
                if (AppointmentsDB.HasOverlappingAppointment(_userId, utcStart, utcEnd))
                {
                    MessageBox.Show("This appointment overlaps with an existing appointment.");
                    return;
                }

                AppointmentsDB.AddAppointment(
                    _customerId, _userId,
                    title, description, location, contact, type,
                    utcStart, utcEnd);

                MessageBox.Show("Appointment added successfully.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnApptCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static class ApptVerify
        {
            public static bool IsWithinBusinessHours(DateTime localStart, DateTime localEnd)
            {
                TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                DateTime startEST = TimeZoneInfo.ConvertTime(localStart, estZone);
                DateTime endEST = TimeZoneInfo.ConvertTime(localEnd, estZone);

                if (startEST.DayOfWeek == DayOfWeek.Saturday ||
                    startEST.DayOfWeek == DayOfWeek.Sunday)
                    return false;

                TimeSpan open = new TimeSpan(9, 0, 0);
                TimeSpan close = new TimeSpan(17, 0, 0);

                return startEST.TimeOfDay >= open && endEST.TimeOfDay <= close;
            }
        }
    }
}
