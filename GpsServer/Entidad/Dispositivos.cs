using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsServer.Entidad
{
    public class Dispositivos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public string Imei { get; set; }
        public int UltimaPosicionId { get; set; }
    }
}
