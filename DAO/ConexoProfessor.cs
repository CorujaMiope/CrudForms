﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;

namespace ProjetoEscola.DAO
{
    public class ConexoProfessor: IPersistenciaDeDados<Professor>
    {

        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        readonly Conexao con = new();

        public bool TemNoBanco;
        public string? mensagem;



        public DataTable Listar()
        {
            try
            {

                
                con.AbrirConexao();

                conexao = new MySqlConnection(servidor);

                comandos = new MySqlCommand("SELECT * FROM professor order by Nome", conexao);

                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                DataTable dtProfs = new();

                da.Fill(dtProfs);



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
               

                
                
                comandos = new MySqlCommand("INSERT INTO professor VALUES (@id, @nome, @sexo, @nascimento, @materia, @login, @senha)", connAberta);
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

                if (!string.IsNullOrEmpty(professor.Nome))
                {
                    comandos = new MySqlCommand("UPDATE professor SET Nome = @nome WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@nome", professor.Nome);

                    comandos.ExecuteNonQuery();
                }
                if (!string.IsNullOrEmpty(professor.Nascimento.ToString()))
                {
                    comandos = new MySqlCommand("UPDATE professor SET Nascimento =  @nascimento WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@nascimento", professor.Nascimento);

                    comandos.ExecuteNonQuery();
                }

                if(!string.IsNullOrEmpty(professor.Sexo))
                {
                    comandos = new MySqlCommand("UPDATE professor SET Sexo = @sexo WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@sexo", professor.Sexo);

                    comandos.ExecuteNonQuery();
                }
                
                if(!string.IsNullOrEmpty(professor.Materia))
                {
                    comandos = new MySqlCommand("UPDATE professor SET Materia = @materia WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@materia", professor.Materia);

                    comandos.ExecuteNonQuery();
                }
                
                if(!string.IsNullOrEmpty(professor.Usuario))
                {
                    comandos = new MySqlCommand("UPDATE professor SET  Usuario = @login WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@login", professor.Usuario);

                    comandos.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(professor.Senha))
                {
                    comandos = new MySqlCommand("UPDATE professor SET  Senha = @senha WHERE Id = @id", connAberta);

                    comandos.Parameters.AddWithValue("@id", professor.ID);
                    comandos.Parameters.AddWithValue("@senha", professor.Senha);

                    comandos.ExecuteNonQuery();
                }
 
                
                

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

                comandos = new MySqlCommand("SELECT * FROM professor WHERE Id LIKE @id", connAberta);
                comandos.Parameters.AddWithValue("@id", id);



                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }
            finally
            {
                con.FecharConexao();
            }


        }

        
    }
}
