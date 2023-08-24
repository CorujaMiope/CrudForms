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
        ConexaoComSqlBoletim notas = new ConexaoComSqlBoletim();
        public DataTable Listar()
        {
            try
            {
                DataTable ListarNotas = new DataTable();

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

        public void excluir(BoletimAluno boletim)
        {
            try
            {
                
                notas.Excluir(boletim);
            
            }catch (Exception) { throw; }
            
        }

        public bool Verificar(int ra)
        {
            bool vr = notas.Verificar(ra);

            return vr;
        }
    }
}
