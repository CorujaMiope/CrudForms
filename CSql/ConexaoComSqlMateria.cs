using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.CSql
{
    public class ConexaoComSqlMateria
    {
        string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlConnection conexao = null;
        MySqlCommand comandos;
        Conexao con = new Conexao();

        public DataTable ListarMaterias()
        {
            try
            {

                conexao = new MySqlConnection(servidor);

                 con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM Materias", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                DataTable dtMaterias = new DataTable();

                da.Fill(dtMaterias);

              

                return dtMaterias;

            }
            catch (Exception) { throw; }
        }
    }
}
