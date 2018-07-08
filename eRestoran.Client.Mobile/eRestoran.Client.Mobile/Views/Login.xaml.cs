using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Navigation;
using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            btnLogin.Clicked += ValidateLogin;
            btnRegister.Clicked += NavigateToRegister;
        }
 
        private async void NavigateToRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registracija());
        }

        private void ValidateLogin(object sender, EventArgs e)
        {
            var loginService = new WebAPIHelper("https://erestoranapi20180630082851.azurewebsites.net/", "api/korisnici/login/");
            var auth = new AuthVM()
            {
                Email = entryEmail.Text,
                Password = entryPassword.Text
            };
            if (String.IsNullOrWhiteSpace(auth.Email) || String.IsNullOrWhiteSpace(auth.Password))
            {
                this.DisplayAlert("Info", "Password or email are not valid!", "OK");
            }
            var response = loginService.PostResponse(auth).Result;
            if (response.IsSuccessStatusCode)
            {
                var korisnik = WebAPIHelper.GetResponseContent<VerifikovanKorisnikVM>(response);
                ApplicationProperties.UserToken = korisnik.Token;
                var x = new MyPage();
                x.Master = new MyPageMaster();
                Application.Current.MainPage = x;
            }
        }
    }
}