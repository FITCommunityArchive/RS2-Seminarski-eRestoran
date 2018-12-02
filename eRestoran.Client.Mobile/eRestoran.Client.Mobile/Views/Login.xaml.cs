using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Navigation;
using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        private ActivityPageViewModel ViewModel { get; set; }

        public Login()
        {
            ViewModel = new ActivityPageViewModel
            {
                ButtonText = "Click Me!"
            };
            BindingContext = ViewModel;
            InitializeComponent();
            btnLogin.Clicked += async (sender, e) => await ValidateLogin();
            btnRegister.Clicked += NavigateToRegister;
        }
        private void NavigateToRegister(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Registracija();
        }

        private async Task ValidateLogin()
        {
            btnLogin.Text = "Logging in...";
            var x = new MyPage();
            Application.Current.MainPage = x;
            ViewModel.IsBusy = true;
           // var isSuccess = await Task.Run(PostLogin);
            // do work son
            ViewModel.IsBusy = false;

            //if (isSuccess)
            //{
            //    var x = new MyPage();
            //    Application.Current.MainPage = x;
            //}
            //else
            //{
            //    btnLogin.Text = "Login";
            //    await this.DisplayAlert("Info", "Password or email are not valid!", "OK");
            //}
        }

        private async Task<bool> PostLogin()
        {
            var loginService = new WebAPIHelper("api/korisnici/login/");
            var auth = new AuthVM()
            {
                Email = entryEmail.Text,
                Password = entryPassword.Text
            };
           
            var response = await loginService.PostResponse(auth);
            if (response.IsSuccessStatusCode)
            {
                var korisnik = WebAPIHelper.GetResponseContent<VerifikovanKorisnikVM>(response);
                ApplicationProperties.UserToken = korisnik.Token;
                return true;
            }

            return false;
        }
    }
    public class BaseViewModel : INotifyPropertyChanged
    {
        // here's your shared IsBusy property
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                // again, this is very important
                OnPropertyChanged();
            }
        }

        // this little bit is how we trigger the PropertyChanged notifier.
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ActivityPageViewModel : BaseViewModel
    {
        private string _buttonText;

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                // This is very important. It indicates to the app that you've changed the content of this property
                OnPropertyChanged();
            }
        }
    }
}