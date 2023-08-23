using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;

namespace ProjetoEscola.CSql
{
    public class ConnectBancoProfs: IExecutavel<Professor>
    {

        string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlConnection conexao = null;
        MySqlCommand comandos;
        Conexao con = new Conexao();

        

        public DataTable ListarDados()
        {
            try
            {

                
                con.AbrirConexao();

                conexao = new MySqlConnection(servidor);

                comandos = new MySqlCommand("SELECT * FROM professor order by Nome", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                DataTable dtProfs = new DataTable();

                da.Fill(dtProfs);



                return dtProfs;

            }
            catch (Exception) { throw; }
        }

        

        public void Salvar( Professor professor)
        { 
            try
            { 
                var connAberta = con.AbrirConexao();
               

                
                
                comandos = new MySqlCommand("INSERT INTO professor (Id, Nome, Sexo, Nascimento, Materia) VALUES (@id, @nome, @sexo, @nascimento, @materia, @email, @senha)", connAberta);
                comandos.Parameters.AddWithValue("@id",professor.ID );
                comandos.Parameters.AddWithValue("@nome", professor.Nome);
                comandos.Parameters.AddWithValue("@sexo", professor.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", professor.Nascimento);
                comandos.Parameters.AddWithValue("@materia", professor.Materia);
                comandos.Parameters.AddWithValue("@email", professor.Usuario);
                comandos.Parameters.AddWithValue("@senha", professor.Senha);

                comandos.ExecuteNonQuery();
                comandos.Dispose();


            }catch (Exception) { throw; }
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

                comandos = new MySqlCommand("UPDATE professor SET   Nome = @nome , Sexo =  @sexo, Nascimento =  @nascimento, Materia = @materia, Email = @email, Senha = @senha WHERE Id = @id", connAberta);
                comandos.Parameters.AddWithValue("@id",professor.ID);
                comandos.Parameters.AddWithValue("@nome", professor.Nome);
                comandos.Parameters.AddWithValue("@sexo", professor.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", professor.Nascimento);
                comandos.Parameters.AddWithValue("@materia", professor.Materia);
                comandos.Parameters.AddWithValue("@email", professor.Usuario);
                comandos.Parameters.AddWithValue("@senha", professor.Senha);

                comandos.ExecuteNonQuery();
                

            }
            catch (Exception) { throw; };
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
            catch (Exception) { throw; }
        }

       
    }
}
