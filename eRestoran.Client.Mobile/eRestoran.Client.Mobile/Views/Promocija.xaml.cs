using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eRestoran.PCL.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using eRestoran.VM;

namespace eRestoran.Client.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Promocija : ContentPage
	{
        //WebAPIHelper helperPica = new WebAPIHelper("api/PonudaAdministrator/GetPice/");

        public Promocija ()
		{
			InitializeComponent ();
            staraCijenaRow.IsVisible = false;
            kategorijaRow.IsVisible = false;
            btnSearch.Clicked += async (sender, e) => await getStavka(sifra.Text);

        }

        private async Task<bool> getStavka(string sifra) {
            var apiUrl = "api/ponuda/GetProizvodBySifra/" + sifra;
            WebAPIHelper helperPica = new WebAPIHelper(apiUrl);

            var response = helperPica.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var item = JsonConvert.DeserializeObject<PonudaVM.PonudaInfo>(content);
                if (item != null) {
                    staraCijena.Text = item.Cijena.ToString() + " KM";
                    kategorija.Text = item.Kategorija;

                    staraCijenaRow.IsVisible = true;
                    kategorijaRow.IsVisible = true;
                    this.DisplayAlert("Info", "Trazena stavka je pronađena", "OK");
                    return true;
                }
                this.DisplayAlert("Info", "Trazena stavka ne postoji", "OK");
                staraCijenaRow.IsVisible = false;
                kategorijaRow.IsVisible = false;
                return false;
            }
            else {
                staraCijenaRow.IsVisible = false;
                kategorijaRow.IsVisible = false;
                return false;
            }
        }

    }


}