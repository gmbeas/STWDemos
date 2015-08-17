using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfGadget.Content
{
    public static class DBGeneral
    {
        public static DataSet WPL_FACT_CLIENTES(string tipoReporte, string perfil)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@TipoReporte", tipoReporte),
                new SqlParameter("@Empresa", ""),
                new SqlParameter("@Sede", ""),
                new SqlParameter("@Rut", ""),
                new SqlParameter("@Año", 0),
                new SqlParameter("@Mes", 0),
                new SqlParameter("@Departamento", ""),
                new SqlParameter("@Vendedor", ""),
                new SqlParameter("@Ventas", ""),
                new SqlParameter("@NotaCredito", "S"),
                new SqlParameter("@Perfil", perfil)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPL_FACT_CLIENTES", commandParameters);
            return results;
        }

//     

    }
}