using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.DAO;
using ProjetoEscola.JanelaAluno.BoletimAluno;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;
using ProjetoEscola.ViewModel;

namespace ProjetoEscola.Model
{
    public class ModelBoletim: IPersistenciaDeDados<Boletim>
    {
      

        readonly ConexaoBoletim boletins = new();
      
        public List<AlunoNotasVM> ListarAlunoEspecifico()
        {
            try
            {
                List<AlunoNotasVM> ListarNotas = new();

                return ListarNotas = boletins.ListarAlunosEspecifico();

            }
            catch { throw; }



        }

        public void Salvar(Boletim boletim)
        {
            try
            {

              boletins.Salvar(boletim);

            }catch { throw; }
            
        }

        public void Editar(Boletim boletim)
        {
            try
            {
                
                boletins.Editar(boletim);

            }catch { throw; }
            
        }

        public void Excluir(Boletim boletim)
        {
            try
            {
                
                boletins.Excluir(boletim);
            
            }catch { throw; }
            
        }

        public bool VerificarIdentificador(int ra)
        {
            return boletins.VerificarIdentificador(ra);
        }

        public bool VerificarAlunoEmateria(int ra, string materia)
        {
            return boletins.VerificarBoletim(ra, materia);

        }


    }
}
