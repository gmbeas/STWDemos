using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using GoogleMaps.LocationServices;
using GpsWeb2.Collection;
using GpsWeb2.Helpers;
using GpsWeb2.Models;

namespace GpsWeb2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult GeneraRutas()
        {
            return View();
        }


        public ActionResult Index()
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_ListaDispositivos();

            var listOkey = lista.ParseXml<Dispositivos>();

            ViewBag.Dispositivos = listOkey;

            return View();
        }

        public ActionResult BuscaContrato(string dato)
        {
            var listdatos = new List<DatosPatenteContrato>();
            var objGps = new wsGps.Service1Client();
            var lista = objGps.SP_ListaDispositivos();
            var listOkey = lista.ParseXml<Dispositivos>();
           
            //var pp = objGps.WPL_POW_EntregaRetiro(dato, "");
            //var xxa = pp.ParseXml<BusquedaContrato>();




            //var direccion = "";
            //var comuna = "";
            //var ciudad = "";
            //var id = "";
            //if (xxa.TablaContrato == null)
            //{
            //    var ppa = objGps.WPL_POW_EntregaRetiro("", dato);
            //    var xxaa = ppa.ParseXml<BusquedaContrato>();
            //    if (xxaa.TablaContrato != null)
            //    {
            //        listdatos.AddRange(from x in xxaa.TablaContrato
            //            where x.Patente != ""
            //            select new DatosPatenteContrato
            //            {
            //                Patente = x.Patente, Rut = x.CodCliente, Id = id
            //            });
            //    }
            //}
            //else
            //{
            //    foreach (var t in listOkey.Tabla)
            //    {
            //        foreach (var x in xxa.TablaContrato)
            //        {
            //            if (t.Patente == x.Patente)
            //            {
            //                id = t.Id;
            //                direccion = x.Direccion;
            //                comuna = x.Comuna;
            //                ciudad = x.Ciudad;
            //            }
                            
            //        }
            //    }
                           

            //    var url = new Uri("http://maps.google.com/maps/api/geocode/xml?address=" + direccion + "&sensor=false");
              
            //      var address = direccion +","+comuna+","+ciudad;
            //      var locationService = new GoogleLocationService();
            //      var point = locationService.GetLatLongFromAddress(address); 
            //      var latitude = point.Latitude; 
            //      var longitude = point.Longitude; 


            //    listdatos.AddRange(from x in xxa.TablaContrato
            //        where x.Patente != ""
            //        select new DatosPatenteContrato
            //        {
            //            Patente = x.Patente, 
            //            Rut = x.CodCliente, 
            //            Id = id, 
            //            Latitud =  latitude.ToString(CultureInfo.CurrentCulture), 
            //            Longitud = longitude.ToString(CultureInfo.CurrentCulture)
            //        });
            //}


            

            return Json(listdatos, JsonRequestBehavior.AllowGet);
        }


        private class DatosPatenteContrato
        {
            public string Patente { get; set; }
            public string Rut { get; set; }
            public string Id { get; set; }
            public string Latitud { get; set; }
            public string Longitud { get; set; }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult GetPosicionesRuta(int idDispositivo, string fechain, string fechaout)
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_TraePosiciones(idDispositivo, fechain, fechaout);

            var listOkey = lista.ParseXml<Dispositivos>();

            var xx = new HelperDistanciaTiempo();

            DistanciaTrackModel info = xx.GetDistanciaTiempo(listOkey);

            return Json(info, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetVehiculos()
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_ListaDispositivos();

            var listOkey = lista.ParseXml<Dispositivos>();

            return Json(listOkey.Tabla, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMarker()
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_ListaDispositivosPosicion();

            var listOkey = lista.ParseXml<Dispositivos>();

            return Json(listOkey.Tabla, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditaVehiculos()
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_ListaDispositivos();

            var listOkey = lista.ParseXml<Dispositivos>();

            ViewBag.Dispositivos = listOkey;
            return View();
        }


        public ActionResult GetDireccion(string dato)
        {

            var info = Helper.DireccionToCardinal(Convert.ToDouble(dato));

            return Json(info, JsonRequestBehavior.AllowGet);
        }



        public ActionResult GetContratosPatente(string patente)
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.WPL_POW_EntregaRetiro("LISTOT", 0, "", "2015/03/01", "2015/03/01", "", "", 0, "", 564, patente, "0,2,3,6");

            var listOkey = lista.ParseXml<BusquedaContrato>();

            return Json(listOkey, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CountryLookup()
        {

            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_ListaDispositivos();

            var listOkey = lista.ParseXml<Dispositivos>();

            var countries = listOkey.Tabla.Select(t => new SearchTypeAheadEntity
            {
                ShortCode = t.Id, Name = t.Patente
            }).ToList();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

      

        public ActionResult InsertaDispositivo(string nombre, string modelo, string patente, string imei, string numero, int activo, int color)
        {
            var objGps = new wsGps.Service1Client();

            var xx = objGps.SP_InsertaDispositivo(nombre, modelo, patente, imei, numero, activo, color);

            return Json(xx, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult UpdateDispositivo(int id, string nombre, string modelo, string patente, string imei, string numero, int activo, int color)
        {

            var objGps = new wsGps.Service1Client();

            var xx = objGps.SP_UpdateDispositivo(id, nombre, modelo, patente, imei, numero, activo, color);

            return Json(xx, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetColores()
        {
            var objGps = new wsGps.Service1Client();
            var pp = objGps.SP_GetColores();
            var xx = pp.ParseXml<Colores>();

            return Json(xx.TablaColor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDispositivo(int id)
        {
            var objGps = new wsGps.Service1Client();
            var pp = objGps.SP_ListaDispositivosID(id);
            var xx = pp.ParseXml<Dispositivos>();

            return Json(xx.Tabla, JsonRequestBehavior.AllowGet);
        }


        
        public ActionResult PopUpDispositivo(int id)
        {
            ViewBag.idDispositivo = id;
            return View();
        }


        public ActionResult GetMarkerPopUpId(int id)
        {
            var objGps = new wsGps.Service1Client();

            var lista = objGps.SP_ListaDispositivosPosicionId(id);

            var listOkey = lista.ParseXml<Dispositivos>();

            return Json(listOkey.Tabla, JsonRequestBehavior.AllowGet);
        }

    }
}