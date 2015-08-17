using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable()]
    public class TablaMonitorDetenido
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("gps_dispositivo_id")]
        public string GpsDispositivoId { get; set; }

        [XmlElement("latitud")]
        public string Latitud { get; set; }

        [XmlElement("longitud")]
        public string Longitud { get; set; }

        [XmlElement("detenido")]
        public string Detenido { get; set; }

        [XmlElement("tiempo")]
        public string Tiempo { get; set; }

        [XmlElement("fechahora")]
        public string FechaHora { get; set; }
    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class MonitorDetenido
    {
        [XmlElement("Table", typeof(TablaMonitorDetenido))]
        public TablaMonitorDetenido[] TablaMonitorDetenido { get; set; }
    }
}
