using cSharpScheduler.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace cSharpScheduler
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            DetectLocation();
            lblError.Visible = false;

        }

        private void DetectLocation()
        {
            RegionInfo region = new RegionInfo(CultureInfo.CurrentCulture.Name);

            lblRegion.Text = "Region: " + region.EnglishName;
        }

        private string language = "en";

        private string Translate(string key)
        {
            // English messages
            if (language == "en")
            {
                if (key == "LoginFailed") return "The username and password do not match.";
                if (key == "EmptyFields") return "Username and Password cannot be blank.";
                if (key == "Success") return "Login successful!";
            }

            // Spanish messages
            if (language == "es")
            {
                if (key == "LoginFailed") return "El nombre de usuario y la contraseña no coinciden.";
                if (key == "EmptyFields") return "Por favor ingrese nombre de usuario y contraseña.";
                if (key == "Success") return "¡Inicio de sesión exitoso!";
            }

            return "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                lblError.Text = Translate("EmptyFields");
                lblError.Visible = true;
                return;
            }

            bool isValid = UserDB.ValidateLogin(user, pass);

            if (!isValid)
            {
                lblError.Text = Translate("LoginFailed");
                lblError.Visible = true;
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

