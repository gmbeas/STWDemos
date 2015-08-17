using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace JsonGPS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicioGPS
    {
        // TODO: Add your service operations here
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetDispositivosJSON"
            )]
        List<DispositivosModel> GetDispositivos();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetUltimaPosicionTodosJSON"
            )]
        List<UltimaPosicionModel> GetUltimaPosicionTodos();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetUltimaPosicionIDJSON?id={id}"
            )]
        List<UltimaPosicionModel> GetUltimaPosicionId(int id);


        [OperationContract]
        [WebGet(UriTemplate = "GetImage?tipo={tipo}&color={color}&alto={alto}&ancho={ancho}", 
            RequestFormat = WebMessageFormat.Xml, 
            ResponseFormat = WebMessageFormat.Xml, 
            BodyStyle = WebMessageBodyStyle.Bare)]
        Stream GetImage(string tipo, string color, string alto, string ancho);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetColorJSON?id={id}"
            )]
        ColorModel GetColor(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "InsertaNombreGeoCercaJSON?id={id}&nombre={nombre}&tipogeo={tipogeo}"
            )]
        InsertaNombreGeocercaModel InsertaNombreGeoCerca(string id, string nombre, string tipogeo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "InsertaGeoCercaJSON?id={id}&latitud={latitud}&longitud={longitud}&radio={radio}"
            )]
        InsertaGeocercaModel InsertaGeoCerca(string id, string latitud, string longitud, string radio);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetGeoCercaNombreJSON?id={id}"
            )]
        List<GeoCercaNombreModel> GetGeoCercaNombre(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetGeoCercaPosicionesJSON?id={id}"
            )]
        List<GeoCercaPosicionModel> GetGeoCercaPosiciones(string id);
    }

    [DataContract]
    public class GeoCercaPosicionModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int GeoCercaId { get; set; }

        [DataMember]
        public double Latitud { get; set; }

        [DataMember]
        public double Longitud { get; set; }

        [DataMember]
        public double Radio { get; set; }
    }

    [DataContract]
    public class GeoCercaNombreModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Tipo_GeoCerca { get; set; }

        [DataMember]
        public int ColorId { get; set; }
    }

    [DataContract]
    public class InsertaGeocercaModel
    {
        [DataMember]
        public int Flag { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }

    [DataContract]
    public class InsertaNombreGeocercaModel
    {
        [DataMember]
        public int IdNombre { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ColorModel
    {
        [DataMember]
        public string Valor { get; set; }
    }

    [DataContract]
    public class UltimaPosicionModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double ClienteId { get; set; }

        [DataMember]
        public string Patente { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public string Imei { get; set; }

        [DataMember]
        public int ColorId { get; set; }

        [DataMember]
        public String FechaHora { get; set; }

        [DataMember]
        public int EstodoId { get; set; }

        [DataMember]
        public int IconoId { get; set; }

        [DataMember]
        public double Latitud { get; set; }

        [DataMember]
        public double Longitud { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public int Altitud { get; set; }

        [DataMember]
        public int Curso { get; set; }

        [DataMember]
        public string Alarma { get; set; }

        [DataMember]
        public int Poder { get; set; }

        [DataMember]
        public double Velocidad { get; set; }

        [DataMember]
        public int Valido { get; set; }


    }

    [DataContract]
    public class DispositivosModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double ClienteId { get; set; }

        [DataMember]
        public string Patente { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int UltimaPosicionId { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public string Imei { get; set; }

        [DataMember]
        public string Numero { get; set; }

        [DataMember]
        public int ColorId { get; set; }

        [DataMember]
        public String FechaHora { get; set; }

        [DataMember]
        public int EstodoId { get; set; }

        [DataMember]
        public int Activo { get; set; }

        [DataMember]
        public int IconoId { get; set; }
    }
}
