using eRestoran.Client.Mobile.Data;
using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Models;
using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using eRestoran.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetail : ContentPage
	{
        public ObservableCollection<PonudaVM.PonudaInfo> OCFabrics { get; }

        public ProductDetail ()
		{
			InitializeComponent ();
            BindingContext = DataRepository.MockDriver;
            btnOcjeni.Clicked += async (sender, e) => OcjeniProizvod();
        }

        private async Task<bool> OcjeniProizvod()
        {
            var ocjenaVM = new OcjeneVM();
            ocjenaVM.Ocjena = (int)ocjenaSlider.Value;
            ocjenaVM.ProizvodId = Convert.ToInt32(proizvodId.Text);
            ocjenaVM.KupacId = Convert.ToInt32(ApplicationProperties.KorisnikId);
            if (IsJelo.Text == "Jela") {
                ocjenaVM.IsJelo = 1;
            }
            else {
                ocjenaVM.IsJelo = 0;

            }

            var ocjeniService = new WebAPIHelper("api/Proizvodi/OcjeniProizvod");
            var response = await ocjeniService.PostResponse(ocjenaVM);
            if (response.IsSuccessStatusCode)
            {
                await this.DisplayAlert("Uspjesno", "Uspjesno ocnjenjen proizvod. Vasa ocjena je " + ocjenaVM.Ocjena, "U redu");
                btnOcjeni.IsVisible = false;
                ocjenaSlider.IsVisible = false;
                return true;
            }
            else {
                await this.DisplayAlert("Neuspjesno", "Neuspjesno ocnjenjen proizvod", "U redu");
                return false;
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var itemClicked = (PonudaVM.PonudaInfo)e.Item;
            itemClicked.Kategorija = itemClicked.IsJelo ? "Jelo" : "Pice";
            var isJeloParam = itemClicked.IsJelo ? 1 : 0;
            var getRecommened = new WebAPIHelper("api/Proizvodi/RecommendProducts/" + itemClicked.Id + "/" + isJeloParam);
            var response = getRecommened.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var proizvodi = JsonConvert.DeserializeObject<List<PonudaVM.PonudaInfo>>(content);
                var newPage = new ProductDetail(itemClicked, proizvodi);
                await Navigation.PushAsync(newPage);
                //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

                //Deselect Item
                ((ListView)sender).SelectedItem = null;
            }
        }

        public ProductDetail(PonudaVM.PonudaInfo proizvod, List<PonudaVM.PonudaInfo> pp)
        {
            InitializeComponent();
            if (proizvod.Ocjena.Length > 3)
            {
                proizvod.Ocjena = proizvod.Ocjena.Substring(0, 3);
            }
            else if (proizvod.Ocjena.Length == 0) {
                proizvod.Ocjena = "N/A";
            }
            OCFabrics = new ObservableCollection<PonudaVM.PonudaInfo>();
            foreach(var item in pp)
            {
                OCFabrics.Add(new PonudaVM.PonudaInfo {  Id=item.Id ,Naziv = item.Naziv, Cijena = item.Cijena, imageUrl = item.imageUrl, Ocjena = item.Ocjena, IsJelo = item.IsJelo });
            }

            lista.ItemsSource = OCFabrics;
            BindingContext = proizvod;
            btnOcjeni.Clicked += async (sender, e) => OcjeniProizvod();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            int value = (int)args.NewValue;
            displayLabel.Text = String.Format("Vasa ocjena je  {0}", value);
            if(value > 0)
            {
                btnOcjeni.IsVisible = true;
            } else
            {
                btnOcjeni.IsVisible = false;
            }
        }
    }
}