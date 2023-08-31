using MySql.Data.MySqlClient;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using ProjetoEscola.JanelaAluno.Boletim;
using ProjetoEscola.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.CSql
{
    public class ConexaoComSqlBoletim: IExecutavel<BoletimAluno>
    {
        string servidor = "SERVER=localhost;DATABASE=escola;UID=root;PWD=; Persist Security Info=True;database=escola;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        Conexao con = new Conexao();


        public bool TemNoBanco;
        public string? menssagem;
        string? materia = AreaDoProfessor.materia;
        public static DataTable? BoletimDoAluno { get; set; }

        public DataTable ListarDados()
        {
            try
            {
                con.AbrirConexao();

                conexao = new MySqlConnection(servidor);

                comandos = new MySqlCommand("SELECT a.RA, a.Nome, a.Sala, b.Materia, b.Nota1, b.Nota2, b.Nota3, b.Nota4, b.NotaFinal, b.Resultado FROM Alunos a\r\nINNER JOIN Boletim b\r\non a.RA = b.RA\r\nwhere b.RA =a.RA AND b.Materia = @materia\r\norder by a.Sala, a.Nome", conexao);
                comandos.Parameters.AddWithValue("@materia", materia);
                var da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                DataTable TabelaDeNotas = new DataTable();

                da.Fill(TabelaDeNotas);

                con.FecharConexao();

                return TabelaDeNotas;

            }
            catch { throw; }
        }

        public void Salvar(BoletimAluno boletim)
        {
            try
            {
                conexao = new MySqlConnection(servidor);



                var connAberta = con.AbrirConexao();



                comandos = new MySqlCommand("INSERT INTO Boletim VALUES (@ra, @materia, @nota1, @nota2, @nota3, @nota4, @media, @condicao )", connAberta);
                comandos.Parameters.AddWithValue("@ra", boletim.RA);
                comandos.Parameters.AddWithValue("@materia", boletim.Materia);
                comandos.Parameters.AddWithValue("@nota1", boletim.N1);
                comandos.Parameters.AddWithValue("@nota2", boletim.N2);
                comandos.Parameters.AddWithValue("@nota3", boletim.N3);
                comandos.Parameters.AddWithValue("@nota4", boletim.N4);
                comandos.Parameters.AddWithValue("@media", boletim.Media);
                comandos.Parameters.AddWithValue("@condicao", boletim.Resultado);

                comandos.ExecuteNonQuery();

                conexao.Dispose();
            }
            catch { MessageBox.Show("Não foi possivel salvar as notas do aluno(a)"); return; }

        }

        public void Editar(BoletimAluno boletim)
        {
            try
            {
                conexao = new MySqlConnection(servidor);



                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("UPDATE Boletim SET Nota1 = @nota1, Nota2 = @nota2, Nota3 = @nota3, Nota4 = @nota4, NotaFinal = @media, Resultado = @condicao, Materia = @materia WHERE RA = @ra", connAberta);
                comandos.Parameters.AddWithValue("@ra", boletim.RA);
                comandos.Parameters.AddWithValue("@materia", boletim.Materia);
                comandos.Parameters.AddWithValue("@nota1", boletim.N1);
                comandos.Parameters.AddWithValue("@nota2", boletim.N2);
                comandos.Parameters.AddWithValue("@nota3", boletim.N3);
                comandos.Parameters.AddWithValue("@nota4", boletim.N4);
                comandos.Parameters.AddWithValue("@media", boletim.Media);
                comandos.Parameters.AddWithValue("@condicao", boletim.Resultado);

                comandos.ExecuteNonQuery();

                MessageBox.Show("Nota editada com sucesso");

            }
            catch { MessageBox.Show("Não foi possivel Editar as notas do aluno(a)"); }
        }

        public void Excluir(BoletimAluno boletim)
        {
            try
            {
                conexao = new MySqlConnection(servidor);



                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("DELETE FROM Boletim WHERE RA = @ra AND Materia = @materia", connAberta);
                comandos.Parameters.AddWithValue("@ra", boletim.RA);
                comandos.Parameters.AddWithValue("@materia", boletim.Materia);

                MessageBox.Show("Notas excluidas com sucesso");

                comandos.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Não foi possivel excluir as notas"); }
        }

        //Aqui o programa vai especificar um aluno especifico
        public bool Verificar(int ra)
        
        {
            try
            {
                conexao = new MySqlConnection(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                

                comandos = new MySqlCommand("SELECT Materia, Nota1, Nota2, Nota3, Nota4, NotaFinal, Resultado FROM boletim WHERE RA LIKE @ra;", connAberta);
                comandos.Parameters.AddWithValue("@ra", ra);
                

                var da = new MySqlDataAdapter();

                da.SelectCommand = comandos;              

                BoletimDoAluno = new DataTable();

                da.Fill(BoletimDoAluno);

                dr = comandos.ExecuteReader();
               

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }               

            }
            catch { this.menssagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }

        public bool VerificarBoletim( int ra, string materia)
        {
            try
            {
                conexao = new MySqlConnection(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();



                comandos = new MySqlCommand("SELECT * FROM boletim WHERE RA LIKE @ra and Materia LIKE @materia;", connAberta);
                comandos.Parameters.AddWithValue("@ra", ra);
                comandos.Parameters.AddWithValue("@materia", materia);



                var da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    TemNoBanco = true;
                }
                else
                {
                    TemNoBanco = false;
                }

            }
            catch { this.menssagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }

            return TemNoBanco;
        }
    }
}
