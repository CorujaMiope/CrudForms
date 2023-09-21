using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.CSql;
using ProjetoEscola.Entidades;

namespace ProjetoEscola.PonteDados
{
    public class ModelAluno
    {
        readonly ConexaoAlunos bancoAlunos = new();

        public DataTable Listar()
        {
            try
            {
                var dataTable = new DataTable();
                dataTable = bancoAlunos.ListarDados();

                return dataTable;

            }catch (Exception ) { throw; }
        }

        public DataTable ListaBasica()
        {
            try
            {
                var dataTable = new DataTable();

                dataTable = bancoAlunos.ListarDadosBasicos();

                return dataTable;

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

        public bool Verificar(int ra)
        {
           bool vr = bancoAlunos.VerificarRa(ra);

            return vr;
        }
    }
}
