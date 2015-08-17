using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wcfAutorizacionFC.Content
{
    public static class DBGeneral
    {

        public static string WPL_ValidaUsuarioAutoriza(string accion, string user, string passwd)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Accion", accion),
                new SqlParameter("@Usuario", user),
                new SqlParameter("@Psw", passwd)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_ValidaUsuarioAutoriza", commandParameters);
            var dr = results.Tables[0].Rows[0];
            return dr["Retorno"].ToString();
        }


        public static DataSet WPA_ActualizaEstadoContrato(string accion, string tipo, string folio, string usuario)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Accion", accion),
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@Folio", folio),
                new SqlParameter("@Usuario", usuario)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPA_ActualizaEstadoContrato", commandParameters);
            return results;
        }

        
    }
}