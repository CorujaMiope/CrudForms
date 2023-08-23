using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.CSql;

namespace ProjetoEscola.PonteDados
{
    public class DadosMateria
    {
        ConnectMateria mt = new ConnectMateria(); 
        public DataTable ListaDeMateria()
        {
            try
            {
                DataTable dataMateria = new DataTable();

                dataMateria = mt.ListarMaterias();

                return dataMateria;

            }
            catch (Exception) { throw; }
        }
    }
}
