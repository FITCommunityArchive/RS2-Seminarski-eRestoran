using eRestoran.Client.Mobile.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPageMaster : ContentPage
    {
        public ListView ListView;

        public MyPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyPageMenuItem> MenuItems { get; set; }
            
            public MyPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyPageMenuItem>(new[]
                {
                    new MyPageMenuItem { Title = "Login",TargetType=typeof(Login) },
                    new MyPageMenuItem {  Title = "Register",TargetType=typeof(Registracija) },
                    new MyPageMenuItem {  Title = "Ponuda",TargetType=typeof(Ponuda) },
                    new MyPageMenuItem { Title = "Detalji",TargetType=typeof(Detalji) },
                    new MyPageMenuItem { Title = "Rezervacije",TargetType=typeof(RezervisiSto) },
                    new MyPageMenuItem { Title = "Dodavanje naloga",TargetType=typeof(DodavanjeNaloga) },
                    new MyPageMenuItem { Title = "Promocija ",TargetType=typeof(Promocija) },

                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}