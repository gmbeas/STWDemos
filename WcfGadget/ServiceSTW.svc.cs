using System.Collections.Generic;
using System.Data;
using System.Linq;
using WcfGadget.Content;

namespace WcfGadget
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSTW : IServiceSTW
    {
        public TipoGrafico TipoGraficoMostrar(string tipoReporte, string perfil)
        {
            var ds = DBGeneral.WPL_FACT_CLIENTES(tipoReporte, perfil);
            var dr = ds.Tables[0].Rows[0];
            var info = new TipoGrafico {Tipo = dr["Tipo"].ToString()};
            return info;
        }

        public RvCar GetReporteRv(string tipoReporte, string perfil)
        {
            var ds = DBGeneral.WPL_FACT_CLIENTES(tipoReporte, perfil);
            var dr = ds.Tables[0].Rows[0];
            var info = new RvCar
            {
                Tipo = dr["Tipo"].ToString(),
                AnoAct = dr["AñoAct"].ToString(),
                AnoAnt = dr["AñoAnt"].ToString(),
                MesAct = dr["MesAct"].ToString(),
                MensajeMes = dr["MensajeMes"].ToString(),
                MensajeAno = dr["MensajeAño"].ToString(),
                ProyMesAnterior = dr["ProyMesAnterior"].ToString(),
                MesAnterior = dr["MesAnterior"].ToString(),
                PlanMes = dr["PlanMes"].ToString(),
                Mes = dr["Mes"].ToString(),
                PorcentMes = dr["% Mes"].ToString(),
                ProyMes = dr["ProyMes"].ToString(),
                PorcentProyMes = dr["% ProyMes"].ToString(),
                ProyAnoAnterior = dr["ProyAñoAnterior"].ToString(),
                AnoAnterior = dr["AñoAnterior"].ToString(),
                PlanAno = dr["PlanAño"].ToString(),
                Ano = dr["Año"].ToString(),
                PorcentAno = dr["% Año"].ToString(),
                ProyAno = dr["ProyAño"].ToString(),
                PorcentProyAno = dr["% ProyAño"].ToString()
            };

            return info;
        }

        public List<ReporteChico> GetReporteChico(string tipoReporte, string perfil)
        {
            var ds = DBGeneral.WPL_FACT_CLIENTES(tipoReporte, perfil);

            return (from DataRow dr in ds.Tables[0].Rows
                select new ReporteChico
                {
                    Tipo = dr["Tipo"].ToString(),
                    MesAnterior = double.Parse(dr["MesAnterior"].ToString()),
                    Mes = double.Parse(dr["Mes"].ToString()),
                    AnoAnterior = double.Parse(dr["AñoAnterior"].ToString()),
                    Ano = double.Parse(dr["Año"].ToString()),
                    MensajeAno = dr["MensajeAño"].ToString(),
                    MensajeMes = dr["MensajeMes"].ToString()
                }).ToList();
        }

        public List<ReporteGrande> GetReporteGrande(string tipoReporte, string perfil)
        {
            var ds = DBGeneral.WPL_FACT_CLIENTES(tipoReporte, perfil);

            return (from DataRow dr in ds.Tables[0].Rows
                let empresa = dr["Empresa"].ToString()
                let tipo = dr["Tipo"].ToString()
                let anoActual = int.Parse(dr["AñoActual"].ToString())
                let mesActual = int.Parse(dr["MesActual"].ToString())
                let anoAnterior = int.Parse(dr["AñoAnterior"].ToString())
                let factMesAnterior = dr["Fact.Mes:" + mesActual + "/" + anoAnterior].ToString()
                let factProyActual = dr["Fact.Proy:" + mesActual + "/" + anoActual].ToString()
                let factMesActual = dr["Fact.Mes:" + mesActual + "/" + anoActual].ToString()
                let porcentFactMes = dr["% Fact Mes:"].ToString()
                let porcentFactMesProy = dr["% Fact Mes Proy:"].ToString()
                let factAnoAnterior = dr["Fact.Año:" + anoAnterior].ToString()
                let factAnoActual = dr["Fact.Año:" + anoActual].ToString()
                let porcentFactAno = dr["% Fact Año:"].ToString()
                let fleteMesAnterior = dr["Flete Mes:" + mesActual + "/" + anoAnterior].ToString()
                let fleteMesActual = dr["Flete Mes:" + mesActual + "/" + anoActual].ToString()
                let porcentFleteMes = dr["% Flete Mes:"].ToString()
                let fleteAnoAnterior = dr["Flete Año:" + anoAnterior].ToString()
                let fleteAnoActual = dr["Flete Año:" + anoActual].ToString()
                let porcentFleteAno = dr["% Flete Año:"].ToString()
                let m3MesAnterior = dr["M3 Mes:" + mesActual + "/" + anoAnterior].ToString()
                let m3ProyActual = dr["M3 Proy:" + mesActual + "/" + anoActual].ToString()
                let m3MesActual = dr["M3 Mes:" + mesActual + "/" + anoActual].ToString()
                let porcentM3Mes = dr["% M3 Mes:"].ToString()
                let porcentM3ProyMes = dr["% M3 Proy Mes:"].ToString()
                select new ReporteGrande
                {
                    Empresa = empresa, Tipo = tipo, AnoActual = anoActual, MesActual = mesActual, AnoAnterior = anoAnterior, FactMesAnterior = double.Parse(factMesAnterior), FactProyActual = double.Parse(factProyActual), FactMesActual = double.Parse(factMesActual), PorcentFactMes = double.Parse(porcentFactMes), PorcentFactMesProy = double.Parse(porcentFactMesProy), FactAnoAnterior = double.Parse(factAnoAnterior), FactAnoActual = double.Parse(factAnoActual), PorcentFactAno = double.Parse(porcentFactAno), FleteMesAnterior = double.Parse(fleteMesAnterior), FleteMesActual = double.Parse(fleteMesActual), PorcentFleteMes = double.Parse(porcentFleteMes), FleteAnoAnterior = double.Parse(fleteAnoAnterior), FleteAnoActual = double.Parse(fleteAnoActual), PorcentFleteAno = double.Parse(porcentFleteAno), M3MesAnterior = double.Parse(m3MesAnterior), M3ProyActual = double.Parse(m3ProyActual), M3MesActual = double.Parse(m3MesActual), PorcentM3Mes = double.Parse(porcentM3Mes), PorcentM3ProyMes = double.Parse(porcentM3ProyMes)
                }).ToList();
        }

        public string GeneraActualizacion(string tipoReporte, string perfil)
        {
            var ds = DBGeneral.WPL_FACT_CLIENTES(tipoReporte, perfil);

            return "OK";
        }


        public Actualizacion GetActualizacion(string tipoReporte, string perfil)
        {
            var ds = DBGeneral.WPL_FACT_CLIENTES(tipoReporte, perfil);
            var info = new Actualizacion();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                info.Flag = dr["Flag"].ToString();
                info.Mensaje = dr["Mensaje"].ToString();
                info.Fecha = dr["Fecha"].ToString();
            }
            return info;
        }

       
    }
}
