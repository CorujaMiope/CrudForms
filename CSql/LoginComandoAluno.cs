﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Interface;
using Microsoft.VisualBasic.Logging;

namespace ProjetoEscola.CSql
{
    public class LoginComandoAluno: IVerificarSeExiste
    {
        readonly string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        readonly Conexao con = new();


        public bool TemNoBanco;
        public string? mensagem;

        public bool Verificar(string login, string senha)
        {
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM alunos WHERE Login = @login AND Senha = @senha", connAberta);
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

            }
            catch (MySqlException) { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }

        public bool VerificarRA(int ra)
        {
            try
            {
                MySqlConnection conexao = new(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM alunos WHERE RA LIKE @ra", connAberta);
                comandos.Parameters.AddWithValue("@ra", ra);



                MySqlDataAdapter da = new()
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
    }
}
