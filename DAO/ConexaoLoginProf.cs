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
using ProjetoEscola.Windows.CriptografarSenha;

namespace ProjetoEscola.DAO
{
    public class ConexaoLoginProf : ILogin
    {
        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
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

        public bool AcessaUsuarios(string login)
        {
            
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM professor WHERE Usuario = @login", connAberta);
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
                
                return TemNoBanco;            
                
            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }
            finally
            {
                con.FecharConexao();
            }

        }

       
        public string senha2;
        internal bool VerificarSeExistUsuario(string usuario, string senha1)
        {
            var cripto = new Criptografar();

            var connAberta = con.AbrirConexao();

            comandos = new MySqlCommand("SELECT * FROM Professor WHERE Usuario = @usuario", connAberta);
            comandos.Parameters.AddWithValue("@usuario", usuario);

            dr = comandos.ExecuteReader();

            

            if (dr.Read())
            {
                Nome = dr["Nome"].ToString();
                Materia = dr["Materia"].ToString();
                DataDeNascimento = dr["Nascimento"].ToString();
                Id = dr["Id"].ToString();
                Sexo = dr["Sexo"].ToString();

                senha2 = dr["Senha"].ToString();
            }

            var senhaCripto = cripto.CriptografarSenha(senha1);

            return senhaCripto == senha2 ? true : false;
        }

        internal bool VarificarUsuarioComID(string usuario, int id)
        {
            var connAberta = con.AbrirConexao();

            comandos = new MySqlCommand(@"SELECT * FROM Professor
                                        WHERE Usuario = @usuario
                                        AND Id = @id", connAberta);

            comandos.Parameters.AddWithValue("@usuario", usuario);
            comandos.Parameters.AddWithValue("@id", id);

            dr = comandos.ExecuteReader();

           return dr.HasRows ? true : false;
          

            
        }
    }
}
