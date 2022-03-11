using CrudCsharpMysql.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.controller
{
    public class LoginController
    {
        public bool haveLogin;
        public string messageError = "";

        public bool access(string login, string password)
        {
            LoginCommand loginDB = new LoginCommand();
            haveLogin = loginDB.verifLogin(login, password);

            if (!loginDB.messageError.Equals(""))
            {
                this.messageError = loginDB.messageError;
            }

            return haveLogin;
        }
        public string register(string login, string senha)
        {
            return messageError;
        }
        
    }
}
