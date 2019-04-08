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
    public class ServicoDeDominioDeTamanhos
    {
        RepositorioTamanhos repositorioTamanhos = new RepositorioTamanhos();

        public List<Tamanho> RecuperarTamanhos()
        {
            return repositorioTamanhos.RecuperarTamanhos();
        }
    }
}
