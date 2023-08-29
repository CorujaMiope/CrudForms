using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola
{
    internal class Conexao
    {
        readonly string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        public MySqlConnection? conexao;

        public MySqlConnection AbrirConexao()
        {
            try
            {
                var conn = new MySqlConnection(servidor);
                conn.Open();

                return conn;
            }
            catch (Exception )  { throw; }
        }

        public void FecharConexao()
        {
            try
            {
                
                conexao = new MySqlConnection(servidor);
                conexao.Close();
            }
            catch (Exception) { throw; }

           
        }
    }
}
