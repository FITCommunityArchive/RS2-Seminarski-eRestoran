using eRestoran.Client.Properties;
using eRestoran.Client.Shared.Helpers;
using eRestoran.PCL.VM;
using FastFoodDemo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace eRestoran.Client
{
    public partial class Stolovi : UserControl
    {
        public WebAPIHelper postOznaciSto = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/oznacisto");
        public WebAPIHelper postOslobodiSto = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/oslobodisto");
        public WebAPIHelper getStolove = new WebAPIHelper(Resources.apiUrlDevelopment, "api/get/stolovi");
        public WebAPIHelper getRezervacijeStolova = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/rezervacijestolova");
        public WebAPIHelper postRezervisiSto = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/rezervisi");
        public WebAPIHelper getOsvjeziStolove = new WebAPIHelper(Resources.apiUrlDevelopment, "api/get/osvjezistolove");
        public WebAPIHelper postIzbrisiRezervaciju = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/izbrisirezervaciju");
        public WebAPIHelper postCheckout = new WebAPIHelper(Resources.apiUrlDevelopment, "api/checkout");

        private Color zauzetiStoColor = Color.FromArgb(60, 255, 1, 1);
        List<StoloviRezervacijaVM> stolovi { get; set; }
        public DateTime DatumRezervacije = DateTime.Now;

        public Stolovi()
        {
            InitializeComponent();

            BindControlsAndData();
            BindEvents();
        }

        private void BindEvents()
        {
            foreach (Control item in this.Controls)
            {
                item.Click += odabirStola;
            }
        }

        public void BindControlsAndData()
        {
            var response = getRezervacijeStolova.PostResponse(DatumRezervacije.ToString("o"));
            if (response.IsSuccessStatusCode)
            {
                stolovi = response.Content.ReadAsAsync<List<StoloviRezervacijaVM>>().Result;
            }
            foreach (var sto in stolovi)
            {
                var btnSto = Controls.Find("btnSto" + sto.RedniBrojStola, false)[0];

                if (!sto.IsSlobodan)
                {
                    btnSto.BackColor = zauzetiStoColor;
                }
                else
                {
                    btnSto.Enabled = true;
                    btnSto.BackColor = Color.Transparent;
                }
            }
        }

        private void odabirStola(object sender, EventArgs e)
        {
            if (sender != null && sender is Button btn)
            {
                if (int.TryParse(btn.Text, out var brojStola))
                {
                    var odabraniSto = stolovi.FirstOrDefault(x => x.RedniBrojStola == brojStola);
                    if (DatumRezervacije != DateTime.MinValue) // uvijek razlicito
                    {
                        if (odabraniSto.IsSlobodan)
                        {
                            btn.BackColor = zauzetiStoColor;
                            postCheckout.AddBearerToken(((Form1)this.ParentForm).VerifikovaniKorisnik.Token);
                            CartIndexVM cartItems = ((Form1)this.ParentForm).GetCartForCheckout();
                            var response2 = postCheckout.PostWithParametar(brojStola, cartItems);
                            if (response2.IsSuccessStatusCode)
                            {
                                var response = postRezervisiSto.PostWithParametar(brojStola, DatumRezervacije.ToString("o"));

                                MessageBox.Show("Uspjesno obavljena rezervacija.");
                            }
                            else
                            {
                                MessageBox.Show("Neuspjesno obavljena rezervacija, morate dodati artikle u korpu.");
                            }
                        }
                        else
                        {
                            var response = postIzbrisiRezervaciju.PostResponse(odabraniSto.RezervacijaId);
                            if (response.IsSuccessStatusCode)
                            {
                                btn.BackColor = Color.Transparent;
                                MessageBox.Show("Uspjesno izbrisana rezervacija");
                            }
                        }
                        odabraniSto.IsSlobodan = !odabraniSto.IsSlobodan;
                    }
                }

                BindControlsAndData();
            }
        }
    }
}
