using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Infraestrutura.Properties;

namespace Infraestrutura.Acesso
{
    public class Dados
    {
        public String strconexao { get; set; }
        public SqlConnection con { get; set; }
        public DataTable tab { get; set; }
        public SqlCommand cmd { get; set; }

        private String server = Settings.Default.Servidor;
        private String database = Settings.Default.Base;
        private String usuario = Settings.Default.Usuario;
        private String senha = Settings.Default.Senha;

        public Dados()
        {
            strconexao = "server=" + server + ";" +
               " initial catalog=" + database + ";" +
               "user=" + usuario + ";password=" + senha + ";";
            con = new SqlConnection(strconexao);

        }

        private void abreConexao()
        {
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void fechaConexao()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void executacomando(SqlCommand cmd)
        {
            try
            {
                abreConexao();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                fechaConexao();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int executacomando(SqlCommand cmd, String nometabela)
        {
            int codigo = 0;
            try
            {
                cmd.CommandText += ";SELECT SCOPE_IDENTITY() "
                    + nometabela;
                abreConexao();
                cmd.Connection = con;
                codigo = int.Parse(cmd.ExecuteScalar().ToString());
                fechaConexao();
            }
            catch (Exception)
            {

                throw;
            }
            return codigo;
        }

        public DataTable executaconsulta(SqlCommand cmd)
        {
            DataTable tab = null;
            try
            {
                tab = new DataTable();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tab);
                da = null;
            }
            catch (Exception)
            {

                throw;
            }
            return tab;

        }
        
    }
}
