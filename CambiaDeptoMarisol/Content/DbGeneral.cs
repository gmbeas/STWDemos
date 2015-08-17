using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambiaDeptoMarisol.Content
{
    public static class DbGeneral
    {
        public static int CambiaEstado(string codigo, string docuemento, string tipo)
        {
            var query =
                string.Format(
                    "UPDATE FALVE SET GcFacDep = {0} WHERE 1=1 and MbEprCod='STE' AND GcFacFolti = {1} AND MbDocCod = '{2}'", codigo, docuemento, tipo);

            var results = SqlHelper.ExecuteNonQuery(Conexion.CadenaConexionAlpha(), CommandType.Text, query);
            return results;
        }
    }
}
