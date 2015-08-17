using System;
using System.Collections.Generic;
using System.Xml;
using WcfGps.Content;

namespace WcfGps
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }


        public XmlElement WPL_GPS(string tipo, string fecha, string patente, int folioOrigen, int folioDestino, int minutos,
            int kms)
        {
            var xa = new DbGeneral().WPL_GPS(tipo, fecha, patente, folioOrigen, folioDestino, minutos, kms);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_TraePosicionxPosicion(int id)
        {
            var xa = new DbGeneral().SP_TraePosicionxPosicion(id);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_Configuracion()
        {
            var xa = new DbGeneral().SP_Configuracion();

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_InsertaUpdateMonitorContrato(string tipo, int gpsDispositivoId, int origen, int destino, string fecha, double tiempo_detenido, double tiempo_puntos, double kms, int id_in, int id_out)
        {
            var xa = new DbGeneral().SP_InsertaUpdateMonitorContrato(tipo, gpsDispositivoId, origen, destino, fecha, tiempo_detenido, tiempo_puntos, kms, id_in, id_out);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_ConsultaMonitorDetenido(int gpsDispositivoId)
        {
            var xa = new DbGeneral().SP_ConsultaMonitorDetenido(gpsDispositivoId);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_ConsultaControlRuta(int idDispositivo, string fecha)
        {
            var xa = new DbGeneral().SP_ConsultaControlRuta(idDispositivo, fecha);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_TraePosiciones(int id, string fechain, string fechaout)
        {
            var xa = new DbGeneral().SP_TraePosiciones(id, fechain, fechaout);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_MarcaAlarma(int id)
        {
            var xa = new DbGeneral().SP_MarcaAlarma(id);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_ListaDispositivosPosicion()
        {
            var xa = new DbGeneral().SP_ListaDispositivosPosicion();
            
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_ListaDispositivosPosicionId(int id)
        {
            var xa = new DbGeneral().SP_ListaDispositivosPosicionId(id);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_ListaDispositivos()
        {
            var xa = new DbGeneral().SP_ListaDispositivos();

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_ListaDispositivosID(int id)
        {
            var xa = new DbGeneral().SP_ListaDispositivosID(id);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_GetColores()
        {
            var xa = new DbGeneral().SP_GetColores();

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement SP_GetColoresID(int id)
        {
            var xa = new DbGeneral().SP_GetColoresID(id);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
            return xd.DocumentElement;
        }

        public XmlElement WPL_POW_EntregaRetiro(string tipo, int folio, string cliente, string fechad, string fechah, string sku, string nombrefoto, int movId, string cadena, int userId, string patente, string estWop)
        {
            var xa = new DbGeneral().WPL_POW_EntregaRetiro(tipo, folio, cliente, fechad, fechah, sku, nombrefoto, movId, cadena, userId, patente, estWop);

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xa);
           
            return xd.DocumentElement;
        }

        public string SP_UpdateDispositivo(int id, string nombre, string modelo, string patente, string imei, string numero,  int activo, int color)
        {
            var xa = new DbGeneral().SP_UpdateDispositivo(id, nombre, modelo, patente, imei, numero, activo, color);
            return xa;
        }

        public string SP_InsertaDispositivo(string nombre, string modelo, string patente, string imei, string numero, int activo, int color)
        {
            var xa = new DbGeneral().SP_InsertaDispositivo(nombre, modelo, patente, imei, numero, activo, color);
            return xa;
        }


        public string SP_InsertaPosicion(string direccion, double altitud, double curso, double latitud, double longitud, string otros, int poder,
            double velocidad, DateTime fechahora, int valido, int dispositivo_id)
        {
            var xa = new DbGeneral().SP_InsertaPosicion(direccion, altitud, curso, latitud, longitud, otros, poder, velocidad, fechahora, valido, dispositivo_id);
            return xa;
        }

        public string SP_InsertaControlRuta(int gpsDispositivoId, double radio, double latitud, double longitud, int folio, string direccion, string fecha)
        {
            var xa = new DbGeneral().SP_InsertaControlRuta(gpsDispositivoId, radio, latitud, longitud, folio, direccion, fecha);
            return xa;
        }

    }
}
