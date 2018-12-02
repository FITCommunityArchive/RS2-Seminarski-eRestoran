using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using System.Collections.Generic;
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
                Status = StatusZaposlenika.Aktivan,
                Telefon = Telefon.Text,
                Username = Username.Text,
                TipKorisnika = (TipKorisnika)Uloga.SelectedIndex
            };

            var response = korisnikPostService.PostResponse(model);
            if (response.Result.IsSuccessStatusCode)
            {
                this.DisplayAlert("Info", "Uspjesno kreiran nalog!", "OK");
            }
            else
            {
                this.DisplayAlert("Info", "Zao nam je doslo je do greske. Pokusajte kasnije!", "OK");
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

            if (Uloga.SelectedItem == null)
            {
                Uloga.Focus();
                return false;
            }
            if (NovaLozinka.Text != PonovljenaLozinka.Text)
            {
                this.DisplayAlert("Info", "Ponovljena lozinka nije ista", "OK");
                return false;
            }
            return true;
        }
    }
}