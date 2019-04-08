using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;

namespace Infraestrutura.Repositorios
{
    public class RepositorioSabores : Repositorio
    {
        public override void Recuperar()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT ID, DESCRICAO, TEMPO FROM V_SABORES";
                tab = executaconsulta(cmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Sabor> RecuperarSabores()
        {
            List<Sabor> sabores = new List<Sabor>();

            try
            {
                this.Recuperar();

                using (var consulta = tab.CreateDataReader())
                {
                    while (consulta.Read())
                    {
                        sabores.Add(new Sabor
                        {
                            Id = (int)consulta["ID"],
                            Descricao = consulta["DESCRICAO"].ToString(),
                            Tempo = (int)consulta["TEMPO"]
                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return sabores;
        }

    }
}
