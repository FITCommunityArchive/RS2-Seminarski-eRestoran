using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eRestoran.PCL.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using eData = eRestoran.PCL.VM;
using eRestoran.Client.Mobile.ViewModels;

namespace eRestoran.Client.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Promocija : ContentPage
    {
        private bool isJelo = false;
        private int stavkaId = 0;
        private double cijena = double.MinValue;
        //WebAPIHelper helperPica = new WebAPIHelper("api/PonudaAdministrator/GetPice/");

        public Promocija()
        {
            var today = DateTime.Now.Date;
            InitializeComponent();
            staraCijenaRow.IsVisible = false;
            kategorijaRow.IsVisible = false;
            nazivRow.IsVisible = false;
            btnSearch.Clicked += async (sender, e) => await getStavka(sifra.Text);
            btnAddPromotion.Clicked += async (sender, e) => await postPromotion();
            
            StartDatePicker.Date = today;
            StartDatePicker.MinimumDate = today;
            EndDatePicker.Date = today.AddDays(1);
            EndDatePicker.MinimumDate = today.AddDays(1);
        }

        private async Task<bool> getStavka(string sifra)
        {
            var apiUrl = "api/ponuda/GetProizvodBySifra/" + sifra;
            WebAPIHelper helper = new WebAPIHelper(apiUrl);

            var response = helper.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var item = JsonConvert.DeserializeObject<PonudaVM.PonudaInfo>(content);
                if (item.Id.HasValue)
                {
                    staraCijena.Text = item.Cijena.ToString() + " KM";
                    cijena = item.Cijena;
                    kategorija.Text = item.Kategorija;
                    nazivProizvoda.Text = item.Naziv;
                    isJelo = item.IsJelo;
                    stavkaId = item.Id.HasValue ? item.Id.Value : 0;
                    staraCijenaRow.IsVisible = true;
                    kategorijaRow.IsVisible = true;
                    nazivRow.IsVisible = true;
                    addons.IsVisible = true;
                    await this.DisplayAlert("Info", "Trazena stavka je pronađena", "OK");

                    return true;
                }

                await this.DisplayAlert("Info", "Trazena stavka ne postoji", "OK");
                staraCijenaRow.IsVisible = false;
                kategorijaRow.IsVisible = false;
                nazivRow.IsVisible = false;

                return false;
            }
            else
            {
                staraCijenaRow.IsVisible = false;
                kategorijaRow.IsVisible = false;
                nazivRow.IsVisible = false;

                return false;
            }
        }

        private async Task<bool> postPromotion()
        {
            var promocijeService = new WebAPIHelper("api/promocija/promovisi");
            if (stavkaId != 0 && double.TryParse(promotivnaCijena.Text, out double novaCijena)) {
                var promocija = new eData.PromocijaVM()
                {
                    DatumOd = DateTime.SpecifyKind(StartDatePicker.Date.Date, DateTimeKind.Utc),
                    DatumDo = DateTime.SpecifyKind(EndDatePicker.Date.Date, DateTimeKind.Utc),
                    PromotivnaCijena = novaCijena,
                    StaraCijena = cijena
                };

                if (isJelo)
                    promocija.JeloId = stavkaId;
                else
                    promocija.ProizvodId = stavkaId;

                var response = await promocijeService.PostResponse(promocija);
                if (response.IsSuccessStatusCode)
                {
                    await this.DisplayAlert("Uspjesno", "Proizvod je promovisan", "U redu");
                    return true;
                }
            }
            await this.DisplayAlert("Neuspjesno", "Izmijenite unesene podatke", "U redu");

            return false;
        }
    }
}