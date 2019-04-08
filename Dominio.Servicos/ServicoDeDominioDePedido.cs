using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;

namespace Dominio.Servicos
{
    public class ServicoDeDominioDePedido
    {
        RepositorioPedido repositorioPedido = new RepositorioPedido();
        ServicoDeDominioDePersonalizacoes servicoDeDominioDePersonalizacoes = new ServicoDeDominioDePersonalizacoes();
        ServicoDeDominioDeTamanhos servicoDeDominioDeTamanhos = new ServicoDeDominioDeTamanhos();
        ServicoDeDominioDeSabores servicoDeDominioDeSabores = new ServicoDeDominioDeSabores();

        public void InserirPedido(Pedido pedido)
        {
            var tamanhos = servicoDeDominioDeTamanhos.RecuperarTamanhos();
            var sabores = servicoDeDominioDeSabores.RecuperarSabores();

            var tamanho = tamanhos.First(t => t.Id == pedido.Tamanho.Id);
            var sabor = sabores.First(t => t.Id == pedido.Sabor.Id);

            pedido.ValorTotal = tamanho.Valor;
            pedido.TempoPreparo = tamanho.Tempo + sabor.Tempo;

            pedido.Id = repositorioPedido.InserirPedido(pedido);
        }

        public void AlterarPedido(Pedido pedido)
        {
            servicoDeDominioDePersonalizacoes.InserirPersonalizacoes(pedido.Id, pedido.Personalizacoes.Where(p => p.Selecionado == true).ToList());

            if (pedido.Personalizacoes.Where(p => p.Selecionado == true).Count() > 0)
            {
                pedido.ValorTotal = pedido.ValorTotal + pedido.Personalizacoes.Where(p => p.Selecionado == true).Sum(p => p.Valor);
                pedido.TempoPreparo = pedido.TempoPreparo + pedido.Personalizacoes.Where(p => p.Selecionado == true).Sum(p => p.Tempo);
            }
        }
    }
}
