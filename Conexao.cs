using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola
{
    public class Conexao
    {
        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        public MySqlConnection? conexao;

        public MySqlConnection AbrirConexao()
        {
            try
            {
                var conn = new MySqlConnection(servidor);
                conn.Open();

                return conn;
            }
            catch (MySqlException ex) { throw; MessageBox.Show("Erro" + ex.Message);  }
        }

        public void FecharConexao()
        {
            try
            {
                
                conexao = new MySqlConnection(servidor);
                conexao.Close();
            }
            catch { throw; }

           
        }
    }
}
