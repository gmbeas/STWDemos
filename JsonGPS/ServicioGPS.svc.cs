using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JsonGPS.Content;

namespace JsonGPS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioGPS : IServicioGPS
    {
        public List<GeoCercaPosicionModel> GetGeoCercaPosiciones(string id)
        {
            var ds = DbGeneral.SP_GeoCerca("CONP",0, "", "", 0, int.Parse(id), 0, 0, 0);
            var lst = ds.Tables[0].ToList<GeoCercaPosicionModel>();
            return lst;
        }
        public List<GeoCercaNombreModel> GetGeoCercaNombre(string id)
        {
            var ds = DbGeneral.SP_GeoCerca("CONN", int.Parse(id), "", "", 0,  0, 0, 0, 0);
            var lst = ds.Tables[0].ToList<GeoCercaNombreModel>();
            return lst;
        }

        public InsertaGeocercaModel InsertaGeoCerca(string id, string latitud, string longitud, string radio)
        {
            var ds = DbGeneral.SP_GeoCerca("INSG", 0, "", "", 0, int.Parse(id), double.Parse(latitud.Replace('.', ',')), double.Parse(longitud.Replace('.', ',')), double.Parse(radio.Replace('.', ',')));
            var dr = ds.Tables[0].Rows[0];
            var info = new InsertaGeocercaModel { Flag = int.Parse(dr["flag"].ToString()), Mensaje = dr["Mensaje"].ToString()};
            return info;
        }

        public InsertaNombreGeocercaModel InsertaNombreGeoCerca(string id, string nombre, string tipogeo)
        {
            var ds = DbGeneral.SP_GeoCerca("INSN", int.Parse(id), nombre, tipogeo, 1, 0, 0, 0, 0);
            var dr = ds.Tables[0].Rows[0];
            var info = new InsertaNombreGeocercaModel {IdNombre = int.Parse(dr["IdNombre"].ToString())};
            return info;
        }

        public List<DispositivosModel> GetDispositivos()
        {
            var ds = DbGeneral.SP_Dispositivo("CON", 0, 0, "", "", 0, "","","",0, DateTime.Now, 0, 1, 0, 0);
            var lst = ds.Tables[0].ToList<DispositivosModel>();
            return lst;
        }

        public List<UltimaPosicionModel> GetUltimaPosicionTodos()
        {
            var ds = DbGeneral.SP_Tracking("CO1", 1, 1,1,0,0,0,DateTime.Now, DateTime.Now, 0,"");
            var lst = ds.Tables[0].ToList<UltimaPosicionModel>();
            return lst;
        }

        public List<UltimaPosicionModel> GetUltimaPosicionId(int id)
        {
            var ds = DbGeneral.SP_Tracking("CO2", 1, 1, 1, 0, id, 0, DateTime.Now, DateTime.Now, 0, "");
            var lst = ds.Tables[0].ToList<UltimaPosicionModel>();
            return lst;
        }

        public Stream GetImage(string tipo, string color, string alto, string ancho)
        {
            var ms = Helper.ModificaImagen(tipo, color, alto, ancho);
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";
            return ms;
        }

        public ColorModel GetColor(string id)
        {
            var colorcito = Colores.GetColor(int.Parse(id));

            var info = new ColorModel {Valor = Helper.GetColor(colorcito)};
            return info;
        }
        

        
    }
}
