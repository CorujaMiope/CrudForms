using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using ProjetoEscola.Interface;


namespace ProjetoEscola.CSql
{
    public class ConexaoLoginAdmin
    {
        readonly string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlDataAdapter da;
        MySqlDataReader dr;
        MySqlConnection? conexao;
        Conexao con = new();
        MySqlCommand? comandos;

        public bool AcessarAdmin(string email)
        {
            try
            {
                bool TemNoBanco;

                conexao = new(servidor);
                con.AbrirConexao();
                var connAberta = con.AbrirConexao();
                

                comandos = new MySqlCommand("SELECT * FROM Diretor WHERE login = @log",connAberta);
                comandos.Parameters.AddWithValue("@log", email);
                

                comandos.ExecuteNonQuery();

                da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }
                else
                {
                    TemNoBanco = false;
                }

                return TemNoBanco;

            }catch { throw; }
            finally
            {
                con.FecharConexao();
            }
            
        }

        public bool VerificarAdmin(string email, string senha)
        {
            try
            {
                bool TemNoBanco;

                conexao = new(servidor);
                con.AbrirConexao();
                var connAberta = con.AbrirConexao();


                comandos = new MySqlCommand("SELECT * FROM Diretor WHERE login = @log AND senha = @senha", connAberta);
                comandos.Parameters.AddWithValue("@log", email);
                comandos.Parameters.AddWithValue("@senha", senha);

                comandos.ExecuteNonQuery();

                da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }
                else
                {
                    TemNoBanco = false;
                }

                return TemNoBanco;

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }

        }

    }
}
