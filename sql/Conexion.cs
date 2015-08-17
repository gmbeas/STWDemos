using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sql
{
    public class Conexion
    {
        public static string CadenaConexion()
        {
            //return ConfigurationManager.ConnectionStrings["Cnn"].ToString();
            return
                "Data Source=localhost;Initial Catalog=master;Integrated Security=False;User ID=sa; Password=";
        }

    }
}