using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prueba
{

    [Serializable()]
    public class Error
    {
        [XmlElement("Error_Codigo")]
        public string ErrorCodigo { get; set; }

        [XmlElement("Error_Descripcion")]
        public string ErrorDescripcion { get; set; }
    }


    [Serializable()]
    [XmlRoot("RespuestaGeneral", Namespace = "LisaWs70")]
    public class RespuestaLisa
    {
        [XmlElement("IndError")]
        public string IndError { get; set; }

        [XmlElement("NumeroServicio")]
        public string NumeroServicio { get; set; }

        [XmlElement("Empresa")]
        public string Empresa { get; set; }

        [XmlElement("Folio")]
        public string Folio { get; set; }


        [XmlArray("Errores")]
        [XmlArrayItem("Error", typeof(Error))]
        public Error[] Error { get; set; }
    }
}
