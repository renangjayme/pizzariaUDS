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
    public class SaboresController : ApiController
    {
        ServicoDeAplicacaoDeSabores servicoDeAplicacaoDeSabores = new ServicoDeAplicacaoDeSabores();
        Conversao conversao = new Conversao();

        public HttpResponseMessage GetSabores()
        {
            try
            {
                var sabores = servicoDeAplicacaoDeSabores.RecuperarSabores();

                return Request.CreateResponse(HttpStatusCode.OK, conversao.Converter(sabores));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}