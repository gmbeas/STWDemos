using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ConsoleApplication1.prueba;
using GoogleMaps.LocationServices;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApplication1
{
    static class Program
    {
        public class Demo1
        {
            public List<Demo2> Nombre = new List<Demo2>();
        }

        public class Demo2
        {
            public List<Demo3> Nombre = new List<Demo3>();
        }

        public class Demo3
        {
            public string Nombre { get; set; }
        }


        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }



        public static long ToUnixTimestamp(this DateTime target)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            var unixTimestamp = System.Convert.ToInt64((target - date).TotalSeconds);

            return unixTimestamp;
        }

        public static DateTime ToDateTime(this DateTime target, long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);

            return dateTime.AddSeconds(timestamp);
        }


        static void Main(string[] args)
        {
            //var au = FromUnixTime(1216598400000);
            DateTime au = Convert.ToDateTime("21-07-2008");

            var timestampx = au.ToUnixTimestamp() * 1000;
            Console.WriteLine("==== Unix Timestamp ====");
            Console.WriteLine(timestampx);

           

            //// First make a System.DateTime equivalent to the UNIX Epoch.
            //System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            //// Add the number of seconds in UNIX timestamp to be converted.
            //dateTime = dateTime.AddSeconds(timestamp);

            //// The dateTime now contains the right date/time so to format the string,
            //// use the standard formatting methods of the DateTime object.
            //string printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();


            //DateTime au = Convert.ToDateTime("22-07-2008");

            //TimeSpan unix_time = (DateTime.UtcNow - au);

            //var aaaax = unix_time.TotalSeconds;
            //var aaaaa = au.ToUnixTime();

            //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(2008, 7, 22,0,0,0))).TotalSeconds;
            //var aaaa = unixTimestamp*1000;

            //string date = "21-07-2008";
            //// Local .NET timeZone.
            //DateTime localDateTime = DateTime.Parse(date);
            //var xx5 = localDateTime.tot
            //DateTime utcDateTime = localDateTime.ToUniversalTime();



            var myList = new List<string>[] { new List<string>(), new List<string>() };

            for (int i = 0; i <= 12; i++)
            {
                if (i == 1)
                    myList.Last().Add(i.ToString());
                else
                    myList.First().Add(i.ToString());
            }




            using (TextFieldParser parser = new TextFieldParser("D:\\update.csv"))
            {
                parser.Delimiters = new string[] { ";" };
                var x = 0;
                while (true)
                {
                    string[] parts = parser.ReadFields();
                    if (parts == null)
                    {
                        break;
                    }
                    if (x != 0)
                    {

                        string connectionString = "Data Source=192.168.1.252;Initial Catalog=LISA_ERP;Integrated Security=False;User ID=sa; Password=";
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            var consulta = string.Format("update FALVE set gcfacdep = 202 where  GcFacFolti={0}",
                                parts[1]);
                            using (SqlCommand cmd = new SqlCommand(consulta, conn))
                            {
                                cmd.ExecuteNonQuery();
                               
                            }
                        }
                        Console.WriteLine("{0} Folio(s)", parts[1]);
                    }
                    x++;
                }
            }




            var demo = new objDemo.Service1Client();

            var aaa = demo.GetData(1);




            var objGps = new Service1Client();
            var listConfig = objGps.SP_Configuracion();
            var objConfig = listConfig.ParseXml<Configuracion>();

            /**************************************************/
            //INICIO INSERTAR COORDENADAS CONTRATOS POR PATENTE
            /**************************************************/
            //var listDispositivox = objGps.SP_ListaDispositivos();

            //var dispositivosx = listDispositivox.ParseXml<Dispositivos>();

            //var fe = "23/02/2015"; // DateTime.Now.ToString("dd/MM/yyyy");
            //var fi = "2015/02/23"; // DateTime.Now.ToString("yyyy/MM/dd");
            //const int radio = 1000;
            //foreach (var x in dispositivosx.Tabla)
            //{
            //    var listContrato = objGps.WPL_POW_EntregaRetiro("LISTOT", 0, "", fi, fi, "", "", 0, "",
            //    564, x.Patente, "0,2,3,6");

            //    var contratos = listContrato.ParseXml<BusquedaContrato>();
            //    if (contratos.TablaContrato != null)
            //    {
            //        foreach (var t in contratos.TablaContrato)
            //        {
            //            var objGeoLocaliza = new GoogleLocationService();
            //            var objLatLon = objGeoLocaliza.GetLatLongFromAddress(t.Dir1 + ", CHILE");

            //            var objInserta = objGps.SP_InsertaControlRuta(x.Id, radio, objLatLon.Latitude, objLatLon.Longitude,
            //                int.Parse(t.Folio), t.Dir1, fe);
            //        }
            //    }


            //    var objInsertax = objGps.SP_InsertaControlRuta(x.Id, objConfig.TablaConfiguracion[0].GeoInicioRadioMetros, objConfig.TablaConfiguracion[0].GeoInicioLatitud, objConfig.TablaConfiguracion[0].GeoInicioLongitud,
            //              1, "Casa Matriz", fe);
            //}
            /**************************************************/
            //FIN INSERTAR COORDENADAS CONTRATOS POR PATENTE
            /**************************************************/




            while (true)
            {
                var fechaMovimiento = "23/02/2015"; //DateTime.Now.ToString("dd/MM/yyyy");

                var listDispositivo = objGps.SP_ListaDispositivos();

                var dispositivos = listDispositivo.ParseXml<Dispositivos>();



                foreach (var t in dispositivos.Tabla)
                {

                    var ultimaPosicionDs = objGps.SP_ListaDispositivosPosicionId(t.Id);
                    var ultimaPosicion = ultimaPosicionDs.ParseXml<Dispositivos>();

                    var pointCamion = new PointF
                    {
                        X = ConvierteDouble(ultimaPosicion.Tabla[0].Latitud),
                        Y = ConvierteDouble(ultimaPosicion.Tabla[0].Longitud)
                    };

                    var gic = objGps.SP_InsertaUpdateMonitorContrato("C", t.Id, 0, 0, fechaMovimiento, 0, 0, 0, 0, 0);
                    var infoContrato = gic.ParseXml<MonitorContrato>();

                    if (infoContrato.TablaMonitorContrato == null)
                    {
                        objGps.SP_InsertaUpdateMonitorContrato("A", t.Id, 0, 0, fechaMovimiento, 0, 0, 0, 0, 0);
                    }
                    else
                    {
                        if (double.Parse(ultimaPosicion.Tabla[0].Velocidad) < 1)
                        {
                            var listMonitorDetenido = objGps.SP_ConsultaMonitorDetenido(t.Id);
                            var monitorDetenido = listMonitorDetenido.ParseXml<MonitorDetenido>();

                            var minDet = ConvierteDouble(monitorDetenido.TablaMonitorDetenido[0].Tiempo);

                            objGps.SP_InsertaUpdateMonitorContrato("A", t.Id, int.Parse(infoContrato.TablaMonitorContrato[0].Origen), int.Parse(infoContrato.TablaMonitorContrato[0].Destino),
                            fechaMovimiento, minDet, ConvierteDouble(infoContrato.TablaMonitorContrato[0].TiempoPuntos),
                            ConvierteDouble(infoContrato.TablaMonitorContrato[0].Kilometros), int.Parse(t.UltimaPosicionId), int.Parse(infoContrato.TablaMonitorContrato[0].IdOut));

                            if (int.Parse(infoContrato.TablaMonitorContrato[0].Destino) != 0)
                            {
                                var mm = objGps.WPL_GPS("ACTW", fechaMovimiento, t.Patente, int.Parse(infoContrato.TablaMonitorContrato[0].Destino),
                               0, Convert.ToInt32(minDet), 0);
                            }
                            else
                            {
                                var mm = objGps.WPL_GPS("ACTW", fechaMovimiento, t.Patente, int.Parse(infoContrato.TablaMonitorContrato[0].Origen),
                              0, Convert.ToInt32(minDet), 0);
                            }

                        }

                    }

                    var listRutasPerimetro = objGps.SP_ConsultaControlRuta(t.Id, fechaMovimiento);
                    var rutaPerimetro = listRutasPerimetro.ParseXml<ControlRuta>();

                    if (rutaPerimetro.TablaControlRuta != null)
                    {
                        foreach (var x in rutaPerimetro.TablaControlRuta)
                        {

                            var dist = 0.0;
                            var lat = 0.0;
                            var lon = 0.0;
                            var mintranscurrido = 0.0;

                            var listMonitorDetenido = objGps.SP_ConsultaMonitorDetenido(t.Id);
                            var monitorDetenido = listMonitorDetenido.ParseXml<MonitorDetenido>();

                            var minDet = ConvierteDouble(monitorDetenido.TablaMonitorDetenido[0].Tiempo);

                            var pointFolio = new PointF
                            {
                                X = ConvierteDouble(x.Latitud),
                                Y = ConvierteDouble(x.Longitud)
                            };

                            var radioFolio = ConvierteDouble(x.Radio);

                            if (IsPointInCircle(pointFolio, radioFolio, pointCamion)) // TRUE: si entra al perimetro, FALSE: si esta fuera el perimetro
                            {
                                if (infoContrato.TablaMonitorContrato != null)
                                {
                                    var aa = infoContrato.TablaMonitorContrato[0].Origen;
                                    var bb = infoContrato.TablaMonitorContrato[0].Destino;

                                    if (aa == "" || aa == "0")
                                    {
                                        objGps.SP_InsertaUpdateMonitorContrato("A", t.Id, int.Parse(x.Folio), 0, fechaMovimiento, 0, 0, 0, int.Parse(t.UltimaPosicionId), 0);
                                    }
                                    else
                                    {
                                        if (int.Parse(aa) != int.Parse(x.Folio))
                                        {
                                            var ap = objGps.SP_TraePosicionxPosicion(int.Parse(infoContrato.TablaMonitorContrato[0].IdIn));
                                            var ax = ap.ParseXml<Dispositivos>();
                                            if (ax.Tabla != null)
                                            {
                                                lat = ConvierteDouble(ax.Tabla[0].Latitud);
                                                lon = ConvierteDouble(ax.Tabla[0].Longitud);
                                                var fechahora1 =
                                                    Convert.ToDateTime(ax.Tabla[0].FechaHora)
                                                        .ToString("dd/MM/yyyy HH:mm:ss");
                                                var fechahora2 =
                                                    Convert.ToDateTime(t.FechaHora).ToString("dd/MM/yyyy HH:mm:ss");

                                                var dat1 = Convert.ToDateTime(fechahora1);
                                                var dat2 = Convert.ToDateTime(fechahora2);

                                                var transcurrido = dat2.Subtract(dat1);
                                                mintranscurrido = Math.Round(transcurrido.TotalMinutes);


                                                var lisPosi = objGps.SP_TraePosiciones(t.Id, fechahora1, fechahora2);
                                                var posicionAll = lisPosi.ParseXml<Dispositivos>();

                                                foreach (var o in posicionAll.Tabla)
                                                {
                                                    var xx = ConvierteDouble(o.Latitud);
                                                    var yy = ConvierteDouble(o.Longitud);
                                                    var ah = Helper.Distance(lat, lon, xx, yy, 'K');
                                                    dist = dist + ah;
                                                    lat = xx;
                                                    lon = yy;
                                                }
                                            }

                                            if (bb == "" || bb == "0")
                                            {
                                                if (minDet > 4)
                                                {
                                                    objGps.SP_InsertaUpdateMonitorContrato("A", t.Id, int.Parse(aa), int.Parse(x.Folio), fechaMovimiento, minDet, mintranscurrido, dist, 0, 0);
                                                    var mm = objGps.WPL_GPS("ACTK", fechaMovimiento, t.Patente, int.Parse(aa), int.Parse(x.Folio), Convert.ToInt32(mintranscurrido), Convert.ToInt32(dist));
                                                }

                                            }
                                            else
                                            {
                                                if (int.Parse(bb) != int.Parse(x.Folio))
                                                {
                                                    if (minDet > 4)
                                                    {
                                                        objGps.SP_InsertaUpdateMonitorContrato("A", t.Id, int.Parse(bb), int.Parse(x.Folio), fechaMovimiento, minDet, mintranscurrido, dist, 0, 0);
                                                        var mm = objGps.WPL_GPS("ACTK", fechaMovimiento, t.Patente, int.Parse(bb), int.Parse(x.Folio), Convert.ToInt32(mintranscurrido), Convert.ToInt32(dist));
                                                    }

                                                }

                                            }
                                        }

                                    }

                                }
                            }


                        }
                    }



                }

                Thread.Sleep(5000);
            }

        }

        private static int EstaEnFolio(int id, string fecha, PointF pointCamion)
        {
            var objGps = new Service1Client();
            var listRutasPerimetro = objGps.SP_ConsultaControlRuta(id, fecha);
            var rutaPerimetro = listRutasPerimetro.ParseXml<ControlRuta>();
            if (rutaPerimetro.TablaControlRuta != null)
            {
                foreach (var t in rutaPerimetro.TablaControlRuta)
                {
                    var pointFolio = new PointF
                    {
                        X = ConvierteDouble(t.Latitud),
                        Y = ConvierteDouble(t.Longitud)
                    };

                    var radioFolio = ConvierteDouble(t.Radio);

                    if (IsPointInCircle(pointFolio, radioFolio, pointCamion))
                    // TRUE: si entra al perimetro, FALSE: si esta fuera el perimetro
                    {
                        return int.Parse(t.Folio);
                    }
                }
            }
            return 0;
        }

        private static double ConvierteDouble(string valor)
        {
            return double.Parse(valor.Replace(".", ","));
        }

        private static bool EstaEnCasaMatriz(Configuracion configura, PointF coordenadaCamion)
        {
            var pointCasaMatriz = new PointF
            {
                X = configura.TablaConfiguracion[0].GeoInicioLatitud,
                Y = configura.TablaConfiguracion[0].GeoInicioLongitud
            };

            if (IsPointInCircle(pointCasaMatriz, configura.TablaConfiguracion[0].GeoInicioRadioMetros, coordenadaCamion))// TRUE: se encuentra en CasaMatriz, FALSE: si esta fuera el perimetro de casa Matriz
            {
                return true;
            }
            return false;
        }


        public static bool ContainsPoint(PointF centre, double radius, PointF toTest)
        {
            // Is the point inside the circle? Sum the squares of the x-difference and
            // y-difference from the centre, square-root it, and compare with the radius.
            // (This is Pythagoras' theorem.)

            var dX = Math.Abs(toTest.X - centre.X);
            var dY = Math.Abs(toTest.Y - centre.Y);

            var sumOfSquares = dX * dX + dY * dY;

            double distance = (double)Math.Sqrt(sumOfSquares);

            return (radius >= distance);
        }


        public static bool IsPointInCircle(PointF centre, double radius, PointF toTest)
        {
            var radius2 = 0.001 * radius; //KM

            //Calculate distance earth between 2 coordinate point
            double e = centre.X * (Math.PI / 180);
            double f = centre.Y * (Math.PI / 180);
            double g = toTest.X * (Math.PI / 180);
            double h = toTest.Y * (Math.PI / 180);
            double i =
                (Math.Cos(e) * Math.Cos(g) * Math.Cos(f) * Math.Cos(h)
                + Math.Cos(e) * Math.Sin(f) * Math.Cos(g) * Math.Sin(h)
                + Math.Sin(e) * Math.Sin(g));
            double j = Math.Acos(i);
            double k = (6371 * j);  //Distance in KM

            return radius2 >= k;
        }


        public static bool IsPointInPolygon4(PointF[] polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public class PointF
        {
            public double Y { get; set; }
            public double X { get; set; }
        }




        public static T ParseXML<T>(this XmlElement @this) where T : class
        {
            var xx = @this.OuterXml;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(@this.OuterXml)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }

        #region Extention Method
        public static XElement ToXElement(this XmlElement element)
        {
            return XElement.Parse(element.OuterXml);
        }

        public static XmlElement ToXmlElement(this XElement element)
        {
            var doc = new XmlDocument();
            doc.LoadXml(element.ToString());
            return doc.DocumentElement;
        }
        #endregion
    }




}
