using System;
using System.Net.Http;

namespace eRestoran.Client.Shared.Helpers
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


        public HttpResponseMessage GetResponse(string parametar)
        {
            return client.GetAsync(route + "/" + parametar).Result;
        }
        public HttpResponseMessage GetResponse(string parametar1, string parametar2)
        {
            return client.GetAsync(route + "/" + parametar1 + "/" + parametar2).Result;
        }

        public HttpResponseMessage PostResponse(object obj)
        {
            return client.PostAsJsonAsync(route, obj).Result;
        }
        public HttpResponseMessage PostWithParametar(int id, object obj)
        {
            return client.PostAsJsonAsync(route + "/" + id, obj).Result;
        }
        public HttpResponseMessage PutResponse(int id, object obj)
        {
            return client.PutAsJsonAsync(route + "/" + id, obj).Result;
        }
    }
}
