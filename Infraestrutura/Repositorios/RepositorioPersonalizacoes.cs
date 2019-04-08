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
    public class RepositorioPersonalizacoes : Repositorio
    {
        public override void Recuperar()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT ID, DESCRICAO, VALOR, TEMPO FROM V_PERSONALIZACOES";
                tab = executaconsulta(cmd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Personalizacao> RecuperarPersonalizacoes()
        {
            List<Personalizacao> personalizacoes = new List<Personalizacao>();

            try
            {
                this.Recuperar();

                using (var consulta = tab.CreateDataReader())
                {
                    while (consulta.Read())
                    {
                        personalizacoes.Add(new Personalizacao
                        {
                            Id = (int)consulta["ID"],
                            Descricao = consulta["DESCRICAO"].ToString(),
                            Valor = Convert.ToDouble(consulta["VALOR"]),
                            Tempo = (int)consulta["TEMPO"]
                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return personalizacoes;
        }

        public void InserirPersonalizacao(int idPedido, int idPersonalizacao)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO PEDIDO_PERSONALIZACAO(ID_PEDIDO, PERSONALIZACAO) " +
                " VALUES (@ID_PEDIDO, @PERSONALIZACAO)";
                cmd.Parameters.Add(new SqlParameter("@ID_PEDIDO", SqlDbType.VarChar)).Value = idPedido;
                cmd.Parameters.Add(new SqlParameter("@PERSONALIZACAO", SqlDbType.VarChar)).Value = idPersonalizacao;
                executacomando(cmd);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
