using eRestoran.Client.Mobile.Models;
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
        public LoginVM loginVM;

        public Login ()
		{
			InitializeComponent ();
            loginVM = new LoginVM();
            MessagingCenter.Subscribe<LoginVM,string>(this, "LoginAlert",(sender,username)=> {
                DisplayAlert("Title", username, "Oke");
            });
            this.BindingContext = loginVM;
            usernameEntry.Completed += (object sender, EventArgs e) =>
            {
                passwordEntry.Focus();

            };
            passwordEntry.Completed += (object sender, EventArgs e) =>
            {
                loginVM.SumbitCommand.Execute(null);

            };

        }
       
        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}