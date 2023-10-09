using MySql.Data.MySqlClient;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using ProjetoEscola.ViewModel;
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
        
        public static List <Aluno> alunos = new List<Aluno>();

        
        public List<Aluno> Listar()
        {
            try
            {
                var connAberta =con.AbrirConexao();

             

                comandos = new MySqlCommand("SELECT * FROM alunos order by Sala,Nome", connAberta);

                dr = comandos.ExecuteReader();
                
                

                while (dr.Read())
                {
                  
                    int ra = Convert.ToInt32(dr["RA"]);
                    string nome = dr["Nome"].ToString();
                    DateTime nascimento = Convert.ToDateTime(dr["Nascimento"]);
                    string sexo = dr["Sexo"].ToString();
                    string sala = dr["sala"].ToString();
                    string usuario = dr["Usuario"].ToString();
                    string senha = dr["Senha"].ToString();
                    
                    Aluno aluno = new Aluno(ra, nome, nascimento, sexo, sala, usuario, senha);

                    alunos.Add(aluno);
                }

                return alunos;

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

                comandos = new MySqlCommand(@"INSERT INTO alunos 
                                            VALUES (@ra, @nome, @sexo, @nascimento, @sala, @login, MD5(@senha))", connAberta);

                comandos.Parameters.AddWithValue("@ra", aluno.RA);
                comandos.Parameters.AddWithValue("@nome", aluno.Nome);
                comandos.Parameters.AddWithValue("@sexo", aluno.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                comandos.Parameters.AddWithValue("@sala", aluno.Sala);
                comandos.Parameters.AddWithValue("@login", aluno.Usuario);
                comandos.Parameters.AddWithValue("@senha", aluno.Senha);

                comandos.ExecuteNonQuery();
            }
            catch { throw; }

        }

        public void Editar(Aluno aluno)
        {
            try
            {
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand(@"UPDATE alunos SET Nome = @nome, Sexo = @sexo, Nascimento = @nascimento, Sala = @sala, Usuario = @usuario, Senha = MD5(@senha) 
                                            WHERE RA = @ra", connAberta);

                comandos.Parameters.AddWithValue("@ra", aluno.RA);
                comandos.Parameters.AddWithValue("@nome", aluno.Nome);
                comandos.Parameters.AddWithValue("@sexo", aluno.Sexo);
                comandos.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
                comandos.Parameters.AddWithValue("@sala", aluno.Sala);
                comandos.Parameters.AddWithValue("@usuario", aluno.Usuario);
                comandos.Parameters.AddWithValue("@senha", aluno.Senha);

                comandos.ExecuteNonQuery();
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

                comandos = new MySqlCommand(@"SELECT * FROM alunos 
                                            WHERE RA LIKE @ra", connAberta);
                comandos.Parameters.AddWithValue("@ra", ra);



                var da = new MySqlDataAdapter
                {
                    SelectCommand = comandos
                };

                dr = comandos.ExecuteReader();

                return dr.HasRows;
                


                return temNoBanco;

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }

        }

        public List<Aluno> ListarDadosBasicos()
        {
            try
            {
                List<Aluno> alunoList = new();

                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT Sala, Nome, RA FROM alunos order by Sala,Nome", connAberta);
                
                dr = comandos.ExecuteReader();

                while(dr.Read())
                {
                    int ra = Convert.ToInt32(dr["RA"]);
                    string nome = dr["Nome"].ToString();
                    string sala = dr["Sala"].ToString();

                    Aluno aluno = new(ra,nome,sala);

                    alunoList.Add(aluno);
                }

                return alunoList;

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        
    }
}
