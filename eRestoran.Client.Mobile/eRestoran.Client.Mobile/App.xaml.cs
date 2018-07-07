
using Xamarin.Forms;
using eRestoran.Client.Mobile.Navigation;
using eRestoran.Client.Mobile.Views;

namespace eRestoran.Client.Mobile
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();
            MainPage = new ProductDetail(food: Data.DataRepository.Drivers[0]);

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
	}
}
