using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
using System.Net.Http;
using eRestoran.Client.Properties;
using eRestoran.PCL.VM;
using FastFoodDemo;
using Newtonsoft.Json;
using eRestoran.VM;
using System.Drawing;
using System.Net;
using System.IO;

namespace eRestoran.Client
{
    public partial class Promocija : UserControl
    {
        private WebAPIHelper korisnikPostService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PostZaposlenik");
        private WebAPIHelper korisnikPutService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PutZaposlenik");
        private WebAPIHelper getKorisniciService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/GetNaloge");
        private Zaposlenik model = new Zaposlenik();
        public Promocija()
        {
            InitializeComponent();
            BindComboBoxes();
        }

        public Promocija(string zaposlenikId)
        {
            InitializeComponent();
            BindComboBoxes();
            BindZaposlenik(zaposlenikId);
        }

        private void BindZaposlenik(string zaposlenikId)
        {
            HttpResponseMessage responseMessage = getKorisniciService.GetResponse(zaposlenikId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var zaposlenik = responseMessage.Content.ReadAsAsync<ZaposlenikVM>().Result;
                datumOdDate.Value = zaposlenik.DatumRodjenja;
                sifraTextBox.Text = zaposlenik.Ime;
                nazivProizvodaTextBox.Text = zaposlenik.Prezime;
                staraCijenaTextBox.Text = zaposlenik.Username;
                NaslovLabel.Text = "Uredivanje korisnika";
                promocijeCijenaTextBox.Text = zaposlenik.Password;
                model.Id = zaposlenik.Id;
            }
        }

        private void BindComboBoxes()
        {
            var statusi = System.Enum.GetValues(typeof(StatusZaposlenika));
            var tipoviKorisnika = System.Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>().ToList();
            tipoviKorisnika = tipoviKorisnika.Where(x => x != TipKorisnika.Klijent).ToList();
        }

        private void snimiKorbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (model.Id != 0)
                {
                    model.DatumRodjenja = datumOdDate.Value;
                    model.Ime = sifraTextBox.Text;
                    model.Password = promocijeCijenaTextBox.Text;
                    model.Prezime = nazivProizvodaTextBox.Text;
                    model.Username = staraCijenaTextBox.Text;

                    HttpResponseMessage responseMessage = korisnikPutService.PutResponse(model.Id, model);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Korisnik uspjesno uređen!");
                        var korisnickinalozi = new KorisnickiNalozi();
                        ((Form1)this.ParentForm).DodajKontrolu(korisnickinalozi);
                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske!");
                    }
                }
                else
                {
                    model = new Zaposlenik()
                    {
                        DatumRodjenja = datumOdDate.Value,
                        Ime = sifraTextBox.Text,
                        Password = promocijeCijenaTextBox.Text,
                        Prezime = nazivProizvodaTextBox.Text,
                        Username = staraCijenaTextBox.Text,
                    };
                    HttpResponseMessage responseMessage = korisnikPostService.PostResponse(model);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Korisnik uspjesno dodan!");
                        var korisnickinalozi = new KorisnickiNalozi();
                        ((Form1)this.ParentForm).DodajKontrolu(korisnickinalozi);
                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske!");
                    }
                }
            }
            
        }

        private void imeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(sifraTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(sifraTextBox, Messages.Univerzalno);
            }
        }

        private void prezimeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nazivProizvodaTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(nazivProizvodaTextBox, Messages.Univerzalno);
            }
        }

        private void usernamaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(staraCijenaTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(staraCijenaTextBox, Messages.Univerzalno);
            }
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(promocijeCijenaTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(promocijeCijenaTextBox, Messages.Univerzalno);
            }

        }

        private void datumRodjenjaDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (datumOdDate.Value.ToString() == "")
            {
                e.Cancel = true;
                errorProvider.SetError(datumOdDate, Messages.Univerzalno);
                datumOdDate.Focus();

            }
        }


        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        private void prikaziPronadjenjiProizvod(PonudaVM.PonudaInfo item)
        {
            toggleVisibility(true);
            nazivProizvodaTextBox.Text = item.Naziv;
            staraCijenaTextBox.Text = item.Cijena.ToString();
            //var sUrl = Resources.apiUrlDevelopment + item.imageUrl;
            //WebRequest req = WebRequest.Create(sUrl);

            //WebResponse res = req.GetResponse();

            //Stream imgStream = res.GetResponseStream();
            //slikaArtiklaPromocija.Image = new Bitmap(Image.FromStream(imgStream), new Size(120, 100));

        }

        private void toggleVisibility(bool isVisible)
        {
            nazivProizvodaLabel.Visible = isVisible;
            nazivProizvodaTextBox.Visible = isVisible;

            staraCijenaLabel.Visible = isVisible;
            staraCijenaTextBox.Visible = isVisible;

            promotivnaLabel.Visible = isVisible;
            promocijeCijenaTextBox.Visible = isVisible;

            datumOdLabel.Visible = isVisible;
            datumOdDate.Visible = isVisible;

            datumDoLabel.Visible = isVisible;
            datumDoDate.Visible = isVisible;

            slikaArtiklaPromocija.Visible = isVisible;
        }


        private void SearchArtikal_Click(object sender, EventArgs e)
        {
            var sifra = sifraTextBox.Text;
            var apiUrl = "";
            if (!String.IsNullOrEmpty(sifra))
            {
                apiUrl = "api/ponuda/GetProizvodBySifra/" + sifra;
                WebAPIHelper getProizvod = new WebAPIHelper(Resources.apiUrlDevelopment, apiUrl);
                HttpResponseMessage responseMessage = getProizvod.GetResponse();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    var item = JsonConvert.DeserializeObject<PonudaVM.PonudaInfo>(content);
                    if (item.Id.HasValue)
                    {
                        prikaziPronadjenjiProizvod(item);
                    } else
                    {
                        MessageBox.Show("Nazalost, ne postoji proizvod sa navedenom sifrom");

                    }

                }
            }
        }
    }
}
