using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace sql
{
    public class DbGeneral
    {

        public static int ReduceFastFast()
        {
            var sqlstring = "use tempdb go DBCC SHRINKFILE(tempdev, 2); go DBCC SHRINKFILE(templog, 2); go";

            var results = SqlHelper.ExecuteNonQuery(Conexion.CadenaConexion(), CommandType.Text, sqlstring);
            return results;
        }
    }
}
