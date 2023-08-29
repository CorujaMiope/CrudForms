﻿using MySql.Data.MySqlClient;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using System.Data;


namespace ProjetoEscola.CSql
{
    public class ConexaoComSqlAlunos : IExecutavel<Aluno>
    {
        readonly string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        readonly Conexao con = new();
        MySqlDataReader? dr;

        public bool TemNoBanco;
        public string? mensagem;

        public DataTable ListarDados()
        {
            try
            {
                con.AbrirConexao();

                conexao = new MySqlConnection(servidor);

                comandos = new MySqlCommand("SELECT * FROM alunos order by Sala,Nome", conexao);

                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                DataTable dtAlunos = new();

                da.Fill(dtAlunos);

                con.FecharConexao();

                return dtAlunos;

            }
            catch (Exception) { throw; }
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
            catch (Exception ex) { MessageBox.Show("Erro ao salvar" + ex); }
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
            catch (Exception) { throw; }
        }

        public bool Verificar(int ra)
        {


            try
            {
                conexao = new MySqlConnection(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM alunos WHERE RA LIKE @ra", connAberta);
                comandos.Parameters.AddWithValue("@ra", ra);



                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }

            }
            catch (MySqlException) { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }

        public DataTable ListarDadosBasicos()
        {
            try
            {
                con.AbrirConexao();

                conexao = new MySqlConnection(servidor);

                comandos = new MySqlCommand("SELECT Sala, Nome, RA FROM alunos order by Sala,Nome", conexao);

                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                DataTable dtAlunos = new();

                da.Fill(dtAlunos);

                con.FecharConexao();

                return dtAlunos;

            }
            catch (Exception) { throw; }
        }
    }
}