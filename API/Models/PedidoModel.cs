using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public TamanhoModel Tamanho { get; set; }
        public SaborModel Sabor { get; set; }
        public List<PersonalizacaoModel> Personalizacoes { get; set; }
        public double ValorTotal { get; set; }
        public int TempoPreparo { get; set; }
    }
}