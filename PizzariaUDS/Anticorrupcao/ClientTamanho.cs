using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Site.Anticorrupcao
{
    public class ClientTamanho
    {
        private HttpClient client;

        public ClientTamanho()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriAPI"].ToString());
        }

        public HttpResponseMessage GetTamanhos()
        {
            return client.GetAsync("api/Tamanhos/GetTamanhos").Result;
        }

    }
}