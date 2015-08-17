using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prueba
{

    [Serializable()]
    public class Cabecera
    {
        [XmlElement("region")]
        public string Region { get; set; }

        [XmlElement("ciudad")]
        public string Ciudad { get; set; }

        [XmlElement("direcciondedespacho")]
        public string DireccionDespacho { get; set; }
    }

    [Serializable()]
    public class Item
    {
        [XmlElement("sku")]
        public string Sku { get; set; }

        [XmlElement("descripcion")]
        public string Descripcion { get; set; }

        [XmlElement("um")]
        public string Um { get; set; }

        [XmlElement("cantidadWeb")]
        public string CantidadWeb { get; set; }

        [XmlElement("cantidadLisa")]
        public string CantidadLisa { get; set; }

        [XmlElement("Valor")]
        public string Valor { get; set; }

        [XmlElement("ValorTotal")]
        public string ValorTotal { get; set; }

        [XmlElement("CodPromo")]
        public string CodPromo { get; set; }

    }


    [Serializable()]
    [XmlRoot("xml")]
    public class NotaPedidoDetalle
    {
        [XmlElement("item", typeof(Item))]
        public Item[] Item { get; set; }

        [XmlElement("cabecera", typeof(Cabecera))]
        public Cabecera[] Cabecera { get; set; }
    }
}
