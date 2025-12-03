using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace cSharpScheduler
{
    public partial class AddModifyCustomerForm : Form
    {
        private bool _isModify = false;
        private int _customerId;

        public AddModifyCustomerForm()
        {
            InitializeComponent();
            _isModify = false;
            lblCustomerTitle.Text = "Add Customer";   // change your label name if needed
        }
        public AddModifyCustomerForm(int customerId)
        {
            InitializeComponent();
            _isModify = true;
            _customerId = customerId;

            lblCustomerTitle.Text = "Modify Customer";
            LoadCustomerData(customerId);
        }

        private void LoadCustomerData(int customerId)
        {
            var c = CustomerDB.GetCustomerById(customerId);

            txtName.Text = c.Name;
            txtAddress.Text = c.Address;
            txtAddress2.Text = c.Address2;
            txtPostal.Text = c.PostalCode;
            txtPhone.Text = c.Phone;
        }


        private void btnAddCustomerSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerFields())
                return;

            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string address2 = txtAddress2.Text.Trim();
            string postal = txtPostal.Text.Trim();
            string phone = txtPhone.Text.Trim();

            try
            {
                if (_isModify)
                {
                    CustomerDB.UpdateCustomer(_customerId, name, address, address2, postal, phone);
                    MessageBox.Show("Customer updated successfully.");
                }
                else
                {
                    CustomerDB.AddCustomer(name, address, address2, postal, phone);
                    MessageBox.Show("Customer added successfully.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customer: " + ex.Message);
            }
        }

        private bool ValidateCustomerFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPostal.Text))
            {
                MessageBox.Show("Postal Code cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number cannot be empty.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text.Trim(), @"^[0-9-]+$"))
            {
                MessageBox.Show("Phone number may contain only digits and dashes.");
                return false;
            }

            return true;
        }

        private void btnAddCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

