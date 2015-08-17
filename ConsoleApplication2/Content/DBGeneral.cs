using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Content
{
    public class DbGeneral
    {

        public DataSet WPL_POW_EntregaRetiro()
        {

            var conexion = "Data Source=192.168.1.252;Initial Catalog=LISA_ERP;Integrated Security=False;User ID=sa; Password=";
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
                new SqlParameter("@TipoArrVta", 'A'),
                new SqlParameter("@SoloFletes", 'S')

            };

            var xx = SqlHelper.ExecuteDataset(conexion, CommandType.StoredProcedure, "WPL_POW_EntregaRetiro", commandParameters);


            return xx;

        }
    }
}
