using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using System.Net.Http;
using eRestoran.Data.Models;

namespace eRestoran.Client
{
    public partial class RezervacijeControl : UserControl
    {
        public WebAPIHelper postOznaciSto = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/oznacisto");
        public WebAPIHelper postOslobodiSto = new WebAPIHelper(Resources.apiUrlDevelopment, "api/post/oslobodisto");
        public WebAPIHelper getStolove = new WebAPIHelper(Resources.apiUrlDevelopment, "api/get/stolovi");
        private Color zauzetiStoColor = Color.FromArgb(60, 255, 1, 1);
        public bool IsRezervacija = false;
        List<Sto> stolovi { get; set; }

        public RezervacijeControl(bool isRezervacija)
        {
            IsRezervacija = isRezervacija;
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

        private void BindControlsAndData()
        {
            var x = btnSto1;
            this.Refresh();
            var responseMessage = getStolove.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                stolovi = responseMessage.Content.ReadAsAsync<List<Sto>>().Result;
                foreach (var sto in stolovi)
                {
                    if (!sto.IsSlobodan)
                    {
                        var btnSto = Controls.Find("btnSto" + sto.RedniBroj, false)[0];
                        btnSto.BackColor = zauzetiStoColor;
                    }
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
        }
    }
}
