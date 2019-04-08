using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;
using API.Models;

namespace API.Conversoes
{
    public class Conversao
    {
        public Pedido Converter(PedidoModel pedido)
        {
            return new Pedido
            {
                Id = pedido.Id,
                Personalizacoes = pedido.Personalizacoes != null ? Converter(pedido.Personalizacoes) : null,
                Tamanho = pedido.Tamanho != null ? Converter(pedido.Tamanho) : null,
                Sabor = pedido.Sabor != null ? Converter(pedido.Sabor) : null,
                ValorTotal = pedido.ValorTotal,
                TempoPreparo = pedido.TempoPreparo
            };
        }

        public PedidoModel Converter(Pedido pedido)
        {
            return new PedidoModel
            {
                Id = pedido.Id,
                Personalizacoes = pedido.Personalizacoes != null ? Converter(pedido.Personalizacoes) : null,
                Tamanho = pedido.Tamanho != null ? Converter(pedido.Tamanho) : null,
                Sabor = pedido.Sabor != null ? Converter(pedido.Sabor) : null,
                ValorTotal = pedido.ValorTotal,
                TempoPreparo = pedido.TempoPreparo
            };
        }

        public List<Personalizacao> Converter(List<PersonalizacaoModel> personalizacoes)
        {
            var lista = new List<Personalizacao>();

            foreach (var model in personalizacoes)
            {
                lista.Add(new Personalizacao
                {
                    Id = model.Id,
                    Selecionado = model.Selecionado,
                    Descricao = model.Descricao,
                    Valor = model.Valor,
                    Tempo = model.Tempo
                });
            };

            return lista;
        }

        public List<PersonalizacaoModel> Converter(List<Personalizacao> personalizacoes)
        {
            var lista = new List<PersonalizacaoModel>();

            foreach (var model in personalizacoes)
            {
                lista.Add(new PersonalizacaoModel
                {
                    Id = model.Id,
                    Selecionado = model.Selecionado,
                    Descricao = model.Descricao,
                    Valor = model.Valor,
                    Tempo = model.Tempo
                });
            };

            return lista;
        }

        public List<TamanhoModel> Converter(List<Tamanho> tamanhos)
        {
            List<TamanhoModel> lista = new List<TamanhoModel>();

            foreach (var tamanho in tamanhos)
            {
                lista.Add(Converter(tamanho));
            }

            return lista;
        }

        public Tamanho Converter(TamanhoModel tamanho)
        {
            return new Tamanho
            {
                Id = tamanho.Id,
                Descricao = tamanho.Descricao,
                Valor = tamanho.Valor,
                Tempo = tamanho.Tempo
            };
        }

        public TamanhoModel Converter(Tamanho tamanho)
        {
            return new TamanhoModel
            {
                Id = tamanho.Id,
                Descricao = tamanho.Descricao,
                Valor = tamanho.Valor,
                Tempo = tamanho.Tempo
            };
        }

        public List<SaborModel> Converter(List<Sabor> sabores)
        {
            List<SaborModel> lista = new List<SaborModel>();

            foreach (var sabor in sabores)
            {
                lista.Add(Converter(sabor));
            }

            return lista;
        }

        public Sabor Converter(SaborModel sabor)
        {
            return new Sabor
            {
                Id = sabor.Id,
                Descricao = sabor.Descricao,
                Tempo = sabor.Tempo
            };
        }

        public SaborModel Converter(Sabor sabor)
        {
            return new SaborModel
            {
                Id = sabor.Id,
                Descricao = sabor.Descricao,
                Tempo = sabor.Tempo
            };
        }
    }
}
