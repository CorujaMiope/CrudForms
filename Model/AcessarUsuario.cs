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
       
        public string? mensagem;

        public bool VerificarSeExisteEmailNoAdmin(string email)
        {
            try
            {
                var admin = new ConexaoLoginAdmin();

                return admin.VerificarSeExisteEmail(email);


            }
            catch { throw; }
            
            
        }

        public bool VerificarAdiministrador(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginAdmin();

                return admin.VerificarSeExisteUsuarioEsenha(email, senha);


            }
            catch { throw; }

            
        }

        public bool  AcessarProfessor( string email)
        {
            try
            {
                var professor = new ConexaoLoginProf();

                return professor.AcessaUsuarios(email);
                

            }
            catch { throw; }

            
        }

        public bool VerificarProfessor(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginProf();

               return admin.VerificarSeExistUsuario(email, senha);


            }
            catch { throw; }

            
        }

        public bool AcessarAluno(string email)
        {
            try
            {
                var aluno = new ConexaoLoginAluno();

                return aluno.AcessaUsuarios(email);

            }catch { throw; }

            
        }

        public bool VerificarAluno(string email, string senha)
        {
            try
            {
                var admin = new ConexaoLoginAluno();

                return admin.VerificarSeExistUsuario(email, senha);


            }
            catch { throw; }

            
        }

    }

}
