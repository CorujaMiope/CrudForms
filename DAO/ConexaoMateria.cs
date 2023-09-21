using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.DAO
{
    public class ConexaoMateria
    {
        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        readonly Conexao con = new();

        public DataTable ListarMaterias()
        {
            try
            {

                conexao = new MySqlConnection(servidor);

                 con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM Materias order by Materia", conexao);

                MySqlDataAdapter da = new()
                {
                    SelectCommand = comandos
                };

                DataTable dtMaterias = new();

                da.Fill(dtMaterias);

              

                return dtMaterias;

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
