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
            comboLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLanguage.SelectedItem.ToString() == "Spanish")
                language = "es";
            else
                language = "en";

            ApplyLanguage();
        }

        private void DetectLocation()
        {
            RegionInfo region = new RegionInfo(CultureInfo.CurrentCulture.Name);
            TimeZoneInfo localZone = TimeZoneInfo.Local;

            string regionLabel = Translate("Region");
            string timeZoneLabel = Translate("TimeZone");

            string regionName = GetLocalizedRegionName(region);

            lblRegion.Text =
                $"{regionLabel}: {regionName}{Environment.NewLine}" +
                $"{timeZoneLabel}: {GetLocalizedTimeZoneName(localZone)}";
        }
        private string GetLocalizedTimeZoneName(TimeZoneInfo zone)
        {
            if (language == "es")
            {
                if (zone.Id == "Eastern Standard Time")
                    return "Hora estándar del este";
                if (zone.Id == "Central Standard Time")
                    return "Hora estándar central";
                if (zone.Id == "Mountain Standard Time")
                    return "Hora estándar de la montaña";
                if (zone.Id == "Pacific Standard Time")
                    return "Hora estándar del Pacífico";
            }

            return zone.StandardName;
        }

        private string GetLocalizedRegionName(RegionInfo region)
        {
            if (language == "es")
            {
                if (region.TwoLetterISORegionName == "US")
                    return "Estados Unidos";
                if (region.TwoLetterISORegionName == "ES")
                    return "España";
            }

            return region.EnglishName;
        }


        private string language = "en";

        private string Translate(string key)
        {
            if (language == "en")
            {
                if (key == "Login") return "Login";
                if (key == "Exit") return "Exit";
                if (key == "Username") return "Username";
                if (key == "Password") return "Password";
                if (key == "Region") return "Region";
                if (key == "TimeZone") return "Time Zone";

                if (key == "LoginFailed") return "The username and password do not match.";
                if (key == "EmptyFields") return "Username and Password cannot be blank.";
                if (key == "Success") return "Login successful!";
            }

            if (language == "es")
            {
                if (key == "Login") return "Iniciar sesión";
                if (key == "Exit") return "Salir";
                if (key == "Username") return "Nombre de\nusuario";
                if (key == "Password") return "Contraseña";
                if (key == "Region") return "Región";
                if (key == "TimeZone") return "Zona horaria";

                if (key == "LoginFailed") return "El nombre de usuario y la contraseña no coinciden.";
                if (key == "EmptyFields") return "Por favor ingrese nombre de usuario y contraseña.";
                if (key == "Success") return "¡Inicio de sesión exitoso!";
            }

            return "";
        }

        private void ApplyLanguage()
        {
            btnLogin.Text = Translate("Login");
            btnLoginExit.Text = Translate("Exit");
            lblUsername.Text = Translate("Username");
            lblPassword.Text = Translate("Password");

            DetectLocation();
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

