using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfPicking.Content
{
    public static class DbGeneral
    {
        public static DataSet WPA_NotasPedido(string TIPO, int FOLIO, char ACTIVIDAD, string CADENAINSERT, string CADENAUPDATE, string CODCLIENTE, string FECHAD, string FECHAH,
            string FECHAEV, string ORDENCOMPRA, string ESTADO, string SKU, string BODEGA)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@TIPO", TIPO),
                new SqlParameter("@FOLIO", FOLIO),
                new SqlParameter("@ACTIVIDAD", ACTIVIDAD),
                new SqlParameter("@CADENAINSERT", CADENAINSERT),
                new SqlParameter("@CADENAUPDATE", CADENAUPDATE),
                new SqlParameter("@CODCLIENTE", CODCLIENTE),
                new SqlParameter("@FECHAD", FECHAD),
                new SqlParameter("@FECHAH", FECHAH),
                new SqlParameter("@FECHAEV", FECHAEV),
                new SqlParameter("@ORDENCOMPRA", ORDENCOMPRA),
                new SqlParameter("@ESTADO", ESTADO),
                new SqlParameter("@SKU", SKU),
                new SqlParameter("@BODEGA", BODEGA)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPA_NotasPedido", commandParameters);
            return results;
        }

        public static DataSet WPL_GeneraPicking(string Tipo, string ListaNV)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@ListaNV", ListaNV)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPL_GeneraPicking", commandParameters);
            return results;
        }
    }
}