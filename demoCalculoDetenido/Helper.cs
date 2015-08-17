using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace demoCalculoDetenido
{
    public static class Helper
    {
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
