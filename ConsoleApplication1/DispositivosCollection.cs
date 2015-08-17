using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable()]
    public class Tabla
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("descripcion")]
        public string Nombre { get; set; }

        [XmlElement("patente")]
        public string Patente { get; set; }

        [XmlElement("modelo")]
        public string Modelo { get; set; }

        [XmlElement("imei")]
        public string Imei { get; set; }

        [XmlElement("gps_posiciones_id")]
        public string UltimaPosicionId { get; set; }

        [XmlElement("gps_estado_id")]
        public string Estado { get; set; }

        [XmlElement("gps_color_id")]
        public string ColorId { get; set; }

        [XmlElement("gps_estado_vehiculo_id")]
        public string EstadoVehiculo { get; set; }

        [XmlElement("posicion")]
        public string Posicion { get; set; }

        [XmlElement("valor")]
        public string Valor { get; set; }

        [XmlElement("icono")]
        public string Icono { get; set; }

        [XmlElement("icono_color")]
        public string IconoColor { get; set; }

        [XmlElement("color")]
        public string Color { get; set; }

        [XmlElement("latitud")]
        public string Latitud { get; set; }

        [XmlElement("longitud")]
        public string Longitud { get; set; }

        [XmlElement("fechahora")]
        public string FechaHora { get; set; }

        [XmlElement("velocidad")]
        public string Velocidad { get; set; }

        [XmlElement("numero")]
        public string Numero { get; set; }

        [XmlElement("curso")]
        public string Curso { get; set; }

    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class Dispositivos
    {
        [XmlElement("Table", typeof(Tabla))]
        public Tabla[] Tabla { get; set; }
    }
}
