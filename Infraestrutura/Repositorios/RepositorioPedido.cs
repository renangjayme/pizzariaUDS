using Infraestrutura.Acesso;
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
    public class RepositorioPedido : Repositorio
    {
        public int InserirPedido(Pedido pedido)
        {
            var id = 0;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO PEDIDOS(TAMANHO, SABOR, VALOR_FINAL, TEMPO_PREPARO) " +
                " VALUES (@TAMANHO, @SABOR, @VALOR_FINAL, @TEMPO_PREPARO)";
                cmd.Parameters.Add(new SqlParameter("@TAMANHO", SqlDbType.Int)).Value = pedido.Tamanho.Id;
                cmd.Parameters.Add(new SqlParameter("@SABOR", SqlDbType.Int)).Value = pedido.Sabor.Id;
                cmd.Parameters.Add(new SqlParameter("@VALOR_FINAL", SqlDbType.Float)).Value = pedido.ValorTotal;
                cmd.Parameters.Add(new SqlParameter("@TEMPO_PREPARO", SqlDbType.Int)).Value = pedido.TempoPreparo;
                id = executacomando(cmd, "PEDIDOS");

            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }

        public void AlterarPedido(Pedido pedido)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE PEDIDOS " +
                " SET VALOR_FINAL = @VALOR_FINAL, TEMPO_PREPARO = @TEMPO_PREPARO " +
                " WHERE ID_PEDIDO = @ID_PEDIDO ";
                cmd.Parameters.Add(new SqlParameter("@ID_PEDIDO", SqlDbType.Int)).Value = pedido.Id;
                cmd.Parameters.Add(new SqlParameter("@VALOR_FINAL", SqlDbType.Float)).Value = pedido.ValorTotal;
                cmd.Parameters.Add(new SqlParameter("@TEMPO_PREPARO", SqlDbType.Int)).Value = pedido.TempoPreparo;
                executacomando(cmd);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
