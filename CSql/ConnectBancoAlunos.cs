﻿using MySql.Data.MySqlClient;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using System.Data;


namespace ProjetoEscola.CSql
{
    public class ConnectBancoAlunos : IExecutavel<Aluno>
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

                comandos = new MySqlCommand("SELECT * FROM alunos order by Sala,Nome", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                DataTable dtAlunos = new DataTable();
                
                da.Fill(dtAlunos);

                con.FecharConexao();

                return dtAlunos;

            }catch (Exception ) { throw; }
        }

        public void Salvar(Aluno aluno)
        {
            try
            {
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("INSERT INTO alunos VALUES (@ra, @nome, @sexo, @nascimento, @sala, @login, @senha)", connAberta);
                comandos.Parameters.AddWithValue("@ra", aluno.RA);
                comandos.Parameters.AddWithValue("@nome", aluno.Nome);
                comandos.Parameters.AddWithValue("@sexo", aluno.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                comandos.Parameters.AddWithValue("@sala", aluno.Sala);
                comandos.Parameters.AddWithValue("@login", aluno.Usuario);
                comandos.Parameters.AddWithValue("@senha", aluno.Senha);

                comandos.ExecuteNonQuery();
            }
            catch (Exception ex ) { MessageBox.Show("Erro ao salvar" + ex); }
        }

        public void Editar(Aluno aluno)
        {
            try
            {
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("UPDATE alunos SET Nome = @nome, Sexo = @sexo, Nascimento = @nascimento, Sala = @sala, Login = @login, Senha = @senha WHERE RA = @ra", connAberta);

                comandos.Parameters.AddWithValue("@ra", aluno.RA);
                comandos.Parameters.AddWithValue("@nome", aluno.Nome);
                comandos.Parameters.AddWithValue("@sexo", aluno.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                comandos.Parameters.AddWithValue("@sala", aluno.Sala);
                comandos.Parameters.AddWithValue("@login", aluno.Usuario);
                comandos.Parameters.AddWithValue("senha", aluno.Senha);

                comandos.ExecuteNonQuery();

            }
            catch (Exception) { throw; }

            
        }

        public void Excluir(Aluno aluno)
        {
            try
            {
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("DELETE FROM alunos WHERE RA = @ra", connAberta);
                comandos.Parameters.AddWithValue("@ra", aluno.RA);

                comandos.ExecuteNonQuery();

            }
            catch(Exception) { throw; }
        }
    }
}
