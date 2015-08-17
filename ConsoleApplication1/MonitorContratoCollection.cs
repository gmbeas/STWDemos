using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable()]
    public class TablaMonitorContrato
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("gps_dispositivo_id")]
        public string GpsDispositivoId { get; set; }

        [XmlElement("origen")]
        public string Origen { get; set; }

        [XmlElement("destino")]
        public string Destino { get; set; }

        [XmlElement("fecha")]
        public string Fecha { get; set; }

        [XmlElement("tiempo_puntos")]
        public string TiempoPuntos { get; set; }

        [XmlElement("tiempo_detenido")]
        public string TiempoDetenido { get; set; }

        [XmlElement("kilometros")]
        public string Kilometros { get; set; }

        [XmlElement("id_in")]
        public string IdIn { get; set; }

        [XmlElement("id_out")]
        public string IdOut { get; set; }
    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class MonitorContrato
    {
        [XmlElement("Table", typeof(TablaMonitorContrato))]
        public TablaMonitorContrato[] TablaMonitorContrato { get; set; }
    }
}
