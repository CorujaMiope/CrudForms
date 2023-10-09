using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using ProjetoEscola.DAO;


namespace ProjetoEscola.PonteDados
{
    public class ModelProfessor:IPersistenciaDeDados<Professor>
     
    {
       ConexoProfessor conexaoProf = new ConexoProfessor();
        public List<Professor> Listar()
        {
            try
            {
               
                List<Professor> listar = new();

               return listar = conexaoProf.Listar();

            }
            catch { throw; }
        }

        public List<Professor> ListarProfessor()
        {
            try
            {
                List<Professor> Lista = new();

               return Lista = conexaoProf.Listar();

            }catch { throw; }
            
        }

        public void Salvar(Professor professor)
        {
            try
            {
                conexaoProf.Salvar(professor);

            }
            catch { throw; }
        }

        public void Editar(Professor professor)
        {
            try
            {
                conexaoProf.Editar(professor);

            }
            catch { throw; }
        }

        public void Excluir(Professor professor)
        {
            try
            {
                conexaoProf.Excluir(professor);

            }
            catch { throw; }

        }

        public bool VerificarIdentificador(int id)
        {
            try
            {
                bool verificar = conexaoProf.VerificarIdentificador(id);

                return verificar;

            }catch { throw; }
        }

        internal bool VerificarUsuarioComID(string usuario, int id)
        {
             ConexaoLoginProf login = new ConexaoLoginProf();
            
            return login.VarificarUsuarioComID(usuario, id);
        }
    }
}
