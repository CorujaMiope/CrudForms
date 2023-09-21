using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Interface;
using System.Data;
using ProjetoEscola.Entidades;
using Microsoft.VisualBasic.Logging;

namespace ProjetoEscola.CSql
{
    public class ConexaoLoginProf : ILogin
    {
        readonly string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        readonly MySqlConnection? conexao = null;
        MySqlDataAdapter? da;
        readonly Conexao con = new();

        public static string? Nome;
        public static string? Materia;
        public static string? Id;
        public static string? DataDeNascimento;
        public static string? Sexo;
        public bool TemNoBanco;
        public string? mensagem;

        public bool AcessarAluno(string login)
        {
            
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM professor WHERE Login = @login", connAberta);
                comandos.Parameters.AddWithValue("@login", login);
                

                MySqlDataAdapter? da = new()
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

 
                if (dr.HasRows)
                {
                     TemNoBanco = true;

                }               
                
            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }

        internal bool VerificarProf(string email, string senha)
        {
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM professor WHERE Login = @login AND Senha = @senha", connAberta);
                comandos.Parameters.AddWithValue("@login", email);
                comandos.Parameters.AddWithValue("@senha", senha);


                MySqlDataAdapter? da = new()
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.Read())
                {
                    Nome = dr["Nome"].ToString();
                    Materia = dr["Materia"].ToString();
                    DataDeNascimento = dr["Nascimento"].ToString();
                    Id = dr["Id"].ToString();
                    Sexo = dr["Sexo"].ToString();
                }

                if (dr.HasRows)
                {
                    TemNoBanco = true;

                }

            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }
    }
}
