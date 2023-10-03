using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using ProjetoEscola.View;
using ProjetoEscola.ViewModel;
using System.Data;


namespace ProjetoEscola.DAO
{
    public class ConexaoBoletim: IPersistenciaDeDados<Boletim>
    {
        string servidor = "SERVER=localhost;DATABASE=SistemaEscolar;UID=root;PWD=; Persist Security Info=True;database=SistemaEscolar;Convert Zero Datetime=True";
        MySqlConnection? conexao = null;
        MySqlCommand? comandos;
        MySqlDataReader? dr;
        Conexao con = new Conexao();


        public bool TemNoBanco;
        public string? menssagem;
        string? materia = AreaDoProfessor.materia;
        public static DataTable? BoletimDoAluno { get; set; }
        
       

        

        public List<AlunoNotasVM> Listar()
        {
            List<AlunoNotasVM> alunoNotasVMs = new List<AlunoNotasVM>();

            try
            {
                
              
                

                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand(@"SELECT a.RA, a.Nome, a.Sala, b.Materia, b.Nota1, b.Nota2, b.Nota3, b.Nota4, b.NotaFinal, b.Resultado FROM Alunos a
                                            INNER JOIN Boletim b
                                            on a.RA = b.RA
                                            where b.Materia = @materia
                                            order by a.Sala, a.Nome;", connAberta);
                comandos.Parameters.AddWithValue("@materia", materia);
               
              
                dr = comandos.ExecuteReader();

               
                while(dr.Read())
                {
                    int ra = Convert.ToInt32(dr["RA"]);
                    string nome = dr["Nome"].ToString();
                    string sala = dr["Sala"].ToString();
                    string materia = dr["Materia"].ToString();
                    double n1 = Convert.ToDouble(dr["Nota1"]);
                    double n2 = Convert.ToDouble(dr["Nota2"]);
                    double n3 = Convert.ToDouble(dr["Nota3"]);
                    double n4 = Convert.ToDouble(dr["Nota4"]);
                    double media = Convert.ToDouble(dr["NotaFinal"]);
                    string resultado = dr["Resultado"].ToString();

                    AlunoNotasVM notavm = new AlunoNotasVM(ra,nome,sala,materia,n1,n2,n3,n4,media,resultado);
                    alunoNotasVMs.Add(notavm);
                }
                return alunoNotasVMs;

               

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        public List<AlunoNotasVM> ListarAlunosEspecifico()
        {
            List<AlunoNotasVM> alunoNotasVMs = new List<AlunoNotasVM>();

            try
            {
                

                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand(@"SELECT b.Materia, b.Nota1, b.Nota2, b.Nota3, b.Nota4, b.NotaFinal, b.Resultado FROM Alunos a
                                            INNER JOIN Boletim b
                                            on a.RA = b.RA
                                            WHERE b.RA = @ra
                                            order by a.Sala, a.Nome;", connAberta);
                comandos.Parameters.AddWithValue("@ra",ConexaoLoginAluno.RA);
                var da = new MySqlDataAdapter();

                dr = comandos.ExecuteReader();


                while (dr.Read())
                {
                    
                    string materia = dr["Materia"].ToString();
                    double n1 = Convert.ToDouble(dr["Nota1"]);
                    double n2 = Convert.ToDouble(dr["Nota2"]);
                    double n3 = Convert.ToDouble(dr["Nota3"]);
                    double n4 = Convert.ToDouble(dr["Nota4"]);
                    double media = Convert.ToDouble(dr["NotaFinal"]);
                    string resultado = dr["Resultado"].ToString();

                    AlunoNotasVM notavm = new(materia, n1, n2, n3, n4, media, resultado);
                    alunoNotasVMs.Add(notavm);
                }
                return alunoNotasVMs;

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        public void Salvar(Boletim boletim)
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
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }

        }

        public void Editar(Boletim boletim)
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

                

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        public void Excluir(Boletim boletim)
        {
            try
            {
                conexao = new MySqlConnection(servidor);



                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("DELETE FROM Boletim WHERE RA = @ra AND Materia = @materia", connAberta);
                comandos.Parameters.AddWithValue("@ra", boletim.RA);
                comandos.Parameters.AddWithValue("@materia", boletim.Materia);
              
                comandos.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }
        }

        //Aqui o programa vai especificar um aluno especifico
        public bool VerificarIdentificador(int ra)
        
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
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }

            return TemNoBanco;
        }

        public bool VerificarBoletim( int ra, string materia)
        {
            try
            {
                conexao = new MySqlConnection(servidor);

                con.AbrirConexao();
                var connAberta = con.AbrirConexao();

                comandos = new MySqlCommand("SELECT * FROM boletim WHERE RA = @ra and Materia = @materia;", connAberta);
                comandos.Parameters.AddWithValue("@ra", ra);
                comandos.Parameters.AddWithValue("@materia", materia);

                var da = new MySqlDataAdapter();

                da.SelectCommand = comandos;

                dr = comandos.ExecuteReader();

                if (dr.HasRows)
                {
                    return TemNoBanco = true;
                }
                else
                {
                    return TemNoBanco = false;
                }

            }
            catch { throw; }
            finally
            {
                con.FecharConexao();
            }          
        }
    }
}
