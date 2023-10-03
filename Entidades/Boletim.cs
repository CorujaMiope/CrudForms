using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Entidades
{
    public class Boletim
    {
        public  int RA { get; set; }  
        public  string? Materia { get; set; }
        public  double N1 { get; set; }

        public  double N2 { get; set; }

        public  double N3 { get; set; }
        
        public  double N4 { get; set; }

        public  double Media { get; set; }

        public  string? Resultado { get; set; }
       

        public Boletim(int ra, string materia, double n1, double n2, double n3, double n4, double media, string resultado)
        {
            RA = ra;
            Materia = materia;
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            Media = media;
            Resultado = resultado;
        }

        public Boletim() { }

    }
}
