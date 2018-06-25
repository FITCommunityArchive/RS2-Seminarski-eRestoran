using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.PCL.Helpers
{
    public class WebAPIHelper
    {
        public HttpClient client { get; set; }
        public string route { get; set; }

        public WebAPIHelper(string uri, string route)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            this.route = route;
        }

        public HttpResponseMessage GetResponse()
        {
            return client.GetAsync(route).Result;
        }

        public HttpResponseMessage DeleteResponse(string parametar)
        {
            return client.DeleteAsync(route + "/" + parametar).Result;
        }

        public void AddBearerToken(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> GetResponse(string parametar)
        {
            return await client.GetAsync(route + "/" + parametar);
        }

        public async Task<HttpResponseMessage> GetResponse(string parametar1, string parametar2)
        {
            return await client.GetAsync(route + "/" + parametar1 + "/" + parametar2);
        }
      
        public async Task<HttpResponseMessage> PostResponse(object obj)
        {
            try
            {
                var serializedObj = JsonConvert.SerializeObject(obj);
                var x = await client.PostAsync(route, new StringContent(serializedObj, Encoding.UTF8, "application/json"));
                return x;
            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }
        }
        public async Task<T> PostResponse<T>(string url, FormUrlEncodedContent content) where T : class
        {
            var response = await client.PostAsync(url, content);
            var result = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject<T>(result);
            return resultObject;

        }
        public async Task<HttpResponseMessage> PostWithParametar(int id, object obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj);
            return await client.PostAsync(route + "/" + id, new StringContent(serializedObj, Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> PutResponse(int id, object obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj);
            return await client.PutAsync(route + "/" + id, new StringContent(serializedObj, Encoding.UTF8, "application/json"));
        }
    }
}
