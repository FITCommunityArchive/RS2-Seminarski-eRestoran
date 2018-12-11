using Xamarin.Forms;
using eRestoran.Client.Mobile.Navigation;
#if __ANDROID__
using Android.Runtime;
#endif
using eRestoran.PCL.VM;
using System.Collections.Generic;
using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Views;

namespace eRestoran.Client.Mobile
{
	public partial class App : Application
	{
       
        //eso tu ?????????????  cujes li me  jebse uisljucio sam  oksve c hoces rbadit ovdje ? hocu ok pozz
        // ako ti bude trebalo sta upali mikrofon cut cu 

        public App ()
		{
			InitializeComponent();
            MainPage = new Login();
#if __ANDROID__

            AndroidEnvironment.UnhandledExceptionRaiser += HandleAndroidException;
            // Android-specific code
#endif

        }
#if __ANDROID__
        void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
        {
            e.Handled = true;
        }
        // Android-specific code
#endif
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
