using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
using System.Net.Http;
using eRestoran.Client.Properties;
using eRestoran.Api.VM;
using FastFoodDemo;

namespace eRestoran.Client
{
    public partial class DodajZaposlenika : UserControl
    {
        private WebAPIHelper korisnikPostService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PostZaposlenik");
        private WebAPIHelper korisnikPutService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PutZaposlenik");
        private WebAPIHelper getKorisniciService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/GetNaloge");
        private Zaposlenik model = new Zaposlenik();
        public DodajZaposlenika()
        {
            InitializeComponent();
            BindComboBoxes();
        }

        public DodajZaposlenika(string zaposlenikId)
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
                adresaTextBox.Text = zaposlenik.Adresa;
                datumZaposlenjaDateTimePicker.Value = zaposlenik.DatumZaposlenja;
                datumRodjenjaDateTimePicker.Value = zaposlenik.DatumRodjenja;
                emailTextBox.Text = zaposlenik.Email;
                imeTextBox.Text = zaposlenik.Ime;
                JMBGTextBox.Text = zaposlenik.JMBG;
                plataNumericUpDown.Value = (int)zaposlenik.Plata;
                prezimeTextBox.Text = zaposlenik.Prezime;
                statusComboBox.SelectedItem = zaposlenik.Status;
                telefonTextBox.Text = zaposlenik.Telefon;
                usernamaTextBox.Text = zaposlenik.Username;
                tipKorisnikaComboBox.SelectedItem = zaposlenik.TipKorisnika;
                NaslovLabel.Text = "Uredivanje korisnika";
                passwordTextBox.Text = zaposlenik.Password;
                model.Id = zaposlenik.Id;
            }
        }

        private void BindComboBoxes()
        {
            var statusi = System.Enum.GetValues(typeof(StatusZaposlenika));
            var tipoviKorisnika = System.Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>().ToList();
            tipoviKorisnika = tipoviKorisnika.Where(x => x != TipKorisnika.Klijent).ToList();
            statusComboBox.DataSource = statusi;
            tipKorisnikaComboBox.DataSource = tipoviKorisnika;
        }

        private void snimiKorbtn_Click(object sender, EventArgs e)
        {
            if (model.Id != 0)
            {
                   model.Adresa = adresaTextBox.Text;
                   model.DatumZaposlenja = datumZaposlenjaDateTimePicker.Value;
                   model.DatumRodjenja = datumRodjenjaDateTimePicker.Value;
                   model.Email = emailTextBox.Text;
                   model.Ime = imeTextBox.Text;
                   model.Jmbg = JMBGTextBox.Text;
                   model.Password = passwordTextBox.Text;
                   model.Plata = (double)plataNumericUpDown.Value;
                   model.Prezime = prezimeTextBox.Text;
                   model.Status = (StatusZaposlenika)statusComboBox.SelectedItem;
                   model.Telefon = telefonTextBox.Text;
                   model.Username = usernamaTextBox.Text;
                model.TipKorisnika = (TipKorisnika)tipKorisnikaComboBox.SelectedItem;

                HttpResponseMessage responseMessage = korisnikPutService.PutResponse(model.Id,model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Korisnik uspjesno uređen!");
                    var korisnickinalozi = new KorisnickiNalozi();
                    ((Form1)Form.ActiveForm).dodajKontrolu(korisnickinalozi);
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
                    Adresa = adresaTextBox.Text,
                    DatumZaposlenja = datumZaposlenjaDateTimePicker.Value,
                    DatumRodjenja = datumRodjenjaDateTimePicker.Value,
                    Email = emailTextBox.Text,
                    Ime = imeTextBox.Text,
                    Jmbg = JMBGTextBox.Text,
                    Password = passwordTextBox.Text,
                    Plata = (double)plataNumericUpDown.Value,
                    Prezime = prezimeTextBox.Text,
                    Status = (StatusZaposlenika)statusComboBox.SelectedItem,
                    Telefon = telefonTextBox.Text,
                    Username = usernamaTextBox.Text,
                    TipKorisnika = (TipKorisnika)tipKorisnikaComboBox.SelectedItem
                };
                HttpResponseMessage responseMessage = korisnikPostService.PostResponse(model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Korisnik uspjesno dodan!");
                    var korisnickinalozi = new KorisnickiNalozi();
                    ((Form1)Form.ActiveForm).dodajKontrolu(korisnickinalozi);
                }
                else
                {
                    MessageBox.Show("Doslo je do greske!");
                }
            }

            
        }
    }
}
