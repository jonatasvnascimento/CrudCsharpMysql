using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.model
{
    public class LoginCommand
    {
        public bool haveLogin = false;
        public string messageError = "";
        
        public bool verifLogin(string login, string password)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnectDB.strConn);
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM openxcod.usuarios WHERE login = @login and senha = @password ";

                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password",password);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    haveLogin = true;
                }

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

            return haveLogin;
        }
        public string register(string login, string password, string confirmPassword)
        {
            //sql registrar o usuário
            return messageError;
        }

    }
}
