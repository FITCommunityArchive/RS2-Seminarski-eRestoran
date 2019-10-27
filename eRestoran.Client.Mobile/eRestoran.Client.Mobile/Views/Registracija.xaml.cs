using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Navigation;
using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registracija : ContentPage
    {
        private List<Entry> entries;

        public Registracija()
        {
            InitializeComponent();
            lblLogin.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToLogin())
            });

            entries = new List<Entry>()
            {
                ime,
                prezime,
                adresa,
                email,
                telefon,
                userName,
                password,
            };

            NavigationPage.SetHasNavigationBar(this, false);
            btnRegister.Clicked += async (sender, e) => await ValidateRegister();



        }
        async void NavigateToLogin()
        {
            var x = new Login();
            Application.Current.MainPage = x;
        }

        private async Task ValidateRegister()
        {
           var isValid = ValidateForm();
            if (isValid)
            {
                ClearForm();
                await Task.Run(RegisterUser);
                NavigateToLogin();
                await this.DisplayAlert("Registracija", "Uspjesna registracija", "OK");

            }

        }

        private void ClearForm()
        {
            adresa.Text = "";
            email.Text = "";
            ime.Text = "";
            prezime.Text = "";
            potvrdiPassword.Text = "";
            password.Text = "";
            telefon.Text = "";
            userName.Text = "";
        }

        private bool ValidateDigits(string digits)
        {
            if (Regex.Match(digits, @"^\d+\.?\d*$").Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateEmail(string email)
        {
            if (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateForm()
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

            if (!ValidateEmail(email.Text))
            {
                this.DisplayAlert("Email", "Niste unijeli pravilan email", "OK");
                email.Focus();
                return false;
            }

            if (!ValidateDigits(telefon.Text))
            {
                this.DisplayAlert("Telefon", "Molimo unesite samo brojeve", "OK");
                telefon.Focus();
                return false;
            }

          

            if (password.Text != potvrdiPassword.Text)
            {
                this.DisplayAlert("Lozinka", "Ponovljena lozinka nije ista", "OK");
                potvrdiPassword.Focus();
                return false;
            }

            return true;
        }

         private async Task<bool> RegisterUser()
        {
            var kor = new KlijentVM()

            {
                Adresa = adresa.Text,
                Email = email.Text,
                Ime = ime.Text,
                Prezime = prezime.Text,
                Username = userName.Text,
                Password = password.Text,
                TipKorisnika = (int)TipKorisnikaVM.Klijent,
                Telefon = telefon.Text,
                DatumPrijave = DateTime.Now
            };

            var registerService = new WebAPIHelper("api/Nalog/PostKlijent");

            var response = await registerService.PostResponse(kor);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

       async void RegisterUserEvent(object sender, EventArgs e)
        {
            await RegisterUser();
        }

    }

}