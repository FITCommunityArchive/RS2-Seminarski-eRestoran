using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Client.Util
{
   public class WebAPIHelper
    {
        private HttpClient client { get; set; }
        public string route { get; set; }

        public WebAPIHelper(string uri,string route)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            this.route = route;

        }
        public HttpResponseMessage GetResponse() {

            return client.GetAsync(route).Result;
        }

    }
}
