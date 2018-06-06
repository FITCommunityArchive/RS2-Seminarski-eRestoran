using eRestoran.Api.VM;
using eRestoran.Client.Properties;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
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
        public WebAPIHelper get = new WebAPIHelper(Resources.apiUrlDevelopment, "api/get/stolovi");


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
                get.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", verifikovaniKorisnik.Token);
                var resp2 = get.GetResponse();
                if (resp2.IsSuccessStatusCode)
                {
                    var stolovi = resp2.Content.ReadAsAsync<List<Sto>>().Result;
                }
            }

        }
    }
}
