using ProjetoEscola.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Interface
{
    public interface IExecutavel <T>
    {
        public DataTable ListarDados();

        public void Salvar(T entidade);

        public void Editar( T entidade);

        public void Excluir(T entidade);
        
    }
}
