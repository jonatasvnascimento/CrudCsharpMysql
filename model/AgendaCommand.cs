using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.model
{
    internal class AgendaCommand
    {
        public bool sucess = false;
        public string messageError = "";
        MySqlConnection conn = new MySqlConnection(ConnectDB.strConn);
        MySqlCommand cmd = new MySqlCommand();
        public bool save(string name, string email, string phone)
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO contatos(nome, email, telefone) values(@name, @email, @phone) ";

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                this.messageError = ex.Message;
            }
            finally
            {
                conn.Close ();
            }

            if (messageError.Equals(""))
            {
                sucess = true;
            }
            else
            {
                sucess = false;
            }

            return sucess;
        }
    }
}
