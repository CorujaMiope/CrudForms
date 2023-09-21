using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.DAO;
using ProjetoEscola.JanelaAluno.Boletim;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;

namespace ProjetoEscola.Model
{
    public class ModelBoletim: IPersistenciaDeDados<BoletimAluno>
    {
        bool verificar;

        readonly ConexaoBoletim notas = new();
        public DataTable Listar()
        {
            try
            {
                DataTable ListarNotas = new();

                ListarNotas = notas.Listar();

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

        public bool VerificarIdentificador(int ra)
        {
            return verificar = notas.VerificarIdentificador(ra);
        }

        public bool VerificarAlunoEmateria(int ra, string materia)
        {
            return verificar = notas.VerificarBoletim(ra, materia);

        }


    }
}
