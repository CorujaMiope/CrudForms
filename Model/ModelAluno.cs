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
        ConexaoLoginAluno loginAluno = new();

        public List<Aluno> Listar()
        {
            try
            {
                List<Aluno> lista = new List <Aluno>();

                lista = bancoAlunos.Listar();

                return lista;

            }catch (Exception ) { throw; }
        }

        public List<Aluno> ListarDadosBasicos()
        {
            List<Aluno> listAluno = new();

            return listAluno = bancoAlunos.ListarDadosBasicos();
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

        public bool VerificarUsuarioComRA(string usuario, int ra)
        {
            return loginAluno.VarificarUsuarioComRA(usuario, ra);
        }
    }
}
