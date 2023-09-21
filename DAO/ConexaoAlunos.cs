using MySql.Data.MySqlClient;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using System.Data;


namespace ProjetoEscola.DAO
{
    public class ConexaoAlunos : IPersistenciaDeDados<Aluno>
    {
        readonly string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        readonly Conexao con = new();
        MySqlDataReader? dr;

        public bool temNoBanco;
        public string? mensagem;

        public DataTable Listar()
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
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
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
            catch { MessageBox.Show("Erro ao salvar"); }

        }

        public void Editar(Aluno aluno)
        {
            try
            {
                var connAberta = con.AbrirConexao();

                if (!string.IsNullOrEmpty(aluno.Nome))
                {
                    comandos = new MySqlCommand("UPDATE alunos SET Nome = @nome WHERE RA = @ra", connAberta);

                    comandos.Parameters.AddWithValue("@ra", aluno.RA);
                    comandos.Parameters.AddWithValue("@nome", aluno.Nome);
                    comandos.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(aluno.Sexo))
                {
                    comandos = new MySqlCommand("UPDATE alunos SET Sexo = @sexo WHERE RA = @ra", connAberta);

                    comandos.Parameters.AddWithValue("@ra", aluno.RA);
                    comandos.Parameters.AddWithValue("@sexo", aluno.Sexo);
                    comandos.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty((aluno.Nascimento.ToString())))
                {
                    comandos = new MySqlCommand("UPDATE alunos SET Nascimento = @nascimento WHERE RA = @ra", connAberta);

                    comandos.Parameters.AddWithValue("@ra", aluno.RA);
                    comandos.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                    comandos.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(aluno.Sala))
                {
                    comandos = new MySqlCommand("UPDATE alunos SET Sala = @sala WHERE RA = @ra", connAberta);

                    comandos.Parameters.AddWithValue("@ra", aluno.RA);
                    comandos.Parameters.AddWithValue("@sala", aluno.Sala);
                    comandos.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(aluno.Usuario))
                {
                    comandos = new MySqlCommand("UPDATE alunos SET Usuario = @login WHERE RA = @ra", connAberta);

                    comandos.Parameters.AddWithValue("@ra", aluno.RA);
                    comandos.Parameters.AddWithValue("@login", aluno.Usuario);
                    comandos.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(aluno.Senha))
                {
                    comandos = new MySqlCommand("UPDATE alunos SET Senha = @senha WHERE RA = @ra", connAberta);

                    comandos.Parameters.AddWithValue("@ra", aluno.RA);
                    comandos.Parameters.AddWithValue("senha", aluno.Senha);
                    comandos.ExecuteNonQuery();
                }



            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }

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
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        public bool VerificarIdentificador(int ra)
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
                    temNoBanco = true;
                }


                return temNoBanco;

            }
            catch { this.mensagem = "Erro ao se conectar ao banco"; MessageBox.Show("Erro ao se conectar ao banco"); throw; }
            finally
            {
                con.FecharConexao();
            }

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
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
