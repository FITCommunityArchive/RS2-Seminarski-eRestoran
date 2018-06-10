using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using System.Net.Http;
using eRestoran.Data.Models;
using eRestoran.Api.VM;
using FastFoodDemo;

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
            var responseMessage = getStolove.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                stolovi = responseMessage.Content.ReadAsAsync<List<StoloviRezervacijaVM>>().Result;
            }

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
                    // Dodati provjeru na kor ulogu
                    //btnSto.Enabled = false;
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
                            var response = postRezervisiSto.PostWithParametar(brojStola, DatumRezervacije.ToString("o"));
                            if (response.IsSuccessStatusCode)
                            {
                                btn.BackColor = zauzetiStoColor;
                                postCheckout.AddBearerToken(((Form1)this.ParentForm).VerifikovaniKorisnik.Token);
                                var response2 = postCheckout.PostWithParametar(brojStola, ((Form1)this.ParentForm).GetCartForCheckout());
                                if(response2.IsSuccessStatusCode)
                                MessageBox.Show("ok proslo");
                            }
                        }
                        else
                        {
                            var response = postIzbrisiRezervaciju.PostResponse(odabraniSto.RezervacijaId);
                            if (response.IsSuccessStatusCode)
                            {
                                btn.BackColor = Color.Transparent;
                                MessageBox.Show("ok proslo");
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
