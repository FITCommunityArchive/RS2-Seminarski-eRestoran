using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using eRestoran.Client.Shared.Helpers;
using System.Net.Http;
using eRestoran.Client.Properties;
using eRestoran.PCL.VM;

namespace FastFoodDemo
{
    public partial class LoginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public WebAPIHelper postLogin = new WebAPIHelper(Resources.apiUrlDevelopment, "api/korisnici/login");

        public LoginForm()
        {
            InitializeComponent();
            this.ActiveControl = txtEmail;
        }

        #region Events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var auth = new AuthVM()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };
            var resp = postLogin.PostResponse(auth);
            if (resp.IsSuccessStatusCode)
            {
                var verifikovaniKorisnik = resp.Content.ReadAsAsync<VerifikovanKorisnikVM>().Result;
                this.Hide();
                var form1 = new Form1(verifikovaniKorisnik);
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pogrešna šifra ili username.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li želite zatvoriti aplikaciju . Jeste li sigurni?", "Zatvori aplikaciju", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
    }
}
