using System;
using System.Collections.Generic;
using System.Text;

namespace CrudCsharpMysql.model
{
    class connectDB
    {
        
        static private string servidor = "localhost";
        static private string banco = "openxcod";
        static private string usuario = "root";
        static private string senha = "Jelis@24";

        public static string strConn = $"server={servidor};user={usuario};database={banco};port=3306;password={senha}";


    }
   
}
