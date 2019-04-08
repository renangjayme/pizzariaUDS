using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Site.Anticorrupcao
{
    public class ClientPersonalizacao
    {
        private HttpClient client;

        public ClientPersonalizacao()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriAPI"].ToString());
        }

        public HttpResponseMessage GetPersonalizacoes()
        {
            return client.GetAsync("api/Personalizacoes/GetPersonalizacoes").Result;
        }

    }
}