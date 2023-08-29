using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Interface;
using System.Data;
using ProjetoEscola.Entidades;

namespace ProjetoEscola.CSql
{
    public class LoginComandoProf : IVerificarSeExiste
    {
        readonly string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        MySqlConnection? conexao = null;
        MySqlDataAdapter? da;
        readonly Conexao con = new();

        public static string? Nome;
        public static string? Materia;
        public static string? Id;
        public static string? DataDeNascimento;
        public bool TemNoBanco;
        public string? mensagem;

        public bool Verificar(string login, string senha)
        {
            
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM professor WHERE Login = @login AND Senha = @senha", connAberta);
                comandos.Parameters.AddWithValue("@login", login);
                comandos.Parameters.AddWithValue("@senha", senha);

                MySqlDataAdapter? da = new()
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if(dr.Read())
                {
                    Nome = dr["Nome"].ToString();
                    Materia = dr["Materia"].ToString();
                    DataDeNascimento = dr["Nascimento"].ToString();
                    Id = dr["Id"].ToString();
                }
            




                if (dr.HasRows)
                {
                     TemNoBanco = true;

                }

               

                
            }
            catch (MySqlException) { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }
      
    }
}
