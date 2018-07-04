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

        public static T GetResponseContent<T>(HttpResponseMessage response)  where T : class 
        {
            var responseResult = response.Content.ReadAsStringAsync().Result;
            T content = JsonConvert.DeserializeObject<T>(responseResult);
            return content;
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
            var serializedObj = JsonConvert.SerializeObject(obj);
            var x = client.PostAsync(route, new StringContent(serializedObj, Encoding.UTF8, "application/json")).Result;
            return x;
        }
        public async Task<T> PostResponse<T>(string url, FormUrlEncodedContent content) where T : class
        {
            var response = client.PostAsync(url, content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject<T>(result);
            return resultObject;

        }
        public async Task<HttpResponseMessage> PostWithParametar(int id, object obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj);
            return client.PostAsync(route + "/" + id, new StringContent(serializedObj, Encoding.UTF8, "application/json")).Result;
        }

        public async Task<HttpResponseMessage> PutResponse(int id, object obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj);
            return client.PutAsync(route + "/" + id, new StringContent(serializedObj, Encoding.UTF8, "application/json")).Result;
        }
    }
}
