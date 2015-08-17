using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Conexion
    {
        public string CadenaConexion()
        {
            //return ConfigurationManager.ConnectionStrings["Cnn"].ToString();
            return "Data Source=192.168.30.250;Initial Catalog=GpsSteward;Integrated Security=False;User ID=sa; Password=A1b1c1d1";
        }
    }
}
