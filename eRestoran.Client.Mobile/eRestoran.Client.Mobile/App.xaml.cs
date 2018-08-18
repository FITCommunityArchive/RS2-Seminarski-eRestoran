using Xamarin.Forms;
using eRestoran.Client.Mobile.Navigation;
using Android.Runtime;
using eRestoran.PCL.VM;
using System.Collections.Generic;
using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Views;

namespace eRestoran.Client.Mobile
{
	public partial class App : Application
	{
       

        public App ()
		{
			InitializeComponent();
            MainPage = new Login();
            AndroidEnvironment.UnhandledExceptionRaiser += HandleAndroidException;
            
        }
        void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
        {
            e.Handled = true;
        }
        protected override void OnStart ()
		{
            var cart = new CartIndexVM();
            cart.Jela = new List<CartRow>();
            cart.Pica = new List<CartRow>();
            cart.TotalPrice = 0.00;
            ApplicationProperties.cart = cart;
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
        }
    }
}
