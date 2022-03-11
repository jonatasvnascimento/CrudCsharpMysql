using CrudCsharpMysql.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.controller
{
    public class AgendaController
    {
        public bool sucessInsert;
        public bool haveLogin;
        public string messageError = "";
        public bool Insert(string name, string email, string phone)
        {
            AgendaCommand agendaCommand = new AgendaCommand();
            agendaCommand.save(name, email, phone);

            if (!agendaCommand.messageError.Equals(""))
            {
                this.messageError = agendaCommand.messageError;
            }
            else
            {
                sucessInsert = agendaCommand.sucess;
            }

            return sucessInsert;
        }
    }
}
