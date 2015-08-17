using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GpsWeb2.Collection
{
    [Serializable()]
    public class TablaColor
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("valor")]
        public string Valor { get; set; }

        [XmlElement("hexa")]
        public string Hexa { get; set; }

    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class Colores
    {
        [XmlElement("Table", typeof(TablaColor))]
        public TablaColor[] TablaColor { get; set; }
    }
}