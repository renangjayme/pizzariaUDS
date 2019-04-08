using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public List<Personalizacao> Personalizacoes { get; set; }
        public double ValorTotal { get; set; }
        public int TempoPreparo { get; set; }
    }
}
