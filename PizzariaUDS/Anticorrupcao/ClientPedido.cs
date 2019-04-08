using Newtonsoft.Json;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Site.Anticorrupcao
{
    public class ClientPedido
    {
        private HttpClient client;

        public ClientPedido()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriAPI"].ToString());
        }

        public HttpResponseMessage PostPedido(PedidoViewModel model)
        {
            var contentString = ConverteJSON(model);

            return client.PostAsync("api/Pedido/PostPedido", contentString).Result;
        }

        public HttpResponseMessage PutPedido(PedidoViewModel model)
        {
            var contentString = ConverteJSON(model);

            return client.PutAsync("api/Pedido/PutPedido", contentString).Result;
        }

        private static StringContent ConverteJSON(PedidoViewModel model)
        {
            var jsonContent = JsonConvert.SerializeObject(model);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return contentString;
        }
    }
}