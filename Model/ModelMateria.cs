using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.DAO;

namespace ProjetoEscola.PonteDados
{
    public class ModelMateria
    {
        ConexaoMateria conexaoBoletim = new ConexaoMateria(); 
        public DataTable ListaDeMateria()
        {
            try
            {
                DataTable dataMateria = new DataTable();

                return dataMateria = conexaoBoletim.ListarMaterias();              

            }
            catch (Exception) { throw; }
        }
    }
}
