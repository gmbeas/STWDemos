using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespaldoFTPServerBD
{
    public static class DbGeneral
    {

        public static DataSet GetFtpParametros()
        {
            var sqlquery = "select * from servidorftp";

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexion(), CommandType.Text, sqlquery);
            return results;
        }

        public static DataSet GetServerParametros(string server, string basedatos)
        {
            var sqlquery = string.Format("select * from parametros where servidor='{0}' and basedatos='{1}'  and activo=1", server, basedatos);

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexion(), CommandType.Text, sqlquery);
            return results;
        }

        public static void InsertaLog(string titulo, string tipo, string archivo, string basedatos)
        {
            var fechahora = DateTime.Now;
            var sqlquery = string.Format("insert into log (valor, tipo, fechahora, archivo, basedatos) values ('{0}','{1}','{2}','{3}','{4}')", titulo, tipo, fechahora.ToString("dd/MM/yyyy HH:mm:ss"), archivo, basedatos);

            SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion(), CommandType.Text, sqlquery);
        }
    }
}