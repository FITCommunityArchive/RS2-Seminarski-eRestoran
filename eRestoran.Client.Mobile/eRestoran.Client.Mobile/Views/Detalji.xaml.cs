using eRestoran.VM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalji : ContentPage
    {
        public Detalji(PonudaVM.PonudaInfo model)
        {
            InitializeComponent();
            this.BindingContext = model;
        }
    }
}