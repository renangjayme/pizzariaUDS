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
    public class RepositorioTamanhos : Repositorio
    {
        public override void Recuperar()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT ID, DESCRICAO, VALOR, TEMPO FROM V_TAMANHOS";
                tab = executaconsulta(cmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Tamanho> RecuperarTamanhos()
        {
            List<Tamanho> tamanhos = new List<Tamanho>();

            try
            {
                this.Recuperar();

                using (var consulta = tab.CreateDataReader())
                {
                    while (consulta.Read())
                    {
                        tamanhos.Add(new Tamanho
                        {
                            Id = (int)consulta["ID"],
                            Descricao = consulta["DESCRICAO"].ToString(),
                            Valor = Convert.ToDouble(consulta["VALOR"].ToString()),
                            Tempo = (int)consulta["TEMPO"]
                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return tamanhos;
        }

    }
}
