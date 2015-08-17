using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concilia_POS.Content
{
    public static class DbGeneral
    {
        public static DataSet POS_Concilia(string fecha, string sede, int caja)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", "COR"),
                new SqlParameter("@Fecha1", fecha),
                new SqlParameter("@Fecha2", fecha),
                new SqlParameter("@Sede", sede),
                new SqlParameter("@Cajero", ""),
                new SqlParameter("@Caja", caja),
                new SqlParameter("@TipoDoc", ""),
                new SqlParameter("@MedioPago", ""),
                new SqlParameter("@NroDoc", "")
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "POS_Concilia", commandParameters);
            return results;
        }

        public static DataSet ConsultaConcilia(string fecha1, string fecha2)
        {
            var sqlStr =
                string.Format(
                    "SELECT pc.* FROM Pos_ConciliaArqueo pc  WHERE pc.fecha BETWEEN '{0}' AND '{1}' AND (pc.MedioPago IN('TDEB','TCRE'))",
                    fecha1, fecha2);

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.Text, sqlStr);
            return results;
        }

        public static DataSet ConsultaCodAut(string folio)
        {
            var sqlStr =
                string.Format(
                    "SELECT * FROM POS_Cabecera pc WHERE pc.Folio={0}",
                    folio);

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.Text, sqlStr);
            if (results.Tables[0].Rows.Count > 0)
            {
                var dr = results.Tables[0].Rows[0];

                var au = dr["Id"].ToString();


                var sqlStr2 =
                    string.Format(
                        "SELECT * FROM POS_Pagos pp WHERE pp.CAB_Id={0}",
                        au);

                var results2 = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.Text, sqlStr2);
                return results2;
            }

            return new DataSet();
        }

        public static DataSet ConsultaLisaDocu(string codtarjeta, int monto)
        {
            var a = codtarjeta.Substring(0, 1);
            if (a.Equals("0"))
            {
                codtarjeta = codtarjeta.Replace("0", "");
            }
            else
            {
                var b = codtarjeta.Substring(codtarjeta.Length - 4, 4);
                codtarjeta = b;
            }
                

            var sqlStr = string.Format("SELECT * FROM [CZPLAPAG] where czplapagcc = '{0}' and czplapagva={1}", int.Parse(codtarjeta), monto);
            var results2 = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.Text, sqlStr);
            return results2;

        }

        public static DataSet ConsultaLisaDocuSegundo(int codAuto, int monto)
        {


            var sqlStr = string.Format("SELECT * FROM [CZPLAPAG] where CzPlaPtaAu = '{0}' and czplapagva={1}", codAuto, monto);
            var results2 = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.Text, sqlStr);
            return results2;

        }

        public static DataSet ConsultaLisaDocuTercero(int codAuto, int monto)
        {
            var sqlStr = string.Format("select * from TEODIDPA where teodidpaca = '{0}' and TeOdiDpaVa='{1}'", codAuto,
                monto);
            var results2 = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.Text, sqlStr);
            return results2;
        }



    }
}
