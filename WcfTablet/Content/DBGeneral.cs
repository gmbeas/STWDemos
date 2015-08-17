using System.Data;
using System.Data.SqlClient;

namespace WcfTablet.Content
{
    public static class DbGeneral
    {

        public static DataSet WPL_ValidaUsuario(string user, string pass)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Usuario", user),
                new SqlParameter("@Psw", pass)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_ValidaUsuario", commandParameters);
            return results;
        }


        //http://localhost:31788/Service1.svc/GetContratosJSON?tipo=LISTOT&Folio=0&cliente=0&fechad=2015/03/18&fechah=2015/03/18&sku=&nombrefoto=&movid=0&cadena=&usrid=564&patente=&estwop=0,2,3,6&tipoarrvta=A&solofletes=S
        public static DataSet WPL_POW_EntregaRetiro(string tipo, int folio, int cliente, string fechad, string fechah, string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop, string tipoarrvta, string solofletes)
        {
           
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@Folio", folio),
                new SqlParameter("@Cliente", cliente),
                new SqlParameter("@FechaD", fechad),
                new SqlParameter("@FechaH", fechah),
                new SqlParameter("@Sku", sku),
                new SqlParameter("@NombreFoto", nombrefoto),
                new SqlParameter("@MOV_Id", movid),
                new SqlParameter("@Cadena", cadena),
                new SqlParameter("@USR_Id", usrid),
                new SqlParameter("@Patente", patente),
                new SqlParameter("@EST_Wop", estwop),
                new SqlParameter("@TipoArrVta", tipoarrvta),
                new SqlParameter("@SoloFletes", solofletes)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WPL_POW_EntregaRetiro", commandParameters);
            return results;
        }

     


    }
}