using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudCsharpMysql.model
{
    static class ConnectDB
    {

        static private string server = "localhost";
        static private string user = "root";
        static private string banc = "openxcod";
        static private string pass = "Jelis@24";
        public static string strConn = $"server={server};user={user};database={banc};port=3306;password={pass}";

        static MySqlConnection conn = new MySqlConnection();
        public static void strConnection()
        {
            conn.ConnectionString = strConn;
        }

        public static void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Clone();
            }
        }
    }

}
