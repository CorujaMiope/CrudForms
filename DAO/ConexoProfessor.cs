using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using System.Security.Cryptography;

namespace ProjetoEscola.DAO
{
    public class ConexoProfessor: IPersistenciaDeDados<Professor>
    {

        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        readonly Conexao con = new();

      
        public string? mensagem;




        public List<Professor> Listar()
        {
            try
            {


                var connAberta = con.AbrirConexao();

               
                comandos = new MySqlCommand("SELECT * FROM professor order by Nome", connAberta);

                dr = comandos.ExecuteReader();

                List<Professor> dtProfs = new();

                while(dr.Read())
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    DateTime idade = Convert.ToDateTime(dr["Nascimento"]);
                    string nome = dr["Nome"].ToString();
                    string sexo = dr["Sexo"].ToString();
                    string materia = dr["Materia"].ToString();
                    string Usuario = dr["Usuario"].ToString();
                    string Senha = dr["Senha"].ToString();

                    Professor professor = new Professor(id, nome, idade, sexo, materia, Usuario, Senha);
                                          
                    dtProfs.Add(professor);

                      
                }

                return dtProfs;

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }


        public void Salvar( Professor professor)
        { 
            try
            { 
                var connAberta = con.AbrirConexao();
               

                
                
                comandos = new MySqlCommand(@"INSERT INTO professor 
                                            VALUES (@id, @nome, @sexo, @nascimento, @materia, @login, MD5(@senha))", connAberta);
                comandos.Parameters.AddWithValue("@id",professor.ID );
                comandos.Parameters.AddWithValue("@nome", professor.Nome);
                comandos.Parameters.AddWithValue("@sexo", professor.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", professor.Nascimento);
                comandos.Parameters.AddWithValue("@materia", professor.Materia);
                comandos.Parameters.AddWithValue("@login", professor.Usuario);
                comandos.Parameters.AddWithValue("@senha", professor.Senha);

                comandos.ExecuteNonQuery();
                comandos.Dispose();


            }catch { throw; }
            finally
            {
                con.FecharConexao();
            }
           
        }
        
        public void Editar(Professor professor)
        {
            try
            { 
                    var connAberta = con.AbrirConexao();
                
                    comandos = new MySqlCommand(@"UPDATE professor SET Nome = @nome,  Sexo = @sexo,  Nascimento =  @nascimento, Materia = @materia,  Usuario = @login, Senha = MD5(@senha)  
                                                WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@nome", professor.Nome);
                    comandos.Parameters.AddWithValue("@sexo", professor.Sexo);
                    comandos.Parameters.AddWithValue("@nascimento", professor.Nascimento);
                    comandos.Parameters.AddWithValue("@materia", professor.Materia);
                    comandos.Parameters.AddWithValue("@login", professor.Usuario);
                    comandos.Parameters.AddWithValue("@senha", professor.Senha);
                    comandos.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        public void Excluir(Professor professor)
        {
            try
            {
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("DELETE FROM professor WHERE Id = @id", connAberta);
                comandos.Parameters.AddWithValue("@id", professor.ID);

                comandos.ExecuteNonQuery();

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        public bool VerificarIdentificador(int id)
        {

            try
            {
                
                conexao = new MySqlConnection(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand(@"SELECT * FROM professor 
                                            WHERE Id LIKE @id", connAberta);
                comandos.Parameters.AddWithValue("@id", id);



                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                return (dr.HasRows) ? true : false;
                

            }
            catch {  throw; }
            finally
            {
                con.FecharConexao();
            }


        }

        
    }
}
