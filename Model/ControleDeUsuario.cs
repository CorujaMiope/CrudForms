﻿using ProjetoEscola.CSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Model
{
    public class ControleDeUsuario
    {
        public bool TemUsuario;
        public string? mensagem;
        public bool  AcessarProfessor( string email, string senha)
        {
            try
            {
                LoginComandoProf logComando = new LoginComandoProf();

                TemUsuario = logComando.VerificarLogin(email, senha);

            }
            catch (Exception ) { throw; }

            return TemUsuario;
        }
        
        public bool AcessarAluno(string email, string senha)
        {
            try
            {
                var aluno = new LoginComandoAluno();

                TemUsuario = aluno.VerificarLogin(email, senha);

            }catch (Exception ) { throw; }

            return TemUsuario;
        }
    }

}
