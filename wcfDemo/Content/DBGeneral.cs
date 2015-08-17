using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wcfDemo.Content
{
    public class DbGeneral
    {

        public DataSet WPL_POW_EntregaRetiro()
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexionAlpha());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", "LISTOT"),
                new SqlParameter("@Folio", 141337),
                new SqlParameter("@Cliente", 0),
                new SqlParameter("@FechaD", ""),
                new SqlParameter("@FechaH", ""),
                new SqlParameter("@Sku", ""),
                new SqlParameter("@NombreFoto", ""),
                new SqlParameter("@MOV_Id", 0),
                new SqlParameter("@Cadena", ""),
                new SqlParameter("@USR_Id", 564),
                new SqlParameter("@Patente", ""),
                new SqlParameter("@EST_Wop", "0,2,3,6"),
                new SqlParameter("@TipoArrVta", "A"),
                new SqlParameter("@SoloFletes", "S"),

            };

            var results = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "WPL_POW_EntregaRetiro",
                commandParameters);
           
            return results;
        }
    }
}