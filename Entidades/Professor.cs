using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Entidades
{
    public class Professor: Pessoa
    {
       
        public int ID { get; set; }    
        public string Materia { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        
    }
}
