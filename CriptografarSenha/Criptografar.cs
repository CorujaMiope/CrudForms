using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoEscola.CriptografarSenha
{
    public class Criptografar
    {


        public string CriptografarSenha(string senha)
        {
            try
            {
                MD5 md5 = MD5.Create();
                StringBuilder sb = new StringBuilder();

                byte[] entradaDeSenha = Encoding.ASCII.GetBytes(senha);
                byte[] hash = md5.ComputeHash(entradaDeSenha);


                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                return sb.ToString().ToLower();

            }
            catch { throw;  }

        }
    }
}
