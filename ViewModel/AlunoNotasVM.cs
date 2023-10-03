using ProjetoEscola.DAO;
using ProjetoEscola.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoEscola.ViewModel
{
    public class AlunoNotasVM
    {
        public List<AlunoNotasVM> ListBoletimVM = new List<AlunoNotasVM>();
        


        #region Aluno   
        public int RA { get; set; }
        public string? Nome { get; set; }
        public string Sala { get; set; }
        #endregion

        #region Nota

        public  string Materia { get; set; }
        public  double N1 { get; set; }
        public  double N2 { get; set; }
        public double N3 { get; set; }
        public double N4 { get; set; }
        public double Media { get; set; }
        public string? Resultado { get; set; }
        #endregion



        public AlunoNotasVM(int rA, string nome, string sala, string materia, double n1, double n2, double n3, double n4, double media, string resultado)
        {
            RA = rA;
            Nome = nome;
            Sala = sala;
            Materia = materia;
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            Media = media;
            Resultado = resultado;
        }

        public AlunoNotasVM(string materia, double n1, double n2, double n3, double n4, double media, string resultado)
        {
          
            Materia = materia;
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            Media = media;
            Resultado = resultado;
        }

        public AlunoNotasVM(int ra, string nome, string? sala)
        {
            RA = ra;
            Nome = nome;
            Sala = sala;
        }

        public AlunoNotasVM() { }

       
        public List<AlunoNotasVM> RecebeNotas()
        {
            

            ConexaoBoletim boletim = new ConexaoBoletim();

            List<AlunoNotasVM> Lista = boletim.Listar();

           

            return Lista;
        }

        

    }
}
