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

                listar = conexaoProf.Listar();

                return listar;

            }
            catch (Exception) { throw; }
        }

        public List<Professor> ListarProfessor()
        {
            

                List<Professor> Lista = new();

                Lista = conexaoProf.Listar();

                return Lista;

            
        }

        public void Salvar(Professor professor)
        {
            try
            {
                conexaoProf.Salvar(professor);

            }
            catch (Exception) { throw; }
        }

        public void Editar(Professor professor)
        {
            try
            {
                conexaoProf.Editar(professor);

            }
            catch (Exception) { throw; }
        }

        public void Excluir(Professor professor)
        {
            try
            {
                conexaoProf.Excluir(professor);

            }
            catch (Exception) { throw; }

        }

        public bool VerificarIdentificador(int id)
        {
            try
            {
                bool verificar = conexaoProf.VerificarIdentificador(id);

                return verificar;

            }catch (Exception) { throw; }
        }

        internal bool VerificarUsuarioComID(string usuario, int id)
        {
             ConexaoLoginProf login = new ConexaoLoginProf();
            
            return login.VarificarUsuarioComID(usuario, id);
        }
    }
}
