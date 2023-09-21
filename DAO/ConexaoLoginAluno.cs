using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Interface;
using Microsoft.VisualBasic.Logging;

namespace ProjetoEscola.DAO
{
    public class ConexaoLoginAluno: ILogin
    {
        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        readonly Conexao con = new();


        public bool TemNoBanco;
        public string? mensagem;

        public static string? Nome;
        public static string? RA;
        public static string? Sala;

        public bool AcessaUsuarios(string login)
        {
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM alunos WHERE Usuario = @login", connAberta);
                comandos.Parameters.AddWithValue("@login", login);
                


                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }

                return TemNoBanco;

            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }
            finally
            {
                con.FecharConexao();
            }

        }

        public bool VerificarAluno(string login, string senha)
        {
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM alunos WHERE Usuario = @login AND Senha = @senha", connAberta);
                comandos.Parameters.AddWithValue("@login", login);
                comandos.Parameters.AddWithValue("@senha", senha);


                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }

                if (dr.Read())
                {
                    Nome = dr["Nome"].ToString();
                    Sala = dr["Sala"].ToString();
                    RA = dr["RA"].ToString();
                }
                
                return TemNoBanco;

            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }
            finally
            {
                con.FecharConexao();
            }
        }    
    }
}
