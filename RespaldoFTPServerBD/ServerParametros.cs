using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespaldoFTPServerBD
{
    public class ServerParametros
    {
        public string Servidor { get; set; }
        public string BaseDatos { get; set; }
        public string LocalFolder { get; set; }
        public string RemoteFolder { get; set; }
        public string FtpFolder { get; set; }

    }
}
