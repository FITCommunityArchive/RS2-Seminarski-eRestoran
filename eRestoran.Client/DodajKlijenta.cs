using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoran.Data.Models;
using System.Net.Http;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using eRestoran.Api.VM;
using FastFoodDemo;

namespace eRestoran.Client
{
    public partial class DodajKlijenta : UserControl
    {
        private WebAPIHelper klijentPostService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PostKlijent");
        private WebAPIHelper klijentPutService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PutKlijent");
        private WebAPIHelper klijentdeleteService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/DeleteKlijent");
        private WebAPIHelper getKlijentaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/GetNalogeKlijent");
        private Klijent model = new Klijent();
        public DodajKlijenta()
        {
            InitializeComponent();


        }
        public DodajKlijenta(string klijentId)
        {
            InitializeComponent();
            BindKlijent(klijentId);


        }

        private void BindKlijent(string klijentid)
        {
            HttpResponseMessage responseMessage = getKlijentaService.GetResponse(klijentid);
            if (responseMessage.IsSuccessStatusCode)
            {
                var klijent = responseMessage.Content.ReadAsAsync<KlijentVM>().Result;

                emailTextBox.Text = klijent.Email;
                imeTextBox.Text = klijent.Ime;
                prezimeTextBox.Text = klijent.Prezime;
                telefonTextBox.Text = klijent.Telefon;
                usernamaTextBox.Text = klijent.Username;
                NaslovLabel.Text = "Uredivanje klijenta";
                passwordTextBox.Text = klijent.Password;
                model.Id = klijent.Id;
            }
            }
        private void ClearForm() {
            emailTextBox.ResetText();
            imeTextBox.ResetText();
            prezimeTextBox.ResetText();
            telefonTextBox.ResetText(); 
            usernamaTextBox.ResetText();
            passwordTextBox.ResetText(); 
        }                                             

        private void snimiKorbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (model.Id != 0)
                {
                    model.Email = emailTextBox.Text;
                    model.Ime = imeTextBox.Text;
                    model.Password = passwordTextBox.Text;
                    model.Prezime = prezimeTextBox.Text;
                    model.Username = usernamaTextBox.Text;
                    model.TipKorisnika = TipKorisnika.Klijent;
                    model.DatumPrijave = DateTime.Now;
                    model.Telefon = telefonTextBox.Text;

                    HttpResponseMessage responseMessage = klijentPutService.PutResponse(model.Id, model);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Klijent uspjesno uređen!");
                        ClearForm();
                        var korisnickinalozi = new KorisnickiNalozi();
                        ((Form1)Form.ActiveForm).DodajKontrolu(korisnickinalozi);

                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske!");
                    }
                }
                else
                {
                    model = new Klijent()
                    {
                        Email = emailTextBox.Text,
                        Ime = imeTextBox.Text,
                        Password = passwordTextBox.Text,
                        Prezime = prezimeTextBox.Text,
                        Username = usernamaTextBox.Text,
                        TipKorisnika = TipKorisnika.Klijent,
                        DatumPrijave = DateTime.Now,
                        Telefon = telefonTextBox.Text
                    };
                    HttpResponseMessage responseMessage = klijentPostService.PostResponse(model);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Klijent uspjesno dodan!");
                        ClearForm();
                        var korisnickinalozi = new KorisnickiNalozi();
                        ((Form1)Form.ActiveForm).DodajKontrolu(korisnickinalozi);

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

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(emailTextBox, Messages.Univerzalno);
            }
            if (!IsValidEmail(emailTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(emailTextBox, Messages.NeispravanEmail);
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
