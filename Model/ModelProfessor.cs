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
        public DataTable Listar()
        {
            try
            {
               
                DataTable dataTable = new();

                dataTable = conexaoProf.Listar();

                return dataTable;

            }
            catch (Exception) { throw; }
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
    }
}
