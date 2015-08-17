using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GpsWeb2.Collection;
using GpsWeb2.Models;

namespace GpsWeb2.Helpers
{
    public class HelperDistanciaTiempo
    {
        public DistanciaTrackModel GetDistanciaTiempo(Dispositivos info)
        {
            var duplicates = info.Tabla
               .GroupBy(i => new { i.Latitud, i.Longitud })
               .Where(g => g.Count() > 1)
               .Select(g => g.Key);


            var infoDato = new DistanciaTrackModel();
            var contador = 0;
            var fechahoraIN = "";
            var distancia = 0.0;
            var lat = 0.0;
            var lon = 0.0;

            foreach (var t in info.Tabla)
            {
                if (lat != 0.0)
                {
                    distancia = distancia + Helper.Distance(lat, lon, double.Parse(t.Latitud.Replace(".", ",")), double.Parse(t.Longitud.Replace(".", ",")), 'K');
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
                            var hora1 = Convert.ToDateTime(fechahoraIN);
                            var hora2 = Convert.ToDateTime(t.FechaHora);

                            var diff1 = hora2.Subtract(hora1);
                            var nn = diff1.ToString(@"hh\:mm\:ss");
                            infoDato.Info.Add(new InfoTrack
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
                    infoDato.Info.Add(new InfoTrack
                    {
                        Latitud = t.Latitud,
                        Longitud = t.Longitud
                    });

                }

                lat = double.Parse(t.Latitud.Replace(".", ","));
                lon = double.Parse(t.Longitud.Replace(".", ","));

            }

            infoDato.Kilometros = Math.Round(distancia, 2).ToString();

            return infoDato;
        }
    }
}