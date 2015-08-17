using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfGadget
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceSTW
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetReporteChicoJSON?tipoReporte={tipoReporte}&perfil={perfil}")]
        List<ReporteChico> GetReporteChico(string tipoReporte, string perfil);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetReporteGrandeJSON?tipoReporte={tipoReporte}&perfil={perfil}")]
        List<ReporteGrande> GetReporteGrande(string tipoReporte, string perfil);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetReporteRvJSON?tipoReporte={tipoReporte}&perfil={perfil}")]
        RvCar GetReporteRv(string tipoReporte, string perfil);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetActualizacionJSON?tipoReporte={tipoReporte}&perfil={perfil}")]
        Actualizacion GetActualizacion(string tipoReporte, string perfil);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ActualizaJSON?tipoReporte={tipoReporte}&perfil={perfil}")]
        string GeneraActualizacion(string tipoReporte, string perfil);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "TipoGraficoMostrarJSON?tipoReporte={tipoReporte}&perfil={perfil}")]
        TipoGrafico TipoGraficoMostrar(string tipoReporte, string perfil);


    }


    [DataContract]
    public class TipoGrafico
    {
        [DataMember]
        public string Tipo { get; set; }
    }

    #region Actualizacion
    [DataContract]
    public class Actualizacion
    {
        [DataMember]
        public string Flag { get; set; }

        [DataMember]
        public string Fecha { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
    #endregion

    #region ReporteGrande
    [DataContract]
    public class ReporteGrande
    {
        [DataMember]
        public string Empresa { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public int AnoActual { get; set; }

        [DataMember]
        public int MesActual { get; set; }

        [DataMember]
        public int AnoAnterior { get; set; }

        [DataMember]
        public double FactMesAnterior { get; set; }

        [DataMember]
        public double FactProyActual { get; set; }

        [DataMember]
        public double FactMesActual { get; set; }

        [DataMember]
        public double PorcentFactMes { get; set; }

        [DataMember]
        public double PorcentFactMesProy { get; set; }

        [DataMember]
        public double FactAnoAnterior { get; set; }

        [DataMember]
        public double FactAnoActual { get; set; }

        [DataMember]
        public double PorcentFactAno { get; set; }

        [DataMember]
        public double FleteMesAnterior { get; set; }

        [DataMember]
        public double FleteMesActual { get; set; }

        [DataMember]
        public double PorcentFleteMes { get; set; }

        [DataMember]
        public double FleteAnoAnterior { get; set; }

        [DataMember]
        public double FleteAnoActual { get; set; }

        [DataMember]
        public double PorcentFleteAno { get; set; }

        [DataMember]
        public double M3MesAnterior { get; set; }

        [DataMember]
        public double M3ProyActual { get; set; }

        [DataMember]
        public double M3MesActual { get; set; }

        [DataMember]
        public double PorcentM3Mes { get; set; }

        [DataMember]
        public double PorcentM3ProyMes { get; set; }
    }
    #endregion


    //Tipo = dr["Tipo"].ToString(), 
    //                MesAnterior = double.Parse(dr["MesAnterior"].ToString()), 
    //                Mes = double.Parse(dr["Mes"].ToString()), 
    //                AnoAnterior = double.Parse(dr["AñoAnterior"].ToString()), 
    //                Ano = double.Parse(dr["Año"].ToString()),
    //                MensajeAno = dr["MensajeAño"].ToString(),
    //                MensajeMes = dr["MensajeMes"].ToString(),
    //ProyMesAnterior = dr["ProyMesAnterior"].ToString(),
    //PlanMes = dr["PlanMes"].ToString(),
    //ProyMes = dr["ProyMes"].ToString(),
    //ProyAnoAnterior = dr["ProyAñoAnterior"].ToString(),
    //PlanAno = dr["PlanAño"].ToString(),
    //ProyAno = dr["ProyAño"].ToString()

    #region ReporteChico
    [DataContract]
    public class ReporteChico
    {
        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public double MesAnterior { get; set; }

        [DataMember]
        public double Mes { get; set; }

        [DataMember]
        public double AnoAnterior { get; set; }

        [DataMember]
        public double Ano { get; set; }

        [DataMember]
        public string MensajeAno { get; set; }

        [DataMember]
        public string MensajeMes { get; set; }
        
    }
    #endregion

    #region RvCar
    [DataContract]
    public class RvCar
    {
        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string AnoAct { get; set; }

        [DataMember]
        public string AnoAnt { get; set; }

        [DataMember]
        public string MesAct { get; set; }

        [DataMember]
        public string MensajeMes { get; set; }

        [DataMember]
        public string MensajeAno { get; set; }

        [DataMember]
        public string ProyMesAnterior { get; set; }

        [DataMember]
        public string MesAnterior { get; set; }

        [DataMember]
        public string PlanMes { get; set; }

        [DataMember]
        public string Mes { get; set; }

        [DataMember]
        public string PorcentMes { get; set; }

        [DataMember]
        public string ProyMes { get; set; }

        [DataMember]
        public string PorcentProyMes { get; set; }

        [DataMember]
        public string ProyAnoAnterior { get; set; }

        [DataMember]
        public string AnoAnterior { get; set; }

        [DataMember]
        public string PlanAno { get; set; }

        [DataMember]
        public string Ano { get; set; }

        [DataMember]
        public string PorcentAno { get; set; }

        [DataMember]
        public string ProyAno { get; set; }

        [DataMember]
        public string PorcentProyAno { get; set; }

    }
    #endregion
}
