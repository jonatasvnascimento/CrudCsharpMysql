using CrudCsharpMysql.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.controller
{
    internal class UserController
    {
        public string messageError = "";
        public bool sucessInsert, sucessDelete;
        private MySqlDataReader usersRead;

        public bool Insert(string name, string login, string password, string email, string status, string access, string deleted, int id)
        {
            UserCommand userCommand = new();

            switch (status)
            {
                case "Ativo":
                    status = "A";
                    break;
                case "Inativo":
                    status = "I";
                    break;
                case "bloqueado":
                    status = "B";
                    break;
                default:
                    break;
            }

            userCommand.Save(name, login, password, email, status, access, deleted, id);

            if (!userCommand.messageError.Equals(""))
            {
                this.messageError = userCommand.messageError;
            }
            else
            {
                sucessInsert = userCommand.sucess;
            }

            return sucessInsert;
        }
        public MySqlDataReader Read(string search)
        {

            UserCommand userCommand = new();
            usersRead = userCommand.Read(search);
            if (!userCommand.messageError.Equals(""))
            {
                this.messageError = userCommand.messageError;
            }

            return usersRead;

        }
        public bool Delete(int id)
        {
            UserCommand userCommand = new();
            userCommand.Delete(id);

            if (!userCommand.messageError.Equals(""))
            {
                this.messageError = userCommand.messageError;
            }
            else
            {
                sucessDelete = userCommand.sucess;
            }

            return sucessDelete;   
        }
    }
}
