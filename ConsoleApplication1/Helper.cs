using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    public static class Helper
    {
        #region ExtraeDistancia
        public static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
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
        #endregion

        public static string DireccionToCardinal(double degrees)
        {
            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSO", "SO", "OSO", "O", "ONO", "NO", "NNO", "N" };
            return caridnals[(int)Math.Round(((double)degrees * 10 % 3600) / 225)];
        }


        public static T ParseXml<T>(this XElement @this) where T : class
        {
            var xml = ToXmlElement(@this);
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml.OuterXml)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }





        #region Extention Method
        private static XElement ToXElement(this XmlElement element)
        {
            return XElement.Parse(element.OuterXml);
        }

        private static XmlElement ToXmlElement(this XElement element)
        {
            var doc = new XmlDocument();
            doc.LoadXml(element.ToString());
            return doc.DocumentElement;
        }
        #endregion
    }
}
