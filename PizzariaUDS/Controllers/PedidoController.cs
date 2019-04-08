using Newtonsoft.Json;
using Site.Anticorrupcao;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class PedidoController : Controller
    {
        public ActionResult Index()
        {
            var model = new PedidoViewModel();

            var clientTamanho = new ClientTamanho();

            var response = clientTamanho.GetTamanhos();

            if (response.IsSuccessStatusCode)
            {
                model.Tamanhos = response.Content.ReadAsAsync<List<TamanhoViewModel>>().Result;
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            var clientSabor = new ClientSabor();

            response = clientSabor.GetSabores();

            if (response.IsSuccessStatusCode)
            {
                model.Sabores = response.Content.ReadAsAsync<List<SaborViewModel>>().Result;
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            return View(model);
        }

        public ActionResult InserirPedido(PedidoViewModel model)
        {
            var clientPedido = new ClientPedido();

            var response = clientPedido.PostPedido(model);

            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<PedidoViewModel>().Result;
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            var clientPersonalizacao = new ClientPersonalizacao();

            response = clientPersonalizacao.GetPersonalizacoes();

            if (response.IsSuccessStatusCode)
            {
                model.Personalizacoes = response.Content.ReadAsAsync<List<PersonalizacaoViewModel>>().Result;
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            return PartialView("_Personalizacao", model);
        }

        public ActionResult FinalizarPedido(PedidoViewModel model)
        {
            var clientPedido = new ClientPedido();

            var response = clientPedido.PutPedido(model);

            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<PedidoViewModel>().Result;
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            var clientTamanho = new ClientTamanho();

            response = clientTamanho.GetTamanhos();

            if (response.IsSuccessStatusCode)
            {
                model.Tamanho = response.Content.ReadAsAsync<List<TamanhoViewModel>>().Result.First(t => t.Id == model.Tamanho.Id);
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            var clientSabor = new ClientSabor();

            response = clientSabor.GetSabores();

            if (response.IsSuccessStatusCode)
            {
                model.Sabor = response.Content.ReadAsAsync<List<SaborViewModel>>().Result.First(t => t.Id == model.Sabor.Id);
            }
            else
                return Json(response, JsonRequestBehavior.AllowGet);

            return PartialView("_Finalizacao", model);
        }
    }
}