using System;
using System.Data;
using System.Data.SqlClient;

namespace WcfGps.Content
{
    public sealed class DbGeneral
    {

        public string WPL_POW_EntregaRetiro2()
        {
            //WPL_POW_EntregaRetiro 'LISTOT',140835,'','2015/02/16','2015/02/16','','',0,'',564,'','0,2,3,6'
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexionAlpha());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", "LISTOT"),
                new SqlParameter("@Folio", 0),
                new SqlParameter("@Cliente", 0),
                new SqlParameter("@FechaD", "2015/03/06"),
                new SqlParameter("@FechaH", "2015/03/06"),
                new SqlParameter("@Sku", ""),
                new SqlParameter("@NombreFoto", ""),
                new SqlParameter("@MOV_Id", 0),
                new SqlParameter("@Cadena", ""),
                new SqlParameter("@USR_Id", 564),
                new SqlParameter("@Patente", ""),
                new SqlParameter("@EST_Wop", "0,2,3,6")
            };

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "WPL_POW_EntregaRetiro", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_TraePosicionxPosicion(int id)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_TraePosicionxPosicion", commandParameters);
            var nn = result.GetXml();
            return nn;
        }

        public string SP_Configuracion()
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_Configuracion", null);
            var nn = result.GetXml();
            return nn;
        }

        public string SP_InsertaUpdateMonitorContrato(string tipo, int gpsDispositivoId, int origen, int destino, string fecha, double tiempo_detenido, double tiempo_puntos, double kms, int id_in, int id_out)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@gps_dispositivo_id", gpsDispositivoId),
                new SqlParameter("@origen", origen),
                new SqlParameter("@destino", destino),
                new SqlParameter("@fecha", fecha),
                new SqlParameter("@tiempo_detenido", tiempo_detenido),
                new SqlParameter("@tiempo_puntos", tiempo_puntos),
                new SqlParameter("@kms", kms),
                new SqlParameter("@id_in", id_in),
                new SqlParameter("@id_out", id_out)
            };

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_InsertaUpdateMonitorContrato", commandParameters);
            var nn = result.GetXml();
            return nn;
        }

        public string SP_ConsultaMonitorDetenido(int gpsDispositivoId)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@gps_dispositivo_id", gpsDispositivoId)
            };

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_ConsultaMonitorDetenido", commandParameters);
            var nn = result.GetXml();
            return nn;
        }

        public string SP_InsertaControlRuta(int gpsDispositivoId, double radio, double latitud, double longitud, int folio, string direccion, string fecha)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@gps_dispositivo_id", gpsDispositivoId),
                new SqlParameter("@radio", radio),
                new SqlParameter("@latitud", latitud),
                new SqlParameter("@longitud", longitud),
                new SqlParameter("@folio", folio),
                new SqlParameter("@direccion", direccion),
                new SqlParameter("@fecha", fecha)
            };

            var result = ProcedureExecuter.ExecuteNonQuery(CommandType.StoredProcedure, "SP_InsertaControlRuta", commandParameters);
            return result.ToString();
        }

        public string WPL_GPS(string tipo, string fecha, string patente, int folioOrigen, int folioDestino, int minutos, int kms)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexionDelta());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@Fecha", fecha),
                new SqlParameter("@Patente", patente),
                new SqlParameter("@FolioOrigen", folioOrigen),
                new SqlParameter("@FolioDestino", folioDestino),
                new SqlParameter("@Minutos", minutos),
                new SqlParameter("@Kms", kms)
            };

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "WPL_GPS", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string WPL_POW_EntregaRetiro(string tipo, int folio, string cliente, string fechad, string fechah, string sku, string nombrefoto, int movId, string cadena, int userId, string patente, string estWop)
        {
            //WPL_POW_EntregaRetiro 'LISTOT',140835,'','2015/02/16','2015/02/16','','',0,'',564,'','0,2,3,6'
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexionAlpha());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@Folio", folio),
                new SqlParameter("@Cliente", cliente),
                new SqlParameter("@FechaD", fechad),
                new SqlParameter("@FechaH", fechah),
                new SqlParameter("@Sku", sku),
                new SqlParameter("@NombreFoto", nombrefoto),
                new SqlParameter("@MOV_Id", movId),
                new SqlParameter("@Cadena", cadena),
                new SqlParameter("@USR_Id", userId),
                new SqlParameter("@Patente", patente),
                new SqlParameter("@EST_Wop", estWop)
            };

            var result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "WPL_POW_EntregaRetiro", commandParameters);

            var nn = result.GetXml();
            return nn;
        }


        public string SP_ConsultaControlRuta(int idDispositivo, string fecha)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@gps_dispositivo_id", idDispositivo),
                new SqlParameter("@fecha", fecha)
            };

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_ConsultaControlRuta", commandParameters);

            var nn = result.GetXml();
            return nn;
        }


        public string SP_TraePosiciones(int id, string fechain, string fechaout)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@fechain", fechain),
                new SqlParameter("@fechaout", fechaout)
            };

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_TraePosiciones", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_MarcaAlarma(int id)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_MarcaAlarma", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_ListaDispositivosPosicion()
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_ListaDispositivosPosicion", null);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_ListaDispositivosPosicionId(int id)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());

            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@dispositivo_id", id)
            };

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_ListaDispositivosPosicionID", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_ListaDispositivos()
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_ListaDispositivos", null);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_ListaDispositivosID(int id)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_ListaDispositivosID", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_GetColores()
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_GetColores", null);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_GetColoresID(int id)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataSet result = ProcedureExecuter.ExecuteDataset(CommandType.StoredProcedure, "SP_GetColoresID", commandParameters);

            var nn = result.GetXml();
            return nn;
        }

        public string SP_UpdateDispositivo(int id, string nombre, string modelo, string patente, string imei, string numero, int activo, int color)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@patente", patente),
                new SqlParameter("@modelo", modelo),
                new SqlParameter("@imei", imei),
                new SqlParameter("@numero", numero),
                new SqlParameter("@estado", activo),
                new SqlParameter("@colorid", color),
            };

            var result = ProcedureExecuter.ExecuteNonQuery(CommandType.StoredProcedure, "SP_UpdateDispositivo", commandParameters);
            return result.ToString();
        }


        public string SP_InsertaDispositivo(string nombre, string modelo, string patente, string imei, string numero, int activo, int color)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@patente", patente),
                new SqlParameter("@modelo", modelo),
                new SqlParameter("@imei", imei),
                new SqlParameter("@numero", numero),
                new SqlParameter("@estado", activo),
                new SqlParameter("@colorid", color),
            };

            var result = ProcedureExecuter.ExecuteNonQuery(CommandType.StoredProcedure, "SP_InsertaDispositivo", commandParameters);
            return result.ToString();
        }

        public string SP_InsertaPosicion(string direccion, double altitud, double curso, double latitud, double longitud, string otros, int poder, 
            double velocidad, DateTime fechahora, int valido, int dispositivo_id)
        {
            ProcedureExecuter.ConexionSql = (new Conexion().CadenaConexion());
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@direccion", direccion),
                new SqlParameter("@altitud", altitud),
                new SqlParameter("@curso", curso),
                new SqlParameter("@latitud", latitud),
                new SqlParameter("@longitud", longitud),
                new SqlParameter("@otros", otros),
                new SqlParameter("@poder", poder),
                new SqlParameter("@velocidad", velocidad),
                new SqlParameter("@fechahora", fechahora),
                new SqlParameter("@valido", valido),
                new SqlParameter("@dispositivo_id", dispositivo_id)
            };

            var result = ProcedureExecuter.ExecuteNonQuery(CommandType.StoredProcedure, "SP_InsertaPosicion", commandParameters);
            return result.ToString();
        }
    }
}