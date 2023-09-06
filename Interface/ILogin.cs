using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Interface
{
    public interface ILogin
    {
        public bool Verificar( string login, string senha);

        
    }
}
