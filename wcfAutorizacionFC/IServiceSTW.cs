using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcfAutorizacionFC
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
                "AutenficacionJSON?accion={accion}&usuario={usuario}&passwd={passwd}"
            )]
        ValidacionModel Autenficacion(string accion, string usuario, string passwd);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "ListadoInfoJSON?accion={accion}&tipo={tipo}"
            )]
        List<ListadoInfoModel> ListadoInfo(string accion, string tipo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "ProcesoFinalJSON?accion={accion}&tipo={tipo}&folio={folio}&usuario={usuario}"
            )]
        FinalModel ProcesoFinal(string accion, string tipo, string folio, string usuario);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    #region ValidacionModel
    [DataContract]
    public class ValidacionModel
    {
        [DataMember]
        public string Retorno { get; set; }
    }

    #endregion

    #region FinalModel

    [DataContract]
    public class FinalModel
    {
        [DataMember]
        public string Mensaje { get; set; }
    }
    #endregion

    #region ListadoInfoModel
    [DataContract]
    public class ListadoInfoModel
    {
        [DataMember]
        public string Gcmoefol { get; set; }

        [DataMember]
        public string MbAuxRaz { get; set; }

        [DataMember]
        public string Total { get; set; }
    }
    #endregion
}
