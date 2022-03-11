using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.model
{
    public class loginCommand
    {
        public bool haveLogin;
        public string message;

        public bool verifLogin(string login, string password)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectDB.strConn);
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
                this.message = ex.Message;
            }

            return haveLogin;
        }
        public string register(string login, string password, string confirmPassword)
        {
            //sql registrar o usuário
            return message;
        }

    }
}
