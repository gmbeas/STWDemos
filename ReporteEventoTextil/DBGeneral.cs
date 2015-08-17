using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteEventoTextil
{
    public class DBGeneral
    {
        public static DataSet GetDatosEvento(int evento)
        {
            var fechaayer = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            fechaayer = fechaayer + " 09:00:00";

            var fechahoy = DateTime.Now.ToString("dd/MM/yyyy");
            fechahoy = fechahoy + " 09:00:00";


            var consulta = string.Format("select * from POW_Eventos where IDEVENTO = {0} AND fecha BETWEEN '{1}' AND '{2}'", evento, fechaayer, fechahoy);
            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.Text, consulta);

           
            return results;
        }


        public static DataSet WPL_PromocionesMkt(string Tipo, string Activo, string PRM_Id, string Vendedor, string TipoNV, string NotaVenta, string Codigo, string Nombre, string EMail,
            string Fono, string SubTipo, string Observaciones, string USR_Id)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Activo", Activo),
                new SqlParameter("@PRM_Id", PRM_Id),
                new SqlParameter("@Vendedor", Vendedor),
                new SqlParameter("@TipoNV", TipoNV),
                new SqlParameter("@NotaVenta", NotaVenta),
                new SqlParameter("@Codigo", Codigo),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@EMail", EMail),
                new SqlParameter("@Fono", Fono),
                new SqlParameter("@SubTipo", SubTipo),
                new SqlParameter("@Observaciones", Observaciones),
                new SqlParameter("@USR_Id", USR_Id)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_PromocionesMkt", commandParameters);
            return results;
        }
    }
}
