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
    public class PedidoController : ApiController
    {
        ServicoDeAplicacaoDePedido servicoDeAplicacaoDePedido = new ServicoDeAplicacaoDePedido();
        Conversao conversao = new Conversao();

        public HttpResponseMessage PostPedido(PedidoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pedido = conversao.Converter(model);

                    servicoDeAplicacaoDePedido.InserirPedido(pedido);

                    return Request.CreateResponse(HttpStatusCode.Created, conversao.Converter(pedido));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage PutPedido(PedidoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pedido = conversao.Converter(model);

                    servicoDeAplicacaoDePedido.AlterarPedido(pedido);

                    return Request.CreateResponse(HttpStatusCode.OK, conversao.Converter(pedido));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}