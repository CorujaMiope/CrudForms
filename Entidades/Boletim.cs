using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Entidades
{
    public class BoletimAluno: Aluno
    {
        public string Materia { get; set; }
        public double N1 { get; set; }

        public double N2 { get; set; }

        public double N3 { get; set; }
        
        public double N4 { get; set; }

        public double Media { get; set; }

        public string Resultado { get; set; }

    }
}
