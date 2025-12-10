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
using System.IO;


namespace cSharpScheduler
{
    public partial class LoginForm : Form
    {
        public int LoggedInUserId { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            DetectLocation();
            lblError.Visible = false;
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboLanguage.Items.Add("English");
            comboLanguage.Items.Add("Spanish");
            comboLanguage.SelectedIndex = 0;
        }

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLanguage.SelectedItem.ToString() == "Spanish")
                language = "es";
            else
                language = "en";
        }

        private void DetectLocation()
        {
            RegionInfo region = new RegionInfo(CultureInfo.CurrentCulture.Name);
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            lblRegion.Text =
            $"Region: {region.EnglishName}{Environment.NewLine}" +
            $"Time Zone: {localZone.StandardName}";
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

            lblError.Visible = false;

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

            LoggedInUserId = UserDB.GetUserId(user);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string logFile = Path.Combine(desktopPath, "Login_Audit.txt");
            string logEntry = $"{DateTime.Now}: {user} logged in";
            File.AppendAllText(logFile, logEntry + Environment.NewLine);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

