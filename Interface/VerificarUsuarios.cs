﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Interface
{
    public interface IVerificarUsuarios
    {
        public bool VerificarLogin(string login, string senha);

        
    }
}
