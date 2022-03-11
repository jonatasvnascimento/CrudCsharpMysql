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
        private MySqlDataReader readers;

        public bool Save(string name, string email, string phone)
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
            catch (Exception ex)
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
        public MySqlDataReader Read(string search)
        {
            string[] searchRows = { };

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "select * from openxcod.contatos where nome like @search or email like @search ";
                cmd.Parameters.AddWithValue("@search", $"%{search}%");
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                readers = reader;
                //while (reader.Read())
                //{
                //    string[] row =
                //    {
                //        reader.GetString(0),
                //        reader.GetString(1),
                //        reader.GetString(2),
                //        reader.GetString(3),
                //    };
                //}
            }
            catch (MySqlException ex)
            {
                this.messageError = ex.Message;
            }
            catch (Exception ex)
            {
                this.messageError = ex.Message;
            }
            
            

            if (messageError.Equals(""))
            {
                sucess = true;
            }
            else
            {
                sucess = false;
            }

            return readers;
        }
    }
}
