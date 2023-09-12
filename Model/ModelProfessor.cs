﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.CSql;
using ProjetoEscola.Entidades;


namespace ProjetoEscola.PonteDados
{
    public class ModelProfessor: ConexoProfessor
     
    {
       

        public DataTable ListarProfessor()
        {
            try
            {
                DataTable dataTable = new();

                dataTable = ListarDados();

                return dataTable;

            }
            catch (Exception) { throw; }
        }

        public void SalvarPof(Professor professor)
        {
            try
            {
                Salvar(professor);

            }
            catch (Exception) { throw; }
        }

        public void EditarProf(Professor professor)
        {
            try
            {
                Editar(professor);

            }
            catch (Exception) { throw; }
        }

        public void ExcluirProf(Professor professor)
        {
            try
            {
                Excluir(professor);

            }
            catch (Exception) { throw; }

        }

        public bool VerificarID(int id)
        {
            try
            {
                bool vr = VerificarRa(id);

                return vr;

            }catch (Exception) { throw; }
        }
    }
}
