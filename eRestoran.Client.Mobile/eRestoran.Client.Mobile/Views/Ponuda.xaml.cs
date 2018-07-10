using eRestoran.PCL.Helpers;
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
        WebAPIHelper helper = new WebAPIHelper("api/PonudaAdministrator/GetPonuda");

        public Ponuda()
        {
            InitializeComponent();
            var resp  = helper.GetResponse();
            if (resp.IsSuccessStatusCode)
            {
                var content = resp.Content.ReadAsStringAsync().Result;
                Items = JsonConvert.DeserializeObject<List<PonudaVM.PonudaInfo>>(content);

            }
            var listaKategorija = new List<string>();
            listaKategorija.Add("Pice");
            listaKategorija.Add("Jela");
            kategorijaProizvodaPicker.ItemsSource = listaKategorija;


            MyListView.ItemsSource=Items;
        }
        protected override void OnAppearing()
        {
            //ovdje napraviti listu koja sadrzi 2 elementa;

            
            base.OnAppearing();

        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var newPage = new ProductDetail(e.Item);
            await Navigation.PushAsync(newPage);
            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void kategorijaProizvodaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    if (kategorijaProizvodaPicker.SelectedItem != null) {

        //        int vrstaId = (kategorijaProizvodaPicker.SelectedItem as KategorijaProizvoda).VrstaId;
        //        HttpResponseMessage response = proizvodiService.getResponse("url", "vrstaId");
        //        if (response.IsSuccessStatusCode) {
        //            var jsonObject = response.Content.ReadAsStringAsync();
        //            List<Proizvodi> proizvodis = JsonConvert.DeserializeObject<List<Proizvodi>>(jsonObject.Result);
        //            kategorijaProizvodaPicker.ItemSource = proizvodis;

        //        }
        //    }
        }
    }

    public class PonudaVM
    {
        public class PonudaInfo
        {
            public int? Id { get; set; }
            public string Kategorija { get; set; }
            public string Naziv { get; set; }
            public double Cijena { get; set; }
            //public Bitmap urIPicture { get; set; }
            public string imageUrl { get; set; }
            public int Kolicina { get; set; }
            public string KolicinaString { get; set; }
            public int? ProdataKolicina { get; set; }
        }
        public List<PonudaInfo> Ponuda { get; set; }
        public List<PonudaInfo> Pica { get; set; }
        public List<PonudaInfo> Jela { get; set; }


    }
    public class PonudaKonobarVM
    {
        public List<PonudaRow> Jela { get; set; }
        public List<PonudaRow> Pica { get; set; }

    }
    public class PonudaRow
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
    }

}
