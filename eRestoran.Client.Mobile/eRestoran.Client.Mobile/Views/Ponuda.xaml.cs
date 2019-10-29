using eRestoran.PCL.Helpers;
using eRestoran.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ponuda : ContentPage
    {
        public List<PonudaVM.PonudaInfo> Items { get; set; }
        WebAPIHelper helperPonuda = new WebAPIHelper("api/PonudaAdministrator/GetPonuda");
        WebAPIHelper helperPica = new WebAPIHelper("api/PonudaAdministrator/GetPica");
        WebAPIHelper helperJela = new WebAPIHelper("api/PonudaAdministrator/GetJela");

        public Ponuda()
        {
            InitializeComponent();
            var resp = helperPonuda.GetResponse();
            if (resp.IsSuccessStatusCode)
            {
                var content = resp.Content.ReadAsStringAsync().Result;
                Items = JsonConvert.DeserializeObject<List<PonudaVM.PonudaInfo>>(content);

            }

            foreach (var item in Items) {
                if (item.imageUrl == null)
                {
                    item.imageUrl = "http://erestoranapi20180630082851.azurewebsites.net/images/28f8bd6b-7c16-44da-8fb3-c217ebb44c2dupload.jpg";
                }
            }

            var listaKategorija = new List<string>();
            listaKategorija.Add("Odaberite kategoriju");
            listaKategorija.Add("Pica");
            listaKategorija.Add("Jela");
            kategorijaProizvodaPicker.ItemsSource = listaKategorija;
            kategorijaProizvodaPicker.SelectedIndex = 0;

            MyListView.ItemsSource = Items;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var itemClicked = (PonudaVM.PonudaInfo)e.Item;
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

        private void kategorijaProizvodaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (kategorijaProizvodaPicker.SelectedIndex)
            {
                case 1:
                    var resp2 = helperPica.GetResponse();
                    Items.RemoveAll(proizvod => proizvod.Id > 0);
                    if (resp2.IsSuccessStatusCode)
                    {
                        var content = resp2.Content.ReadAsStringAsync().Result;
                        Items = JsonConvert.DeserializeObject<List<PonudaVM.PonudaInfo>>(content);
                        foreach (var item in Items)
                        {
                            if (item.imageUrl == null)
                            {
                                item.imageUrl = "http://erestoranapi20180630082851.azurewebsites.net/images/28f8bd6b-7c16-44da-8fb3-c217ebb44c2dupload.jpg";
                            }
                        }
                    }
                    break;

                case 2:
                    var resp1 = helperJela.GetResponse();
                    Items.RemoveAll(proizvod => proizvod.Id > 0);
                    if (resp1.IsSuccessStatusCode)
                    {
                        Items.RemoveAll(proizvod => proizvod.Id > 0);
                        var content = resp1.Content.ReadAsStringAsync().Result;
                        Items = JsonConvert.DeserializeObject<List<PonudaVM.PonudaInfo>>(content);
                    }
                    break;
                default:
                    //DisplayAlert("Item Tapped", kategorijaProizvodaPicker.SelectedIndex.ToString(), "OK");
                    var resp = helperPonuda.GetResponse();
                    Items.RemoveAll(proizvod => proizvod.Id > 0);
                    if (resp.IsSuccessStatusCode)
                    {
                        var content = resp.Content.ReadAsStringAsync().Result;
                        Items = JsonConvert.DeserializeObject<List<PonudaVM.PonudaInfo>>(content);
                        foreach (var item in Items)
                        {
                            if (item.imageUrl == null)
                            {
                                item.imageUrl = "http://erestoranapi20180630082851.azurewebsites.net/images/28f8bd6b-7c16-44da-8fb3-c217ebb44c2dupload.jpg";
                            }
                        }
                    }
                    break;
            }

            MyListView.ItemsSource = Items;

            //int vrstaId = (kategorijaProizvodaPicker.SelectedItem as KategorijaProizvoda).VrstaId;
            //HttpResponseMessage response = proizvodiService.getResponse("url", "vrstaId");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonObject = response.Content.ReadAsStringAsync();
            //    List<Proizvodi> proizvodis = JsonConvert.DeserializeObject<List<Proizvodi>>(jsonObject.Result);
            //    kategorijaProizvodaPicker.ItemSource = proizvodis;

            //}
        }
    }

}
