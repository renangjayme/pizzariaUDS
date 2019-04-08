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
    public class ServicoDeDominioDePersonalizacoes
    {
        RepositorioPersonalizacoes repositorioPersonalizacoes = new RepositorioPersonalizacoes();

        public List<Personalizacao> RecuperarPersonalizacoes()
        {
            return repositorioPersonalizacoes.RecuperarPersonalizacoes();
        }

        public void InserirPersonalizacoes(int idPedido, List<Personalizacao> personalizacoes)
        {
            foreach (var personalizacao in personalizacoes)
            {
                repositorioPersonalizacoes.InserirPersonalizacao(idPedido, personalizacao.Id);
            }
        }
    }
}
