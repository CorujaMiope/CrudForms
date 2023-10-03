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
        public  int RA { get; set; }
        public  string? Sala { get; set; }
       

        public Aluno (int ra, string nome, DateTime nascimento, string sexo,  string? sala, string? usuario, string? senha)
        {
            RA = ra;
            Nome = nome;
            Nascimento = nascimento;
            Sexo = sexo;
            Sala = sala;
            Usuario = usuario;
            Senha = senha;
        }

        public Aluno(int ra, string nome, string? sala)
        {
            RA = ra;
            Nome = nome;
            Sala = sala;
        }

        public Aluno () { }
    }
}
