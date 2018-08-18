using eRestoran.Client.Mobile.Helpers;
using eRestoran.PCL.Helpers;
using eRestoran.PCL.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervisiSto : ContentPage
    {
        List<StoloviRezervacijaVM> stolovi { get; set; }
        public DateTime DatumRezervacije = DateTime.Now;

        public WebAPIHelper getRezervacijeStolova = new WebAPIHelper("api/post/rezervacijestolova");
        public WebAPIHelper postOznaciSto = new WebAPIHelper("api/post/oznacisto");
        public WebAPIHelper postOslobodiSto = new WebAPIHelper("api/post/oslobodisto");
        public WebAPIHelper getStolove = new WebAPIHelper("api/get/stolovi");
        public WebAPIHelper postRezervisiSto = new WebAPIHelper("api/post/rezervisi");
        public WebAPIHelper getOsvjeziStolove = new WebAPIHelper("api/get/osvjezistolove");
        public WebAPIHelper postIzbrisiRezervaciju = new WebAPIHelper("api/post/izbrisirezervaciju");
        public WebAPIHelper postCheckout = new WebAPIHelper("api/checkout");

        public RezervisiSto()
        {
            InitializeComponent();
            var responseMessage = getStolove.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                stolovi = responseMessage.Content.ReadAsAsync<List<StoloviRezervacijaVM>>();
            }
            BindControlsAndData();
        }

        private void BtnSto_Clicked(object sender, System.EventArgs e)
        {
            if (sender != null && sender is Button btn)
            {
                if (int.TryParse(btn.Text, out var brojStola))
                {
                    var odabraniSto = stolovi.FirstOrDefault(x => x.RedniBrojStola == brojStola);
                    if (DatumRezervacije != DateTime.MinValue) // uvijek razlicito
                    {
                        if (odabraniSto.IsSlobodan)
                        {
                            var response = postRezervisiSto.PostWithParametar(brojStola, DatumRezervacije.ToString("o")).Result;
                            if (response.IsSuccessStatusCode)
                            {

                                postCheckout.AddBearerToken(ApplicationProperties.UserToken);
                                var response2 = postCheckout.PostWithParametar(brojStola, CartHelper.GetCartForCheckout()).Result;
                                if (response2.IsSuccessStatusCode)
                                {
                                btn.Image = "sto_zauzet.jpg";
                                    Application.Current.MainPage = new Ponuda();
                                    //redirect na ponudu
                                }
                            }
                        }
                        else
                        {
                            var response = postIzbrisiRezervaciju.PostResponse(odabraniSto.RezervacijaId).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                btn.Image = "sto_slobodan.jpg";
                            }
                        }
                        odabraniSto.IsSlobodan = !odabraniSto.IsSlobodan;
                    }

                }
                BindControlsAndData();
            }
        }
        public void BindControlsAndData()
        {
            var response = getRezervacijeStolova.PostResponse(DatumRezervacije.ToString("o")).Result;
            if (response.IsSuccessStatusCode)
            {
                stolovi = response.Content.ReadAsAsync<List<StoloviRezervacijaVM>>();
            }
            foreach (var sto in stolovi)
            {

                var btnSto = this.FindByName<Button>("btnSto" + sto.RedniBrojStola);
                if (!sto.IsSlobodan)
                {
                    btnSto.Image = "sto_zauzet.jpg";
                }
                else
                {
                    btnSto.Image = "sto_slobodan.jpg";
                }
            }
        }
    }

    public static class HttpContentExtensions
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static T ReadAsAsync<T>(this HttpContent content) where T : class
        {
            var response = content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(response);
        }

    }
}