using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Models;
using API.Conversoes;
using Aplicacao;
using Dominio.Entidades;

namespace API.Controllers
{
    public class TamanhosController : ApiController
    {
        ServicoDeAplicacaoDeTamanhos servicoDeAplicacaoDeTamanhos = new ServicoDeAplicacaoDeTamanhos();
        Conversao conversao = new Conversao();

        public HttpResponseMessage GetTamanhos()
        {
            try
            {
                var tamanhos = servicoDeAplicacaoDeTamanhos.RecuperarTamanhos();

                return Request.CreateResponse(HttpStatusCode.OK, conversao.Converter(tamanhos));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}