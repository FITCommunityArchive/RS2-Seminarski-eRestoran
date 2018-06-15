using eRestoran.Client.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eRestoran.Client.Mobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            
		}

        private async void GetAction()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("link");
            var result = JsonConvert.DeserializeObject<List<VerifikovaniKorisnikVM>>(response);
            // moze se koristit dalje podatak

        }
        private async void PostAction()
        {
            var loginVM = new LoginVM();
            var json = JsonConvert.SerializeObject(loginVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var response = await client.PostAsync("link",content);
            if (response.IsSuccessStatusCode) {

            }

            // moze se koristit dalje podatak

        }
    }
}
