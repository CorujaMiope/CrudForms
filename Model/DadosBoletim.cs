using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.CSql;
using ProjetoEscola.JanelaAluno.Boletim;
using ProjetoEscola.Entidades;

namespace ProjetoEscola.Model
{
    public class DadosBoletim
    {
        readonly ConexaoComSqlBoletim notas = new();
        public DataTable Listar()
        {
            try
            {
                DataTable ListarNotas = new();

                ListarNotas = notas.ListarDados();

                return ListarNotas;

            }catch (Exception) { throw; }

           
            
        }

        public void Salvar(BoletimAluno boletim)
        {
            try
            {

              notas.Salvar(boletim);

            }catch (Exception) { throw; }
            
        }

        public void Editar(BoletimAluno boletim)
        {
            try
            {
                
                notas.Editar(boletim);

            }catch (Exception) { throw; }
            
        }

        public void Excluir(BoletimAluno boletim)
        {
            try
            {
                
                notas.Excluir(boletim);
            
            }catch (Exception) { throw; }
            
        }

        public bool Verificar(int ra, string materia)
        {
            bool vr = notas.VerificarBoletim(ra, materia);

            return vr;
        }


    }
}
