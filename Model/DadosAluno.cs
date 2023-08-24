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
    public class DadosAluno
    {
        ConexaoComSqlAlunos bancoAlunos = new ConexaoComSqlAlunos();

        public DataTable Listar()
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = bancoAlunos.ListarDados();

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
           bool vr = bancoAlunos.Verificar(ra);

            return vr;
        }
    }
}
