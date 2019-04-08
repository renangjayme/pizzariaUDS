using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;
using Dominio.Servicos;

namespace Aplicacao
{
    public class ServicoDeAplicacaoDePedido
    {
        ServicoDeDominioDePedido servicoDeDominioDePedido = new ServicoDeDominioDePedido();
        
        public void InserirPedido(Pedido pedido)
        {
            servicoDeDominioDePedido.InserirPedido(pedido);
        }

        public void AlterarPedido(Pedido pedido)
        {
            servicoDeDominioDePedido.AlterarPedido(pedido);
        }
    }
}
