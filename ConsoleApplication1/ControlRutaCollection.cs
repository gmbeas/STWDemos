using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable()]
    public class TablaControlRuta
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("gps_dispositivo_id")]
        public string GpsDispositivoId { get; set; }

        [XmlElement("radio")]
        public string Radio { get; set; }

        [XmlElement("latitud")]
        public string Latitud { get; set; }

        [XmlElement("longitud")]
        public string Longitud { get; set; }

        [XmlElement("folio")]
        public string Folio { get; set; }

        [XmlElement("direccion")]
        public string Direccion { get; set; }

        [XmlElement("fecha")]
        public string Fecha { get; set; }
    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class ControlRuta
    {
        [XmlElement("Table", typeof(TablaControlRuta))]
        public TablaControlRuta[] TablaControlRuta { get; set; }
    }
}
