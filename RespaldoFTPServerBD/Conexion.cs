using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespaldoFTPServerBD
{
    public static class Conexion
    {
        public static string CadenaConexion()
        {
            //return ConfigurationManager.ConnectionStrings["Cnn"].ToString();
            return
                "Data Source=192.168.1.242;Initial Catalog=FTPDB;Integrated Security=False;User ID=sa; Password=";
        }
    }
}
