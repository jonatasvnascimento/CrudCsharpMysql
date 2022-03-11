using CrudCsharpMysql.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.controller
{
    public class Controle
    {
        public bool haveLogin;
        public string message;

        public bool access(string login, string password)
        {
            loginCommand loginDB = new loginCommand();
            haveLogin = loginDB.verifLogin(login, password);

            //if (!loginDB.message.Equals(""))
            //{
            //    this.message = loginDB.message;
            //}

            return haveLogin;
        }
        public string register(string login, string senha)
        {
            return message;
        }
    }
}
