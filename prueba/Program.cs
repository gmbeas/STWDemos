using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using prueba.Properties;
using prueba.ws_lisa;
using prueba.ws_wop;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {

            

            //string path = @"C:\Users\Gonzalo Martinez\Desktop\aa\29-01-14\112705_D.xml";


            //var datos = path.ParseXML<NotaPedidoDetalle>();


            
                        const string directorio = @"C:\inetpub\wwwroot\cgi-bin\log\";
            const string directorioXml = @"D:\xmlArchivo\";
            var watcher = new FileSystemWatcher
            {
                Path = directorio,
                Filter = "*.txt",
                IncludeSubdirectories = false
            };

            var result = watcher.WaitForChanged(WatcherChangeTypes.All);

            if (result.ChangeType.ToString() == "Created")
            {
                Thread.Sleep(2000);
                var nombreArchivo = result.Name.ToString();
                var fArchivo = nombreArchivo.Split('_');
                if (fArchivo[0].Equals("DatosParaCheckMac")) //CONFIRMO QUE SEA ARCHIVO FINAL DE PAGO WEBPAY
                {
                    if (File.ReadAllText(directorio + nombreArchivo).Contains("TBK_MONTO=")) //VERIFICO QUE TENGA EL TAG DE PAGO
                    {
                        var archivoConfirma = directorio + string.Format("ResultadoCheckMac_{0}", fArchivo[1]); //NOMBRE DE ARCHIVO VALIDADOR
                        if (File.Exists(archivoConfirma)) //PREGUNTO SI EXISTE ARCHIVO VALIDADOR
                        {
                            if (File.ReadAllText(archivoConfirma).Contains("CORRECTO")) //VALIDO QUE EL ARCHIVO VALIDADOR ESTE OKEY
                            {
                                var xmlCompraOriginal = directorioXml + fArchivo[1].Replace(".txt",".xml");
                                var xmlCompraDetalle = directorioXml + fArchivo[1].Replace(".txt", "_D.xml");

                                if (File.Exists(xmlCompraOriginal)) //PREGUNTO SI XML GENERADO POR LA COMPRA EXISTE
                                {
                                    if (File.Exists(xmlCompraDetalle)) //PREGUNTO SI XML DETALLE GENERADO POR LA COMPRA POSTERIOR AL PAGO WEBAPY
                                    {

                                        var objReader = new StreamReader(directorio + nombreArchivo);
                                        var readLine = objReader.ReadLine();
                                        if (readLine != null)
                                        {
                                            var post = readLine.Trim();
                                            objReader.Close();
                                            var cadena = post.Trim();
                                            var parametros = Regex.Split(cadena, "&");
                                            Globales.TBK_CODIGO_AUTORIZACION = parametros[4];
                                            Globales.TBK_CODIGO_AUTORIZACION = Globales.TBK_CODIGO_AUTORIZACION.Substring(Globales.TBK_CODIGO_AUTORIZACION.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_FECHA_CONTABLE = parametros[6];
                                            Globales.TBK_FECHA_CONTABLE = Globales.TBK_FECHA_CONTABLE.Substring(Globales.TBK_FECHA_CONTABLE.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_FECHA_TRANSACCION = parametros[7];
                                            Globales.TBK_FECHA_TRANSACCION = Globales.TBK_FECHA_TRANSACCION.Substring(Globales.TBK_FECHA_TRANSACCION.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_FINAL_NUMERO_TARJETA = parametros[5];
                                            Globales.TBK_FINAL_NUMERO_TARJETA = Globales.TBK_FINAL_NUMERO_TARJETA.Substring(Globales.TBK_FINAL_NUMERO_TARJETA.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_HORA_TRANSACCION = parametros[8];
                                            Globales.TBK_HORA_TRANSACCION = Globales.TBK_HORA_TRANSACCION.Substring(Globales.TBK_HORA_TRANSACCION.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_ID_TRANSACCION = parametros[10];
                                            Globales.TBK_ID_TRANSACCION = Globales.TBK_ID_TRANSACCION.Substring(Globales.TBK_ID_TRANSACCION.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_NUMERO_CUOTAS = parametros[12];
                                            Globales.TBK_NUMERO_CUOTAS = Globales.TBK_NUMERO_CUOTAS.Substring(Globales.TBK_NUMERO_CUOTAS.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_TIPO_PAGO = parametros[11];
                                            Globales.TBK_TIPO_PAGO = Globales.TBK_TIPO_PAGO.Substring(Globales.TBK_TIPO_PAGO.IndexOf("=", StringComparison.Ordinal) + 1);

                                            Globales.TBK_MONTO = parametros[3];
                                            Globales.TBK_MONTO = Globales.TBK_MONTO.Substring(Globales.TBK_MONTO.IndexOf("=", StringComparison.Ordinal) + 1);
                                            Globales.TBK_MONTO = Globales.TBK_MONTO.Substring(0, Globales.TBK_MONTO.Length - 2); //saca los dos 0 del final que son representación de los decimales.
                                        }

                                        var envianoenvia = true;
                                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                                        ns.Add("", "");
                                        var xmlOrignal = xmlCompraOriginal.ParseXML<NotaPedido>();
                                        var xmlDetalle = xmlCompraDetalle.ParseXML<NotaPedidoDetalle>();
                                       

                                        var xsSubmit = new XmlSerializer(typeof(NotaPedido));
                                        var subReq = xmlOrignal;

                                        var sww = new StringWriter();
                                        var writer = XmlWriter.Create(sww);
                                        xsSubmit.Serialize(writer, subReq, ns);
                                        var xml = sww.ToString();
                                        xml = ParseHelpers.RemoveTypeTagFromXml(xml);
                                        var xdoc = new XmlDocument();
                                        xdoc.LoadXml(xml);
                                        var xmldoc = xdoc.ToString();

                                        var objLisa = new WS_Lisa();
                                        var objWop = new Pos();



                                        var resultado = xdoc.ParseXmlRespuestaLisa<RespuestaLisa>();
                                        if (resultado.IndError.Equals("N")) //PROSIGO
                                        {
                                            var res = objLisa.ConsultaPos("BOD", "STE", "", "", "1", Int32.Parse(resultado.Folio), "", ""); //cambio bodega
                                            if (res.Tables.Count == 0)
                                            {

                                                var emails = new ArrayList();
                                                emails.Add("gmartinez@steward.cl");
                                                var emailcuerpoMailInterno = new StringBuilder();
                                                emailcuerpoMailInterno.Append("CAMBIO BODEGA");
                                                new EnviaMailHtml()._EnviaCorreos("ERROR CAMBIO BODEGA", emailcuerpoMailInterno.ToString(), emails);
                                               envianoenvia = false;
                                            }
                                            ActualizaWop(Int32.Parse(resultado.Folio), Convert.ToInt32(fArchivo[1].Replace(".txt","")));
                                          
                                        }
                                        else //HAY ERRORES
                                        {
                                            envianoenvia = false;
                                            var emails = new ArrayList();
                                            emails.Add("gmartinez@steward.cl");
                                            var emailcuerpoMailInterno = new StringBuilder();
                                            emailcuerpoMailInterno.Append(resultado.Error[0].ErrorDescripcion);
                                            new EnviaMailHtml()._EnviaCorreos("ERROR COMPRA LISA", emailcuerpoMailInterno.ToString(), emails);

                                        }




                                        if (envianoenvia == true)
                                        {
                                            //PROCESO ENVIA EMAIL
                                            var infocliente = TraeUsuarioWeb(xmlOrignal.Auxiliar);
                                            //var bruto = new EnviaMailHtml().EnviaMail(infodetalle, infocliente, regcabe, ciucabe, ddescabe, folio, flete);
                                            var bruto = new EnviaMailHtml().EnviaMailPdf(xmlDetalle, infocliente, xmlDetalle.Cabecera[0].Region, xmlDetalle.Cabecera[0].Ciudad, xmlDetalle.Cabecera[0].DireccionDespacho, resultado.Folio, xmlOrignal.Articulo[0].Flete);

                                            var emails = new ArrayList();
                                            emails.Add("gmartinez@steward.cl");
                                            emails.Add("ventas@steward.cl");
                                            emails.Add("ventas2@steward.cl");
                                            emails.Add("lmiranda@steward.cl");
                                            emails.Add("jdiaz@steward.cl");
                                            emails.Add("fmuguruza@steward.cl");
                                            emails.Add("jsantana@steward.cl");
                                            emails.Add("aedery@gmail.com");
                                            emails.Add("saguilera@steward.cl");
                                            emails.Add("aflores@steward.cl");
                                            //COBRANZA
                                            emails.Add("esepulveda@steward.cl");
                                            emails.Add("emeza@steward.cl");
                                            emails.Add("jaguilera@steward.cl");
                                            emails.Add("pquintana@steward.cl");

                                            var emailcuerpoMailInterno = new StringBuilder();
                                            emailcuerpoMailInterno.Append("Estimados, Los Datos de la Compra Web son los Siguientes: ");
                                            emailcuerpoMailInterno.Append("<br/>"); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Información del cliente");
                                            emailcuerpoMailInterno.Append("<br/>"); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Rut:" + xmlOrignal.Auxiliar); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Nombre: " + infocliente.Nombre); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Email: " + infocliente.Email); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Dirección: " + xmlDetalle.Cabecera[0].DireccionDespacho); emailcuerpoMailInterno.Append("<br/>"); emailcuerpoMailInterno.Append("<br/>");

                                            emailcuerpoMailInterno.Append("Información de Compra"); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Fecha de la compra: " + DateTime.Now.ToShortDateString()); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Nro Nota: " + resultado.Folio); 
                                            emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Monto Pagado: " + double.Parse(Globales.TBK_MONTO).ToString("#,##0")); 
                                            emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Codigo Autorizacion: " + Globales.TBK_CODIGO_AUTORIZACION); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Digitos Tarjeta: " + Globales.TBK_FINAL_NUMERO_TARJETA); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Tipo Compra: " + Globales.TBK_TIPO_PAGO); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Nro Cuotas: " + Globales.TBK_NUMERO_CUOTAS); emailcuerpoMailInterno.Append("<br/>"); emailcuerpoMailInterno.Append("<br/>");
                                            emailcuerpoMailInterno.Append("Este Mail ha sido generado de forma automática. Favor no responder.");

                                            new EnviaMailHtml()._EnviaCorreos("Compra Web Steward Transbank", emailcuerpoMailInterno.ToString(), emails);

                                            var folderXml = Settings.Default.pathXml;
                                            var folderXmlBak = Settings.Default.pathXml_bak;
                                          
                                            //MUEVE ARCHIVOS PROCESADOS
                                            File.Move(xmlCompraDetalle, xmlCompraDetalle.Replace(folderXml, folderXmlBak));
                                            File.Move(xmlCompraOriginal, xmlCompraOriginal.Replace(folderXml, folderXmlBak));
                                        }




                                    }
                                    else //EN EL CASO DE QUE NO EXISTA EL DETALLE, LO GENERO MANUALMENTE
                                    {
                                        var xmlOrignal = xmlCompraOriginal.ParseXML<NotaPedido>();


                                        var rut = Convert.ToInt32(xmlOrignal.Auxiliar);


                                        var xx = rut.ParseXmlClienteLisa<ClienteLisa>();

                                        var detDire = "";
                                        var detReg = "";
                                        var detCiu = "";


                                        foreach (var t in xx.Direccion)
                                        {
                                            if (t.Codigo.Equals("888"))
                                            {
                                                detDire = "La orden será entregada en Steward Cash&Carry (Américo Vespucio Norte 0655 ,Huechuraba, Santiago)";
                                                detReg = t.Codreg;
                                                detCiu = t.Codciu;
                                            }
                                            else
                                            {
                                                if (t.Codigo.Equals(xmlOrignal.Dir_Despacho.Trim()))
                                                {

                                                    detDire = "La orden será despachada desde Steward Cash&amp;Carry a la dirección " + t.Descripcion + ", " + t.Nomcom + ", " + t.Nomciu;
                                                    detReg = t.Codreg;
                                                    detCiu = t.Codciu;
                                                }
                                            }
                                           
                                        }




                                        var xsSubmit = new XmlSerializer(typeof(NotaPedidoDetalle));
                                        var subReq = new NotaPedidoDetalle
                                        {
                                            Cabecera = new[]
                                            {
                                                new Cabecera
                                                {
                                                    Region = detReg,
                                                    Ciudad = detCiu,
                                                    DireccionDespacho = detDire
                                                }
                                            },
                                            Item = (from t in xmlOrignal.Articulo
                                                let xxx = ParseHelpers.GetProducto(t.ArticuloCod)
                                                select new Item
                                                {
                                                    Sku = t.ArticuloCod,
                                                    Descripcion = xxx.Descripcion,
                                                    Um = "",
                                                    CantidadWeb = t.Umevta_Cant,
                                                    CantidadLisa = t.Umevta_Cant,
                                                    Valor = xxx.Valor,
                                                    ValorTotal = xxx.Valor,
                                                    CodPromo = ""
                                                }).ToArray()
                                        };



                                        var sww = new StringWriter();
                                        var writer = XmlWriter.Create(sww);
                                        xsSubmit.Serialize(writer, subReq);
                                        var xml = sww.ToString(); 

                                        var xdoc = new XmlDocument();
                                        xdoc.LoadXml(xml);
                                        xdoc.Save(xmlCompraDetalle); //guardo xml detalle
                                    }
                                }

                            }
                        }
                    }
                }
            }

        }

        private static void ActualizaWop(int folio, int codigonv)
        {
            var objWop = new Pos();
         
            const string _Bodega = "";
            const string _codpromo = "";
            var dsresultado = objWop.POS_ActualizaCabecera("S", "STE", _Bodega, "99", "FAAF", codigonv, DateTime.Now.ToShortDateString(), "WWW", "", "500", 4, 0, 0, 0, 0, 0, 0, folio, "", 0, 0, 1, _codpromo, 0, 0, 0, "", 0, 0, "");
        }


        private static EDatoCliente TraeUsuarioWeb(string rut)
        {
            var info = new EDatoCliente();
            var msg = "-N";
            var objWop = new Pos();
            var ds = objWop.WEB_Usuarios("FUS", rut, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            if (ds.Tables[0].Rows.Count > 0)
            {
                var dr = ds.Tables[0].Rows[0];
                info.Rut = dr["rut"].ToString();
                info.Email = dr["email"].ToString();
                info.Nombre = dr[4].ToString();
            }
            else
            {
                var rutInt = int.Parse(rut.Trim());
                var resultado = rutInt.ParseXmlClienteLisa<ClienteLisa>();
                if (resultado.Contacto[0].Correo != "")
                {
                    info.Rut = rut;
                    info.Email = resultado.Contacto[0].Correo;
                    info.Nombre = resultado.Datoscliente[0].Nombre;
                }
                else
                {
                    info.Rut = rut;
                    info.Email = "ventas@steward.cl";
                    info.Nombre = resultado.Datoscliente[0].Nombre;
                }

            }
            return info;
        }
    }

}
