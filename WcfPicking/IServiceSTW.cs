using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPicking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceSTW
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetNotaPedidoJSON?tipo={tipo}&folio={folio}&actividad={actividad}&cadenainsert={cadenainsert}&cadenaupdate={cadenaupdate}&codcliente={codcliente}&fechad={fechad}&fechah={fechah}&fechaev={fechaev}&ordencompra={ordencompra}&estado={estado}&sku={sku}&bodega={bodega}"
            )]
        List<NotaPedido> WPA_NotasPedido(string tipo, int folio, char actividad, string cadenainsert,
            string cadenaupdate, string codcliente, string fechad, string fechah,
            string fechaev, string ordencompra, string estado, string sku, string bodega);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetLParJSON?tipo={tipo}"
            )]
        List<LPar> WPA_LPAR(string tipo);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetLBodJSON?tipo={tipo}"
            )]
        List<LBod> WPA_LBOD(string tipo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetLEmpJSON?tipo={tipo}"
            )]
        List<LEmp> WPA_LEMP(string tipo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetLSedLVenJSON?tipo={tipo}"
            )]
        List<LSedLVen> WPA_LSED_LVEN(string tipo);







        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GeneraPickingJSON?tipo={tipo}&listaNv={listaNv}"
            )]
        Prueba WPL_GeneraPicking(string tipo, string listaNv);
    }



    [DataContract]
    public class LPar
    {
        [DataMember]
        public string Valor { get; set; }
    }

    [DataContract]
    public class LBod
    {
        [DataMember]
        public string Bodega { get; set; }
    }

    [DataContract]
    public class LEmp
    {
        [DataMember]
        public string MbEprCod { get; set; }

        [DataMember]
        public string Nombre { get; set; }
    }

    [DataContract]
    public class LSedLVen
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }
    }








    [DataContract]
    public class Prueba
    {
         [DataMember]
        public List<Tabla1> Dato1 = new List<Tabla1>();
         [DataMember]
        public List<Tabla2> Dato2 = new List<Tabla2>();
         [DataMember]
        public List<Tabla3> Dato3 = new List<Tabla3>();
    }

    [DataContract]
    public class Tabla1
    {
        [DataMember]
        public string DatoTabla1 { get; set; }
    }

    [DataContract]
    public class Tabla2
    {
        [DataMember]
        public string DatoTabla2 { get; set; }
    }

    [DataContract]
    public class Tabla3
    {
        [DataMember]
        public string DatoTabla3 { get; set; }
    }




    #region NotaPedido
    [DataContract]
    public class NotaPedido
    {
        [DataMember]
        public int Selec { get; set; }

        [DataMember]
        public string Fecauto { get; set; }

        [DataMember]
        public string Nronv { get; set; }

        [DataMember]
        public double MontoNeto { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public int Bodega { get; set; }

        [DataMember]
        public string Cliente { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string NombreFantasia { get; set; }

        [DataMember]
        public int Dias { get; set; }

        [DataMember]
        public string Vendedor { get; set; }

        [DataMember]
        public string Sede { get; set; }

        [DataMember]
        public int EnvioFact { get; set; }

        [DataMember]
        public int Fact { get; set; }

        [DataMember]
        public string OrdenCompra { get; set; }         
    }
    #endregion
    
}
