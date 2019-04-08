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
    public class ServicoDeDominioDeSabores
    {
        RepositorioSabores repositorioSabores = new RepositorioSabores();

        public List<Sabor> RecuperarSabores()
        {
            return repositorioSabores.RecuperarSabores();
        }
    }
}
