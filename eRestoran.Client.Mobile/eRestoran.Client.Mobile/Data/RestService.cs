using eRestoran.Client.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Client.Mobile.Data
{
    public class RestService
    {
        HttpClient client;
        private string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));

        }
        public async Task<VerifikovaniKorisnikVM> Login(KlijentVM user) {
            var postdata = new List<KeyValuePair<string, string>>();
            postdata.Add(new KeyValuePair<string, string>("grantype", grant_type));
            postdata.Add(new KeyValuePair<string, string>("grantype", user.Username));
            postdata.Add(new KeyValuePair<string, string>("grantype", user.Password));
            var content = new FormUrlEncodedContent(postdata);
            var url = "";
            var response = await PostResponse<VerifikovaniKorisnikVM>(url, content);
            return response;


        }
        public async Task<T> PostResponse<T>(string url, FormUrlEncodedContent content) where T : class {
            var response = await client.PostAsync(url, content);
            var result = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject<T>(result);
            return resultObject;

        }
       
    }
}
