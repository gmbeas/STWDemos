using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ProcedureExecuter
    {
        public static int? CommandTimeout
        {
            get { return SqlHelper.CommandTimeout; }
            set { SqlHelper.CommandTimeout = value; }
        }

        public static string ConexionSql
        {
            get { return SqlHelper.ConexionSql; }
            set { SqlHelper.ConexionSql = value; }
        }


        public static DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteDataset(commandType, commandText);
        }

        public static DataSet ExecuteDataset(CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(commandType, commandText, commandParameters);
        }

        public static int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteNonQuery(commandType, commandText);
        }

        public static int ExecuteNonQuery(CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(commandType, commandText, commandParameters);
        }

        public static int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteNonQuery(spName, parameterValues);
        }

    }
}
