using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Entidades
{
    public class Aluno: Pessoa
    {

        public int RA { get; set; }
        public string Sala { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

    }
}
