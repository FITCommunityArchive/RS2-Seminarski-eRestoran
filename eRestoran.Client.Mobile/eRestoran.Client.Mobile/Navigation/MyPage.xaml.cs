using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace eRestoran.Client.Mobile.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : MasterDetailPage
    {
        public MyPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MyPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = true;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}