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
	public partial class Registracija : ContentPage
	{
		public Registracija ()
		{
            InitializeComponent();
            lblLogin.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToLogin())
            });
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void NavigateToLogin() {
            await Navigation.PushAsync(new Login());
        }

    }
}