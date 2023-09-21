using ProjetoEscola.CSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Model
{
    public class AcessarUsuario
    {
        public bool TemUsuario;
        public string? mensagem;

        public bool AcessarAdiministrador(string email)
        {
            try
            {
                var admin = new ConexaoLoginAdmin();

                TemUsuario = admin.AcessarAdmin(email);


            }
            catch (Exception) { throw; }

            return TemUsuario;
        }

        public bool VerificarAdiministrador(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginAdmin();

                TemUsuario = admin.VerificarAdmin(email, senha);


            }
            catch (Exception) { throw; }

            return TemUsuario;
        }

        public bool  AcessarProfessor( string email)
        {
            try
            {
                var professor = new ConexaoLoginProf();

                TemUsuario = professor.AcessarAluno(email);
                

            }
            catch (Exception ) { throw; }

            return TemUsuario;
        }

        public bool VerificarProfessor(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginProf();

                TemUsuario = admin.VerificarProf(email, senha);


            }
            catch (Exception) { throw; }

            return TemUsuario;
        }

        public bool AcessarAluno(string email)
        {
            try
            {
                var aluno = new ConexaoLoginAluno();

                TemUsuario = aluno.AcessarAluno(email);

            }catch (Exception ) { throw; }

            return TemUsuario;
        }

        public bool VerificarAluno(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginAluno();

                TemUsuario = admin.VerificarAluno(email, senha);


            }
            catch (Exception) { throw; }

            return TemUsuario;
        }

    }

}
