using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var loginService = new WebAPIHelper("http://192.168.0.16/", "api/korisnici/login/");
            var test = new WebAPIHelper("https://192.168.0.16/", "api/korisnici/korisnik/mirza/");
            var response2 = loginService.GetResponse();
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
                Navigation.PushAsync(new Tabovi());
            }

           
        }
    }
}