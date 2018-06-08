using FastFoodDemo;
using System;
using System.Windows.Forms;

namespace eRestoran.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }
    }
}
