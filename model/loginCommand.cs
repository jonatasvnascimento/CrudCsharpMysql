using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.model
{
    internal class loginCommand
    {
        public bool haveLogin;
        public string message;
        public bool verifLogin(string login, string password)
        {
            //Comando sql para verificar sem tem o usuario cadastrado na base
            return haveLogin;
        }
        public string register(string login, string password, string confirmPassword)
        {
            //sql registrar o usuário
            return message;
        }

    }
}
