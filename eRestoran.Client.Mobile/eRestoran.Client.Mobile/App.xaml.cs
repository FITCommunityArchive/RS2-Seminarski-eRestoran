using System;
using Xamarin.Forms;
using eRestoran.Client.Mobile.Views;
using Xamarin.Forms.Xaml;
using eRestoran.Client.Mobile.Navigation;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace eRestoran.Client.Mobile
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();
            MainPage = new MyPage();
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
