using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfCambioUbicacion.Content
{
    public static class DBGeneral
    {

        public static string ValidaUsuario(string user, string passwd)
        {
            var query = string.Format("select dbo.ValidaUsuario('{0}', '{1}')", user, passwd);
            var result = SqlHelper.ExecuteReader(Conexion.CadenaConexionDelta(), CommandType.Text, query);
            result.Read();
            return result.GetValue(0).ToString();
        }

        public static bool ValidaRol(string user, int idRol)
        {
            var query = string.Format("select dbo.ValidaUsuarioRol('{0}', '{1}')", user, idRol);
            var result = SqlHelper.ExecuteReader(Conexion.CadenaConexionDelta(), CommandType.Text, query);
            result.Read();
            return result.GetValue(0).ToString() == "S" ? true : false;
        }

        public static DataSet WPL_ListaBodegas(string Empresa)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Empresa", Empresa)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPL_ListaBodegas", commandParameters);
            return results;
        }

        public static DataSet WPA_CambioDeUbicacion(string Tipo, string Cadena1, string Cadena2, string Cadena3, string Cadena4, string Cadena5, string Cadena6, int Cantidad)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Cadena1", Cadena1),
                new SqlParameter("@Cadena2", Cadena2),
                new SqlParameter("@Cadena3", Cadena3),
                new SqlParameter("@Cadena4", Cadena4),
                new SqlParameter("@Cadena5", Cadena5),
                new SqlParameter("@Cadena6", Cadena6),
                new SqlParameter("@Cantidad", Cantidad),

            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPA_CambioDeUbicacion", commandParameters);
            return results;
        }

        public static DataSet WPL_StockBodegaUbicacion(string Empresa, string Bodega, string Sku)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Empresa", Empresa),
                new SqlParameter("@Bodega", Bodega),
                new SqlParameter("@Sku", Sku)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPL_StockBodegaUbicacion", commandParameters);
            return results;
        }
    }
}