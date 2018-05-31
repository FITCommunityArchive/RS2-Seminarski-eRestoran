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

        private Color zauzetiStoColor = Color.FromArgb(60, 255, 1, 1);
        List<Sto> stolovi { get; set; }
        List<StoloviRezervacijaVM> sviStolovi { get; set; }
        public DateTime DatumRezervacije { get; set; }

        public Stolovi()
        {
            InitializeComponent();
            var responseMessage = getStolove.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                stolovi = responseMessage.Content.ReadAsAsync<List<Sto>>().Result;
            }
            if (DatumRezervacije != DateTime.MinValue)
            {
                ProvjeriRezervacije();
                BindControlsAndData(true);
            }

            BindControlsAndData(false);
            BindEvents();
        }

        private void BindEvents()
        {
            foreach (Control item in this.Controls)
            {
                item.Click += odabirStola;
            }
        }

        public void ProvjeriRezervacije()
        {
            var response = getRezervacijeStolova.PostResponse(DatumRezervacije.ToString("o"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("USPJESNA PROVJERA");
                stolovi = response.Content.ReadAsAsync<List<Sto>>().Result;
                BindControlsAndData(true);
            }
        }

        private void BindControlsAndData(bool isRezervacija)
        {
            getOsvjeziStolove.GetResponse();

            foreach (var sto in stolovi)
            {
                var btnSto = Controls.Find("btnSto" + sto.RedniBroj, false)[0];

                if (!sto.IsSlobodan)
                {
                    if (isRezervacija)
                    {
                        btnSto.Enabled = false;
                    }
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
                    var odabraniSto = stolovi.FirstOrDefault(x => x.RedniBroj == brojStola);
                    if (DatumRezervacije != DateTime.MinValue) // uvijek razlicito
                    {
                        var response = postRezervisiSto.PostWithParametar(brojStola, DatumRezervacije.ToString("o"));
                        if (response.IsSuccessStatusCode)
                        {
                            btn.BackColor = zauzetiStoColor;
                            MessageBox.Show("ok proslo");
                        }
                    }
                    else
                    {
                        if (odabraniSto.IsSlobodan)
                        {
                            
                            var response = postOznaciSto.PostResponse(brojStola);
                            if (response.IsSuccessStatusCode)
                            {
                                btn.BackColor = zauzetiStoColor;
                                MessageBox.Show("ok proslo");
                            }
                        }
                        else
                        {
                            var response = postOslobodiSto.PostResponse(brojStola);
                            if (response.IsSuccessStatusCode)
                            {
                                btn.BackColor = Color.Transparent;
                                MessageBox.Show("ok proslo");
                            }
                        }
                        odabraniSto.IsSlobodan = !odabraniSto.IsSlobodan;
                    }
                }
                getOsvjeziStolove.GetResponse();
            }
        }
    }
}
