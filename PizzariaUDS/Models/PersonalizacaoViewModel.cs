using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class PersonalizacaoViewModel
    {
        public int Id { get; set; }
        public bool Selecionado { get; set; }        
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Tempo { get; set; }
    }
}