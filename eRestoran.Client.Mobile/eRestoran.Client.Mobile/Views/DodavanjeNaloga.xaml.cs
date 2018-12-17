using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodavanjeNaloga : ContentPage
    {
        private List<Entry> entries;
        public DodavanjeNaloga()
        {
            InitializeComponent();
            DatumZaposlenja.MinimumDate = DateTime.Now.AddYears(-40);
            entries = new List<Entry>()
            {
                Ime,
                Prezime,
                Jmbg,
                Adresa,
                Telefon,
                Email,
                Plata,
                Username,
                NovaLozinka,
                PonovljenaLozinka
            };
         
             var listaUloga = new List<string>();
            listaUloga.Add("Odaberite ulogu");
            listaUloga.Add("Admin");
            listaUloga.Add("Menadzer");
            listaUloga.Add("Klijent");
            listaUloga.Add("Konobar");
            listaUloga.Add("Kuhar");
            listaUloga.Add("Sanker");
            Uloga.ItemsSource = listaUloga;
            Uloga.SelectedIndex = 0;
        }

        private void SnimiKorisnika(object sender, System.EventArgs e)
        {
            if (!ProvjeriFormu())
                return;

            var korisnikPostService = new WebAPIHelper("api/Nalog/PostZaposlenik");

            var model = new NoviZaposlenik()
            {
                Adresa = Adresa.Text,
                DatumZaposlenja = DatumZaposlenja.Date,
                DatumRodjenja = DatumRodjenja.Date,
                Email = Email.Text,
                Ime = Ime.Text,
                Jmbg = Jmbg.Text,
                Password = NovaLozinka.Text,
                Plata = double.Parse(Plata.Text),
                Prezime = Prezime.Text,
                Status = StatusZaposlenikaPCL.Aktivan,
                Telefon = Telefon.Text,
                Username = Username.Text,
                TipKorisnika = (TipKorisnikaPCL)Uloga.SelectedIndex
            };

            var response = korisnikPostService.PostResponse(model);
            if (response.Result.IsSuccessStatusCode)
            {
                this.DisplayAlert("Info", "Uspjesno kreiran nalog!", "OK");
                ClearForm();
            }
            else
            {
                this.DisplayAlert("Info", "Zao nam je doslo je do greske. Pokusajte kasnije!", "OK");
            }
        }

        private void ClearForm() {
            Adresa.Text = "";
            DatumZaposlenja.Date = DateTime.Now;
            DatumRodjenja.Date = DateTime.Now;
            Email.Text = "";
            Ime.Text = "";
            Jmbg.Text = "";
            NovaLozinka.Text = "";
            PonovljenaLozinka.Text = "";
            Plata.Text = "";
            Prezime.Text = "";
            Telefon.Text = "";
            Username.Text = "";
            Uloga.SelectedIndex = 0;
        }

        private bool ValidateEmail(string email) {
            if (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }

        private bool ValidateDigits(string digits) {
            if (Regex.Match(digits, @"^\d+\.?\d*$").Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ProvjeriFormu()
        {
            foreach (var entry in entries)
            {
                if (string.IsNullOrWhiteSpace(entry.Text))
                {
                    entry.PlaceholderColor = Color.Red;
                    entry.Focus();
                    return false;
                }
                entry.StyleClass = new[] { "" };
            }

           

            if (!ValidateDigits(Jmbg.Text))
            {
                this.DisplayAlert("JMBG", "Molimo unesite samo brojeve", "OK");
                Jmbg.Focus();
                return false;
            }

            if (!ValidateDigits(Telefon.Text))
            {
                this.DisplayAlert("Telefon", "Molimo unesite samo brojeve", "OK");
                Telefon.Focus();
                return false;
            }

            if (!ValidateEmail(Email.Text))
            {
                this.DisplayAlert("Email", "Niste unijeli pravilan email", "OK");
                Email.Focus();
                return false;
            }

            if (!ValidateDigits(Plata.Text))
            {
                this.DisplayAlert("Plata", "Molimo unesite samo brojeve (. - delimitor)", "OK");
                Plata.Focus();
                return false;
            }


            if (NovaLozinka.Text != PonovljenaLozinka.Text)
            {
                this.DisplayAlert("Lozinka", "Ponovljena lozinka nije ista", "OK");
                PonovljenaLozinka.Focus();
                return false;
            }

            if (Uloga.SelectedIndex == 0)
            {
                Uloga.Focus();
                return false;
            }

            return true;
        }
    }
}