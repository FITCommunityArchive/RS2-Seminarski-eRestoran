using eRestoran.Client.Mobile.Views;
using System;
using Xamarin.Forms;
using eRestoran.Client.Mobile.Data;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace eRestoran.Client.Mobile
{
  
    public partial class App : Application
    {
        static RestService restService;
        public App ()
		{
			InitializeComponent();

			MainPage = new Registracija();
		}

		protected override void OnStart ()
		{
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
        public static RestService RestService
        {

            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;

            }
        } 
                
    }
}
