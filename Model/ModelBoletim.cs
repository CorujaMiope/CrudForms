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
        bool verificar;

        readonly ConexaoBoletim boletins = new();
      
        public List<AlunoNotasVM> ListarAlunoEspecifico()
        {
            try
            {
                List<AlunoNotasVM> ListarNotas = new();

                ListarNotas = boletins.ListarAlunosEspecifico();

                return ListarNotas;

            }
            catch (Exception) { throw; }



        }

        public void Salvar(Boletim boletim)
        {
            try
            {

              boletins.Salvar(boletim);

            }catch (Exception) { throw; }
            
        }

        public void Editar(Boletim boletim)
        {
            try
            {
                
                boletins.Editar(boletim);

            }catch (Exception) { throw; }
            
        }

        public void Excluir(Boletim boletim)
        {
            try
            {
                
                boletins.Excluir(boletim);
            
            }catch (Exception) { throw; }
            
        }

        public bool VerificarIdentificador(int ra)
        {
            return verificar = boletins.VerificarIdentificador(ra);
        }

        public bool VerificarAlunoEmateria(int ra, string materia)
        {
            return verificar = boletins.VerificarBoletim(ra, materia);

        }


    }
}
