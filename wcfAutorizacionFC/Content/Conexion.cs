using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfAutorizacionFC.Content
{
    public static class Conexion
    {
        public static string CadenaConexion()
        {
            //return ConfigurationManager.ConnectionStrings["Cnn"].ToString();
            return
                "Data Source=192.168.30.250;Initial Catalog=StewardGps;Integrated Security=False;User ID=sa; Password=A1b1c1d1";
        }

        public static string CadenaConexionAlpha()
        {
            //return ConfigurationManager.ConnectionStrings["Cnn"].ToString();
            return
                "Data Source=192.168.1.252;Initial Catalog=LISA_ERP;Integrated Security=False;User ID=sa; Password=";
        }

        public static string CadenaConexionDelta()
        {
            //return ConfigurationManager.ConnectionStrings["Cnn"].ToString();
            return
                "Data Source=192.168.1.242;Initial Catalog=WOP;Integrated Security=False;User ID=sa; Password=";
        }
    }
}