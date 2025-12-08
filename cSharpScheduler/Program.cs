using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpScheduler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    int userId = login.LoggedInUserId;

                    Application.Run(new MainForm(userId));
                }
                else
                {
                    Application.Exit();
                }
            }

        }
    }
}
