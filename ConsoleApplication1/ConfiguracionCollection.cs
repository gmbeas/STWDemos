using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable()]
    public class TablaConfiguracion
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("tiempo_detenido_minutos")]
        public int TiempoDetenidoMinutos { get; set; }

        [XmlElement("geo_inicio_radio_metros")]
        public int GeoInicioRadioMetros { get; set; }

        [XmlElement("geo_inicio_latitud")]
        public double GeoInicioLatitud { get; set; }

        [XmlElement("geo_inicio_longitud")]
        public double GeoInicioLongitud { get; set; }

        [XmlElement("refresh_mapa_segundos")]
        public int RefreshMapaSegundos { get; set; }
    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class Configuracion
    {
        [XmlElement("Table", typeof(TablaConfiguracion))]
        public TablaConfiguracion[] TablaConfiguracion { get; set; }
    }
}
