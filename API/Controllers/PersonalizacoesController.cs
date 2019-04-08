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
    public class PersonalizacoesController : ApiController
    {
        ServicoDeAplicacaoDePersonalizacoes servicoDeAplicacaoDePersonalizacoes = new ServicoDeAplicacaoDePersonalizacoes();
        Conversao conversao = new Conversao();

        public HttpResponseMessage GetPersonalizacoes()
        {
            try
            {
                var personalizacoes = servicoDeAplicacaoDePersonalizacoes.RecuperarPersonalizacoes();

                return Request.CreateResponse(HttpStatusCode.OK, conversao.Converter(personalizacoes));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}