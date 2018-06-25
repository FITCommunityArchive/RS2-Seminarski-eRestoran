using eRestoran.PCL.VM;
using eRestoran.Client.Properties;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
using FastFoodDemo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace eRestoran.Client
{
    public partial class Login : Form
    {
        public WebAPIHelper postLogin = new WebAPIHelper(Resources.apiUrlDevelopment, "api/korisnici/login");
        
        public Login()
        {
            InitializeComponent();
        }

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

        }
    }
}
