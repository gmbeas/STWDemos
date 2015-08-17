using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prueba
{

    [Serializable()]
    public class Datoscliente
    {
        [XmlElement("RUT")]
        public string Rut { get; set; }

        [XmlElement("DIGITO")]
        public string Digito { get; set; }

        [XmlElement("NOMBRE")]
        public string Nombre { get; set; }

        [XmlElement("MBGIRDES")]
        public string Mbgirdes { get; set; }

        [XmlElement("GCCLIBOD")]
        public string Gcclibod { get; set; }
    }


    [Serializable()]
    public class Direccion
    {
        [XmlElement("CODIGO")]
        public string Codigo { get; set; }

        [XmlElement("DESCRIPCION")]
        public string Descripcion { get; set; }

        [XmlElement("CODREG")]
        public string Codreg { get; set; }

        [XmlElement("CODCIU")]
        public string Codciu { get; set; }

        [XmlElement("CODCOM")]
        public string Codcom { get; set; }

        [XmlElement("NOMREG")]
        public string Nomreg { get; set; }

        [XmlElement("NOMCIU")]
        public string Nomciu { get; set; }

        [XmlElement("NOMCOM")]
        public string Nomcom { get; set; }
    }


    [Serializable()]
    public class Contacto
    {
        [XmlElement("CODIGO")]
        public string Codigo { get; set; }

        [XmlElement("NOMBRE")]
        public string Nombre { get; set; }

        [XmlElement("TELEFONO")]
        public string Telefono { get; set; }

        [XmlElement("CORREO")]
        public string Correo { get; set; }
    }


    [Serializable()]
    [XmlRoot("CLIENTE", Namespace = "")]
    public class ClienteLisa
    {

        [XmlArray("CONTACTOS")]
        [XmlArrayItem("CONTACTO", typeof(Contacto))]
        public Contacto[] Contacto { get; set; }


        [XmlArray("DIRECCIONES")]
        [XmlArrayItem("DIRECCION", typeof(Direccion))]
        public Direccion[] Direccion { get; set; }


        [XmlElement("DATOSCLIENTE", typeof(Datoscliente))]
        public Datoscliente[] Datoscliente { get; set; }
    }
}
