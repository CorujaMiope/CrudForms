using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using ProjetoEscola.Interface;


namespace ProjetoEscola.DAO
{
    public class ConexaoLoginAdmin
    {
        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        MySqlDataAdapter da;
        MySqlDataReader dr;
        MySqlConnection? conexao;
        Conexao con = new();
        MySqlCommand? comandos;

        public bool VerificarSeExisteEmail(string email)
        {
            try
            {
                bool TemNoBanco;

                conexao = new(servidor);
                con.AbrirConexao();
                var connAberta = con.AbrirConexao();
                

                comandos = new MySqlCommand("SELECT * FROM Diretor WHERE Login = @log",connAberta);
                comandos.Parameters.AddWithValue("@log", email);
                

                comandos.ExecuteNonQuery();

                da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                return (dr.HasRows) ? true : false; 
                

               

            }catch { throw; }
            finally
            {
                con.FecharConexao();
            }
            
        }

        public bool VerificarSeExisteUsuarioEsenha(string email, string senha)
        {
            try
            {
               

                conexao = new(servidor);
                con.AbrirConexao();
                var connAberta = con.AbrirConexao();


                comandos = new MySqlCommand("SELECT * FROM Diretor WHERE Login = @log AND Senha = @senha", connAberta);
                comandos.Parameters.AddWithValue("@log", email);
                comandos.Parameters.AddWithValue("@senha", senha);

                comandos.ExecuteNonQuery();

                da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                return dr.HasRows;
                

              

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }

        }

    }
}
