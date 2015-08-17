using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpsWeb2.Models
{
    
        public class DistanciaTrackModel
        {
            public List<InfoTrack> Info = new List<InfoTrack>();
            public string Kilometros { get; set; }

        }

        public class InfoTrack
        {
            public string Latitud { get; set; }
            public string Longitud { get; set; }
            public string InfoWindows { get; set; }
        }
   
}