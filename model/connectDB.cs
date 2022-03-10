using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudCsharpMysql.model
{
    class connectDB
    {

        static private string server = "localhost";
        static private string user = "root";
        static private string banc = "openxcod";
        static private string pass = "Jelis@24";
        public static string strConn = $"server={server};user={user};database={banc};port=3306;password={pass}";

        MySqlConnection conn = new MySqlConnection();
        public void strConnection()
        {
            conn.ConnectionString = strConn;
        }

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Clone();
            }
        }
    }

}
