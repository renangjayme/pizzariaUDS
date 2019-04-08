using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Site.Anticorrupcao
{
    public class ClientSabor
    {
        private HttpClient client;

        public ClientSabor()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriAPI"].ToString());
        }

        public HttpResponseMessage GetSabores()
        {
            return client.GetAsync("api/Sabores/GetSabores").Result;
        }

    }
}