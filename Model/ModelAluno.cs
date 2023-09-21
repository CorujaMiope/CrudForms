using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.DAO;
using ProjetoEscola.Entidades;
using ProjetoEscola.Interface;

namespace ProjetoEscola.PonteDados
{
    public class ModelAluno: IPersistenciaDeDados<Aluno>
    {
        readonly ConexaoAlunos bancoAlunos = new();

        public DataTable Listar()
        {
            try
            {
                var dataTable = new DataTable();
                dataTable = bancoAlunos.Listar();

                return dataTable;

            }catch (Exception ) { throw; }
        }

        public DataTable ListaBasica()
        {
            try
            {
                var dataTable = new DataTable();

                return dataTable = bancoAlunos.ListarDadosBasicos();            

            }catch (Exception ) { throw; }
        }

        public void Salvar(Aluno aluno)
        {
            try
            {
                bancoAlunos.Salvar(aluno);

            }catch (Exception ) { throw; }
        }

        public void Editar(Aluno aluno)
        {
            try
            {
                bancoAlunos.Editar(aluno);

            }
            catch (Exception) { throw; }
        }

        public void Excluir(Aluno aluno)
        {
            try
            {
                bancoAlunos.Excluir(aluno);

            }catch (Exception) { throw; }
           
        }

        public bool VerificarIdentificador(int ra)
        {
           bool veriicar = bancoAlunos.VerificarIdentificador(ra);

            return veriicar;
        }
    }
}
