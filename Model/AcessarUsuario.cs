using ProjetoEscola.DAO;
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

                return TemUsuario = admin.AcessarAdmin(email);


            }
            catch (Exception) { throw; }
            
            
        }

        public bool VerificarAdiministrador(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginAdmin();

                return TemUsuario = admin.VerificarAdmin(email, senha);


            }
            catch (Exception) { throw; }

            
        }

        public bool  AcessarProfessor( string email)
        {
            try
            {
                var professor = new ConexaoLoginProf();

                return TemUsuario = professor.AcessaUsuarios(email);
                

            }
            catch (Exception ) { throw; }

            
        }

        public bool VerificarProfessor(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginProf();

               return TemUsuario = admin.VerificarProf(email, senha);


            }
            catch (Exception) { throw; }

            
        }

        public bool AcessarAluno(string email)
        {
            try
            {
                var aluno = new ConexaoLoginAluno();

                return TemUsuario = aluno.AcessaUsuarios(email);

            }catch (Exception ) { throw; }

            
        }

        public bool VerificarAluno(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginAluno();

                return TemUsuario = admin.VerificarAluno(email, senha);


            }
            catch (Exception) { throw; }

            
        }

    }

}
