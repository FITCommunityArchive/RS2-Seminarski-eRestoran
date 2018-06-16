using eRestoran.Client.Mobile.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        public LoginVM loginVM;

        public Login ()
		{
			InitializeComponent ();
            loginVM = new LoginVM();
            //MessagingCenter.Subscribe<LoginVM,string>(this, "LoginAlert",(sender,username)=> {
            //    DisplayAlert("Title", username, "Oke");
            //});
            BindingContext = loginVM;
            usernameEntry.Completed += (object sender, EventArgs e) =>
            {
                passwordEntry.Focus();

            };
            passwordEntry.Completed += (object sender, EventArgs e) =>
            {
                loginVM.SumbitCommand.Execute(null);

            };

        }
              
    }
}