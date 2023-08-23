using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Entidades
{
    public abstract class Pessoa
    {
       public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
       
        

    }
}
