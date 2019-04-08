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
    public class ServicoDeAplicacaoDePersonalizacoes
    {
        ServicoDeDominioDePersonalizacoes servicoDeDominioDePersonalizacoes = new ServicoDeDominioDePersonalizacoes();

        public List<Personalizacao> RecuperarPersonalizacoes()
        {
            return servicoDeDominioDePersonalizacoes.RecuperarPersonalizacoes();
        }
    }
}
