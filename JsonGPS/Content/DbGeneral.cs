using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonGPS.Content
{
    public static class DbGeneral
    {
        public static DataSet SP_GeoCerca(string tipo, int dispositivoid, string nombre, string tipo_geocerca, int estado, int geocercaid, double latitud, double longitud, double radio)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@dispositivoid", dispositivoid),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@tipo_geocerca", tipo_geocerca),
                new SqlParameter("@estado", estado),
                new SqlParameter("@geocercaid", geocercaid),
                new SqlParameter("@latitud", latitud),
                new SqlParameter("@longitud", longitud),
                new SqlParameter("@radio", radio)
            };


            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexion(), CommandType.StoredProcedure, "SP_GeoCerca", commandParameters);
            return results;
        }

        public static DataSet SP_Dispositivo(string tipo, int clienteid, int usuarioid, string patente, string descripcion, int ultimaposicionid, string modelo, string imei, string numero,
            int colorid, DateTime fechahora, int estodoid, int activo, int iconoid, int id)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@clienteid", clienteid),
                new SqlParameter("@usuarioid", usuarioid),
                new SqlParameter("@patente", patente),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@ultimaposicionid", ultimaposicionid),
                new SqlParameter("@modelo", modelo),
                new SqlParameter("@imei", imei),
                new SqlParameter("@numero", numero),
                new SqlParameter("@colorid", colorid),
                new SqlParameter("@fechahora", fechahora),
                new SqlParameter("@estodoid", estodoid),
                new SqlParameter("@activo", activo),
                new SqlParameter("@iconoid", iconoid),
                new SqlParameter("@id", id),
            };


            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexion(), CommandType.StoredProcedure, "SP_Dispositivo", commandParameters);
            return results;
        }


        public static DataSet SP_Tracking(string tipo, int clienteid, int userid, int activo, int estadoid, int dispositivoid, int posicionid, DateTime fechain, DateTime fechaout,
            double velocidad, string alarma)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@clienteid", clienteid),
                new SqlParameter("@userid", userid),
                new SqlParameter("@activo", activo),
                new SqlParameter("@estadoid", estadoid),
                new SqlParameter("@dispositivoid", dispositivoid),
                new SqlParameter("@posicionid", posicionid),
                new SqlParameter("@fechain", fechain),
                new SqlParameter("@fechaout", fechaout),
                new SqlParameter("@velocidad", velocidad),
                new SqlParameter("@alarma", alarma)
            };


            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexion(), CommandType.StoredProcedure, "SP_Tracking", commandParameters);
            return results;
        }
    }
}
