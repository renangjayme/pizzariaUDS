using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class PedidoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Selecione o tamanho")]
        public TamanhoViewModel Tamanho { get; set; }

        [Display(Name = "Selecione o sabor")]
        public SaborViewModel Sabor { get; set; }

        [Display(Name = "Personalize sua Pizza")]
        public List<PersonalizacaoViewModel> Personalizacoes { get; set; }

        public List<TamanhoViewModel> Tamanhos { get; set; }
        public List<SaborViewModel> Sabores { get; set; }

        [Display(Name = "Valor Total")]
        public double ValorTotal { get; set; }

        [Display(Name = "Tempo de Preparo")]
        public int TempoPreparo { get; set; }
    }
}