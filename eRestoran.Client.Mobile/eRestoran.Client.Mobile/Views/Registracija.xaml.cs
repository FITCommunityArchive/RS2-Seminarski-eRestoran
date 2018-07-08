using eRestoran.Client.Mobile.Navigation;
using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registracija : ContentPage
    {
        public Registracija()
        {
            InitializeComponent();
            lblLogin.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToLogin())
            });
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
           await Task.Run(RegisterUser);
            var x = new MyPage();
            Application.Current.MainPage = x;

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

    }

}