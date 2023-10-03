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
        

        public Professor(int iD, string nome, DateTime nascimento, string sexo, string materia, string usuario, string senha)
        {
            ID = iD;
            Nome = nome;
            Nascimento = nascimento; 
            Sexo = sexo;
            Materia = materia;
            Usuario = usuario;
            Senha = senha;
        }

        public Professor() { }
    }
}
