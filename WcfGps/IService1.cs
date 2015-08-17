using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WcfGps
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract, XmlSerializerFormat]
        XmlElement WPL_GPS(string tipo, string fecha, string patente, int folioOrigen, int folioDestino, int minutos, int kms);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_TraePosicionxPosicion(int id);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_Configuracion();

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_InsertaUpdateMonitorContrato(string tipo, int gpsDispositivoId, int origen, int destino, string fecha, double tiempo_detenido, double tiempo_puntos, double kms, int id_in, int id_out);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_ConsultaMonitorDetenido(int gpsDispositivoId);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_ConsultaControlRuta(int idDispositivo, string fecha);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_ListaDispositivosPosicion();

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_ListaDispositivosPosicionId(int id);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_ListaDispositivos();

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_ListaDispositivosID(int id);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_GetColores();

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_GetColoresID(int id);

        [OperationContract, XmlSerializerFormat]
        XmlElement WPL_POW_EntregaRetiro(string tipo, int folio, string cliente, string fechad, string fechah, string sku, string nombrefoto, int movId, string cadena, int userId, string patente, string estWop);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_TraePosiciones(int id, string fechain, string fechaout);

        [OperationContract]
        string SP_UpdateDispositivo(int id, string nombre, string modelo, string patente, string imei, string numero, int activo, int color);

        [OperationContract]
        string SP_InsertaDispositivo(string nombre, string modelo, string patente, string imei, string numero, int activo, int color);

        [OperationContract, XmlSerializerFormat]
        XmlElement SP_MarcaAlarma(int id);

        [OperationContract]
        string SP_InsertaPosicion(string direccion, double altitud, double curso, double latitud, double longitud, string otros, int poder, double velocidad, DateTime fechahora, int valido, int dispositivo_id);

        [OperationContract]
        string SP_InsertaControlRuta(int gpsDispositivoId, double radio, double latitud, double longitud, int folio, string direccion, string fecha);




        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getData/{value}")]
        string GetData(string value);

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

}
