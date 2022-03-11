using CrudCsharpMysql.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.controller
{
    public class AgendaController
    {
        public MySqlDataReader readersController;
        public bool sucessInsert, sucessUpdate, sucessDelete;
        public bool haveLogin;
        public string messageError = "";
        internal SerializationInfo sucessRead;

        public bool Insert(string name, string email, string phone)
        {
            AgendaCommand agendaCommand = new AgendaCommand();
            agendaCommand.Save(name, email, phone);

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
        public MySqlDataReader Read(string search)
        {

            AgendaCommand agendaCommand = new AgendaCommand();
            readersController = agendaCommand.Read(search);
            return readersController;
            
        }
        public bool Update()
        {
            return sucessInsert;
        }
        public bool Delet()
        {
            return sucessInsert;
        }
       
    }
}
