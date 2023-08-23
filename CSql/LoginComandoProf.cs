using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Interface;

namespace ProjetoEscola.CSql
{
    public class LoginComandoProf: IVerificarUsuarios
    {
        string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlConnection conexao = null;
        MySqlCommand comandos;
        MySqlDataReader dr;
        Conexao con = new Conexao();


        public bool TemNoBanco;
        public string? mensagem;

        public bool VerificarLogin(string login, string senha)
        {
            try
            {
                conexao = new MySqlConnection(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM professor WHERE Login = @login AND Senha = @senha", connAberta);
                comandos.Parameters.AddWithValue("@login", login);
                comandos.Parameters.AddWithValue("@senha", senha);


                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                dr = comandos.ExecuteReader();


                

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
