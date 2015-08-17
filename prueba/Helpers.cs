using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace prueba
{
    internal static class ParseHelpers
    {
        public class InfoSku
        {
            public  string Sku { get; set; }
            public  string Descripcion { get; set; }
            public  string Valor { get; set; }

        }
        public static InfoSku GetProducto(string sku)
        {
            var info = new InfoSku();
            var objWop = new ws_wop.Pos();
            var resultado = objWop.WPL_Sku_Atributos("SPB", "X", "N", "STE", sku, 1, 24, "47465", 1, "", "50",
                "1", "0", "0", "0", "", "N", 1, "", "", 0, "");

            foreach (DataRow dr in resultado.Tables[0].Rows)
            {
                if (dr["SKU_Id"].ToString() != "0")
                {
                    info.Sku = dr["SKU"].ToString();
                    info.Descripcion = dr["NombreSku"].ToString();
                    info.Valor = dr["PrecioUnidad"].ToString();
                }
            }

            return info;
        }

          
        public static T ParseXmlClienteLisa<T>(this int @this) where T :class
        {
            var objLisa = new ws_lisa.WS_Lisa();
            var resultado = objLisa.ConsultaCliente("STE", @this);

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultado.OuterXml)))
            {
                var serializer = new XmlSerializer(typeof(ClienteLisa));
                return (T)serializer.Deserialize(stream);
            }
        }

        public static string RemoveTypeTagFromXml(string xml)
        {
            xml = xml.Replace("q1:", "");
            xml = xml.Replace(":q1", "");
            xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            return xml;

        }


        public static T ParseXmlRespuestaLisa<T>(this XmlDocument @this) where T : class
        {
            
            var objapws0109 = new apws0109.Pws0109();
            var resultado = objapws0109.Execute(@this.OuterXml);
            var xml = new XmlDocument();
            xml.LoadXml(resultado); 

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml.OuterXml)))
            {
                var serializer = new XmlSerializer(typeof(RespuestaLisa));
                return (T)serializer.Deserialize(stream);
            }
        }

        //private static JavaScriptSerializer json;
        //private static JavaScriptSerializer JSON { get { return json ?? (json = new JavaScriptSerializer()); } }

        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        public static T ParseXML<T>(this string @this) where T : class
        {

            var xml = File.ReadAllText(@this);
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }

            //var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            //return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        //public static T ParseJSON<T>(this string @this) where T : class
        //{
        //    return JSON.Deserialize<T>(@this.Trim());
        //}
    }
}
