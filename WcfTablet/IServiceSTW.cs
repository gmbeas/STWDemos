using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfTablet
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceSTW
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "NewMovimientoJSON?tipo={tipo}&Folio={folio}&cliente={cliente}&fechad={fechad}&fechah={fechah}&sku={sku}&nombrefoto={nombrefoto}&movid={movid}&cadena={cadena}&usrid={usrid}&patente={patente}&estwop={estwop}&tipoarrvta={tipoarrvta}&solofletes={solofletes}")]
        List<NuevoMovimiento> NewMovimiento(string tipo, int folio, int cliente, string fechad, string fechah, string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop, string tipoarrvta, string solofletes);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetContratosJSON?tipo={tipo}&Folio={folio}&cliente={cliente}&fechad={fechad}&fechah={fechah}&sku={sku}&nombrefoto={nombrefoto}&movid={movid}&cadena={cadena}&usrid={usrid}&patente={patente}&estwop={estwop}&tipoarrvta={tipoarrvta}&solofletes={solofletes}")]
        List<Contratos> GetContratos(string tipo, int folio, int cliente, string fechad, string fechah, string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop, string tipoarrvta, string solofletes);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetMovimientosJSON?tipo={tipo}&Folio={folio}&cliente={cliente}&fechad={fechad}&fechah={fechah}&sku={sku}&nombrefoto={nombrefoto}&movid={movid}&cadena={cadena}&usrid={usrid}&patente={patente}&estwop={estwop}&tipoarrvta={tipoarrvta}&solofletes={solofletes}")]
        List<MovimientosContrato> GetMovimientos(string tipo, int folio, int cliente, string fechad, string fechah, string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop, string tipoarrvta, string solofletes);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ValidaLoginJSON?User={user}&Pass={pass}")]
        Login ValidaLogin(string user, string pass);
      

    }

    #region Login
    [DataContract]
    public class Login
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Email { get; set; }
        
        [DataMember]
        public string Respuesta { get; set; }

        [DataMember]
        public int Valida { get; set; }
    }
    #endregion

    #region Contratos
    [DataContract]
    public class Contratos
    {
        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public int Folio { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string CodCliente { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string Contacto { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Ciudad { get; set; }

        [DataMember]
        public string Comuna { get; set; }

        [DataMember]
        public string FechaEntrega { get; set; }

        [DataMember]
        public string FechaRetiro { get; set; }

        [DataMember]
        public string Entregado { get; set; }

        [DataMember]
        public string Devuelto { get; set; }

        [DataMember]
        public string PorRecibir { get; set; }

        [DataMember]
        public string M3 { get; set; }

        [DataMember]
        public string UnidadxRack { get; set; }

        [DataMember]
        public string M3Rack { get; set; }

        [DataMember]
        public string NroRacks { get; set; }

        [DataMember]
        public string Flete { get; set; }

        [DataMember]
        public string Horario { get; set; }

        [DataMember]
        public string Hora { get; set; }

        [DataMember]
        public string Cli1 { get; set; }

        [DataMember]
        public string Cli2 { get; set; }

        [DataMember]
        public string Dir1 { get; set; }

        [DataMember]
        public string Dir2 { get; set; }

        [DataMember]
        public string Patente { get; set; }

        [DataMember]
        public string EstId { get; set; }

        [DataMember]
        public string EstadoWop { get; set; }

        [DataMember]
        public string Observaciones { get; set; }

        [DataMember]
        public string Thumbnail { get; set; }

    }
    #endregion

    #region MovimientosContrato
    [DataContract]
    public class MovimientosContrato
    {
        [DataMember]
        public int NroMov { get; set; }

        [DataMember]
        public string Fecha { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public int UsrId { get; set; }

        [DataMember]
        public int EstId { get; set; }

        [DataMember]
        public int FlagFoto { get; set; }

        [DataMember]
        public int FlagFirma { get; set; }

        [DataMember]
        public int EstId1 { get; set; }

        [DataMember]
        public string Estado1 { get; set; }

        [DataMember]
        public string MovRef { get; set; }

        [DataMember]
        public int FolioRef { get; set; }
    }
    #endregion

    #region NuevoMovimiento
    [DataContract]
    public class NuevoMovimiento
    {
        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public int Recibido { get; set; }

        [DataMember]
        public int ARecibir { get; set; }

        [DataMember]
        public string NombreFoto { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Sku1 { get; set; }

        [DataMember]
        public string Sku2 { get; set; }
    }
    #endregion
}
