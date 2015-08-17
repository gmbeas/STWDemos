using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Chilkat;
using ConsoleApplication2.Content;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace ConsoleApplication2
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var obj0049 = new ws0049.Pws0049();
            obj0049.Timeout = 40000;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"F:\demo_niveles.xml");
            var xmlDocto = xmlDoc.OuterXml;

            var resultado = obj0049.Execute(xmlDocto);
            obj0049.Dispose();

            //Get the Search Address
            String address = @"http://www.sismologia.cl/links/ultimos_sismos.html";
            //Create an Instance of the WebClient Class
            WebClient client = new WebClient();
            //Download the Source
            String reply = client.DownloadString(address);
            //Will remove everything up to the table, Assuming there is only one Table on the Page
            reply = reply.Remove(0, reply.IndexOf("<table"));
            //Remove everything after </table>
            reply = reply.Remove(reply.IndexOf("</table>") + 8);


            var lic = "HtmlToXml87654321_063CDFBFmRR5";

            HtmlToXml pp = new HtmlToXml();
            pp.UnlockComponent(lic);
            pp.Html = reply;
            var aaa = pp.ToXml();

            var catalog1 = aaa.ParseXML<root>();


            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reply);




            string json = JsonConvert.SerializeXmlNode(doc);
            
            foreach (XmlNode node in doc.GetElementsByTagName("tr"))
            {
                int counter = 0;
                foreach (XmlNode childNode in node.ChildNodes)
                {

                    if (counter > 0)
                    {
                        var aa = childNode.InnerText.ToLower();
                    }
                    

                    counter++;
                }
            }
           

        }


        

        public static XmlDocument FromHtml(TextReader reader)
        {

            // setup SgmlReader
            Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
            sgmlReader.DocType = "HTML";
            sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
            sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
            sgmlReader.InputStream = reader;

            // create document
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.XmlResolver = null;
            doc.Load(sgmlReader);
            return doc;
        }
       

    }
}
