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
            if (this.ValidateChildren())
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
            if (String.IsNullOrEmpty(imeTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(imeTextBox, Messages.Univerzalno);
            }
        }

        private void prezimeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(prezimeTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(prezimeTextBox, Messages.Univerzalno);
            }
        }

        private void usernamaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(usernamaTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(usernamaTextBox, Messages.Univerzalno);
            }
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(passwordTextBox, Messages.Univerzalno);
            }

        }

        private void datumRodjenjaDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (datumRodjenjaDateTimePicker.Value.ToString() == "")
            {
                e.Cancel = true;
                errorProvider.SetError(datumRodjenjaDateTimePicker, Messages.Univerzalno);
                datumRodjenjaDateTimePicker.Focus();

            }
        }

        private void tipKorisnikaComboBox_Validating(object sender, CancelEventArgs e)
        {
            if ((int)tipKorisnikaComboBox.SelectedValue == 0)
            {
                errorProvider.SetError(tipKorisnikaComboBox, "Morate odabrati tip korisnika.");
                e.Cancel = true;

            }
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(emailTextBox, Messages.Univerzalno);
            }
            if (!IsValidEmail(emailTextBox.Text)) {
                e.Cancel = true;
                errorProvider.SetError(emailTextBox, Messages.NeispravanEmail);
            }
           

        }

        private void datumZaposlenjaDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (datumZaposlenjaDateTimePicker.Value.ToString() == "")
            {
                e.Cancel = true;
                errorProvider.SetError(datumZaposlenjaDateTimePicker, Messages.Univerzalno);
                datumZaposlenjaDateTimePicker.Focus();
               
            }
        }

        private void JMBGTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(JMBGTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(JMBGTextBox, Messages.Univerzalno);
            }
        }

        private void adresaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(adresaTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(adresaTextBox, Messages.Univerzalno);
            }
        }

        private void plataNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(plataNumericUpDown.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(plataNumericUpDown, Messages.Univerzalno);
            }
            else
            {
                if (plataNumericUpDown.Text.Contains(","))
                {
                    e.Cancel = true;
                    plataNumericUpDown.Focus();
                    errorProvider.SetError(plataNumericUpDown, Messages.Cijena_zarez);
                }
                if (plataNumericUpDown.Text.Contains("-"))
                {
                    e.Cancel = true;
                    plataNumericUpDown.Focus();
                    errorProvider.SetError(plataNumericUpDown, Messages.NegVrijednost);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(plataNumericUpDown.Text, "\\d+(\\.\\d{1,2})?"))
                {
                    e.Cancel = true;
                    plataNumericUpDown.Focus();
                    errorProvider.SetError(plataNumericUpDown, Messages.Cijena_decimale);
                }

            }
        }

        private void statusComboBox_Validating(object sender, CancelEventArgs e)
        {
            if ((int)statusComboBox.SelectedValue == 0)
            {
                errorProvider.SetError(statusComboBox, "Morate odabrati status korisnika.");
                e.Cancel = true;

            }
        }

        private void telefonTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(telefonTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(telefonTextBox, Messages.Univerzalno);
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
    }
}
