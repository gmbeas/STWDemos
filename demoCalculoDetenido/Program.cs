using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCalculoDetenido
{
    static class Program
    {
        static void Main(string[] args)
        {
            var objGps = new wcfGps.Service1Client();

            var lista = objGps.SP_TraePosiciones(2, "18/02/2015 15:00:00", "18/02/2015 17:00:00");

            var listOkey = lista.ParseXml<Dispositivos>();

            var duplicates = listOkey.Tabla
                .GroupBy(i => new { i.Latitud, i.Longitud })
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);



            var pp = new MyClass();
            
            var contador = 0;
            var fechahoraIN = "";
            var distancia = 0.0;
            var lat = 0.0;
            var lon = 0.0;
            foreach (var t in listOkey.Tabla)
            {
                if (lat != 0.0)
                {
                    distancia = distancia + Distance(lat, lon, double.Parse(t.Latitud.Replace(".", ",")), double.Parse(t.Longitud.Replace(".", ",")), 'K');
                }

                var ppa = false;
                
                foreach (var d in duplicates)
                {
                    if (t.Latitud == d.Latitud && t.Longitud == d.Longitud)
                    {
                        if (contador == 0)
                        {
                            fechahoraIN = t.FechaHora;
                        }
                        if (contador == d.Latitud.Count())
                        {
                            var hora1= Convert.ToDateTime(fechahoraIN);
                            var hora2 = Convert.ToDateTime(t.FechaHora);

                            var diff1 = hora2.Subtract(hora1);
                            var nn = diff1.ToString(@"hh\:mm\:ss");
                            pp.Info.Add(new Demo
                            {
                                Latitud = t.Latitud,
                                Longitud = t.Longitud,
                                InfoWindows = nn
                            });
                        }
                        ppa = true;
                        contador++;
                    }
                }




                if (ppa == false)
                {
                    contador = 0;
                    pp.Info.Add(new Demo
                    {
                        Latitud = t.Latitud,
                        Longitud = t.Longitud
                    });
                   
                }

                lat = double.Parse(t.Latitud.Replace(".",","));
                lon = double.Parse(t.Longitud.Replace(".", ","));

            }

            pp.Kilometros = Math.Round(distancia, 2).ToString();


        }


        private class MyClass
        {
            public List<Demo> Info = new List<Demo>();
            public string Kilometros { get; set; }

        }

        private class Demo
        {
            public  string Latitud { get; set; }
            public string Longitud { get; set; }
            public string InfoWindows { get; set; }
        }

       

        private static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
