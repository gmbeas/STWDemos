using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCambioUbicacion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceSTW
    {
        // TODO: Add your service operations here

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "AutenficacionJSON?usuario={usuario}&passwd={passwd}"
            )]
        UsuarioRolModel Autenficacion(string usuario, string passwd);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "ValidaRolJSON?usuario={usuario}&rolPerfil={rolPerfil}"
            )]
        RolModel ValidaRol(string usuario, int rolPerfil);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "WPL_ListaBodegasJSON"
            )]
        List<BodegasModel> WPL_ListaBodegas();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso1JSON?bodega={bodega}&origen={origen}"
            )]
        List<OkValorModel> CambioDeUbicacionPaso1(string bodega, string origen);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso2JSON?usuario={usuario}"
            )]
        List<NombreTablaModel> CambioDeUbicacionPaso2(string usuario);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso3JSON?sku={sku}"
            )]
        List<OkValorModel> CambioDeUbicacionPaso3(string sku);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso4JSON?sku={sku}"
            )]
        List<OkValorModel> CambioDeUbicacionPaso4(string sku);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso5JSON?bodega={bodega}&origen={origen}&sku={sku}"
            )]
        List<OkValorModel> CambioDeUbicacionPaso5(string bodega, string origen, string sku);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso6JSON?tabla={tabla}&bodega={bodega}&origen={origen}&sku={sku}"
            )]
        List<OkMensajeStockConteoCantidadModel> CambioDeUbicacionPaso6(string tabla, string bodega, string origen, string sku);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso7JSON?tabla={tabla}&bodega={bodega}&origen={origen}&sku={sku}&cantidad={cantidad}"
            )]
        List<OkMensajeStockConteoCantidadModel> CambioDeUbicacionPaso7(string tabla, string bodega, string origen, string sku, int cantidad);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso8JSON?bodega={bodega}&origen={origen}"
            )]
        List<OkValorModel> CambioDeUbicacionPaso8(string bodega, string origen);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso9JSON?tabla={tabla}&bodega={bodega}&destino={destino}"
            )]
        List<BodegasModel> CambioDeUbicacionPaso9(string tabla, string bodega, string destino);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CambioDeUbicacionPaso10JSON?tabla={tabla}&bodega={bodega}&origen={origen}&destino={destino}&usuario={usuario}"
            )]
        List<FlagFinal> CambioDeUbicacionPaso10(string tabla, string bodega, string origen, string destino, string usuario);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "StockBodegaUbicacionJSON?bodega={bodega}&sku={sku}"
            )]
        List<StockBodegaUbi> StockBodegaUbicacion(string bodega, string sku);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "PrecioSkuJSON?sku={sku}"
            )]
        List<PrecioModel> PrecioSku(string sku);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "SkuUbicacionJSON?bodega={bodega}&ubicacion={ubicacion}"
            )]
        List<SkuUbicacionModel> SkuUbicacion(string bodega, string ubicacion);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "UbicacionesJSON?bodega={bodega}"
            )]
        List<UbicacionesModel> Ubicaciones(string bodega);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    #region UbicacionesModel
    [DataContract]
    public class UbicacionesModel
    {
        [DataMember]
        public string Ubicacion { get; set; }
    }
    #endregion

    #region SkuUbicacionModel
    [DataContract]
    public class SkuUbicacionModel
    {
        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Stock { get; set; }
    }
    #endregion

    #region PrecioModel
    [DataContract]
    public class PrecioModel
    {
        [DataMember]
        public string CodLista { get; set; }

        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string PrecioNeto { get; set; }

        [DataMember]
        public string PrecioBruto { get; set; }
    }
    #endregion

    #region StockBodegaUbi
    [DataContract]
    public class StockBodegaUbi
    {
        [DataMember]
        public string Ubicacion { get; set; }

        [DataMember]
        public string Unidades { get; set; }
    }
    #endregion

    #region BodegasModel
    [DataContract]
    public class BodegasModel
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }
    }
    #endregion

    #region FlagFinal
    [DataContract]
    public class FlagFinal
    {
        [DataMember]
        public string Flag { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
    #endregion

    #region OkValorModel
    [DataContract]
    public class OkValorModel
    {
        [DataMember]
        public string Ok { get; set; }

        [DataMember]
        public string Valor { get; set; }
    }
    #endregion

    #region NombreTablaModel
    [DataContract]
    public class NombreTablaModel
    {
        [DataMember]
        public string NombreTabla { get; set; }
    }
    #endregion

    #region OkMensajeStockConteoCantidadModel
    [DataContract]
    public class OkMensajeStockConteoCantidadModel
    {
        [DataMember]
        public string Ok { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public string Stock { get; set; }

        [DataMember]
        public string Conteo { get; set; }

        [DataMember]
        public string Cantidad { get; set; }
    }
    #endregion

    #region UsuarioRolModel
    [DataContract]
    public class UsuarioRolModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public int Estado { get; set; }
    }
    #endregion

    #region RolModel
    [DataContract]
    public class RolModel
    {
        [DataMember]
        public bool EsRol { get; set; }
    }
    #endregion
}
