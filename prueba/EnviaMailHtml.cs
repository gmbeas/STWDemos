using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ExpertPdf.HtmlToPdf;

namespace prueba
{
    public class EnviaMailHtml
    {
        #region EnviaMailPdf
        public string EnviaMailPdf(NotaPedidoDetalle info, EDatoCliente cliente, string region, string ciudad,
            string ddespacho, string nventa, string flete)
        {
            var textoACambiar = cliente.Nombre.ToLower();
            var nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(textoACambiar);
            //var nombre = new CultureInfo("en-US", false).TextInfo.ToTitleCase(textoACambiar);

            var folderHtml = Properties.Settings.Default.htmlbak;
            var folderPdf = Properties.Settings.Default.pdfbak;

            if (region != "0")
            {
                var xx = ddespacho.Split(',');
                var nomregion = xx[xx.Count() - 1];
                var nomciudad = xx[xx.Count() - 2];
                ddespacho = ddespacho.Replace(nomregion, "").Replace(nomciudad, "").Replace(",,", "");
            }


            var strFile = File.ReadAllText(folderHtml + @"\master.html");

            strFile = strFile.Replace("{direccion_despacho}", ddespacho);
            strFile = strFile.Replace("{fecha}", DateTime.Now.ToShortDateString());
            strFile = strFile.Replace("{guia}", nventa);
            strFile = strFile.Replace("{email}", cliente.Email);
            strFile = strFile.Replace("{nombre}", nombre);

            var detalle = new StringBuilder();
            var valor1 = 0.0;

            foreach (var t in info.Item)
            {
                detalle.Append("<tr>");
                detalle.Append("<td style='text-align:center;'>" + t.Sku + "</td>");
                detalle.Append("<td style='text-align:center;'>" + t.Descripcion + "</td>");
                detalle.Append("<td style='text-align:center;'>" + t.CantidadLisa + "</td>");


                var ivan = Math.Round(Convert.ToDouble(t.Valor) / Convert.ToDouble("1,19"));
                var neto = Math.Round(Convert.ToDouble(t.Valor) - ivan);
                detalle.Append("<td style='text-align:right;'>$" + Convert.ToDouble(ivan).ToString("N0") + "</td>");

                detalle.Append("<td style='text-align:right;'>$" + ((ivan) * Convert.ToDouble(t.CantidadLisa)).ToString("N0") + "</td>");
                detalle.Append("</tr>");

                valor1 = valor1 + Convert.ToInt32((ivan) * Convert.ToDouble(t.CantidadLisa));
            }
            strFile = strFile.Replace("{detalle}", detalle.ToString());
            if (flete == "")
                flete = "0";
            strFile = strFile.Replace("{subtotal}", "$" + valor1.ToString("N0"));
            strFile = strFile.Replace("{despacho}", "$" + Convert.ToDouble(flete).ToString("N0"));

            var ivax = valor1 + Convert.ToInt32(flete);
            var iva = Convert.ToDouble(ivax) * 0.19;
            var ivmostrar = Math.Round(iva, 0);

            strFile = strFile.Replace("{iva}", "$" + Convert.ToDouble(ivmostrar).ToString("N0"));
            strFile = strFile.Replace("{total}", "$" + Convert.ToDouble((ivmostrar + valor1) + Convert.ToDouble(flete)).ToString("N0"));
            var total = String.Format("{0:n0}", Convert.ToDouble((ivmostrar + valor1 + Convert.ToDouble(flete)).ToString()));



            File.WriteAllText(folderHtml + @"\" + nventa + ".html", strFile);

            string outFile = null;
            string url = folderHtml + @"\" + nventa + ".html";

            var pdfConverter = new PdfConverter();
            pdfConverter.LicenseKey = "ACsyIDggZmYxYzdjNjFfOTgwN180YWQzX2JlODlfODVkNzJkZGZiOTVhIDguMCAxOS4wMS4yMDM4";
            pdfConverter.PdfDocumentOptions.EmbedFonts = false;
            pdfConverter.PdfDocumentOptions.ShowFooter = false;
            pdfConverter.PdfDocumentOptions.ShowHeader = false;
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;

            outFile = Path.Combine(folderPdf + @"\", "Comprobante_" + nventa + ".pdf");
            try
            {
                pdfConverter.SavePdfFromUrlToFile(url, outFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

            var envio = false;
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("pod51010.outlook.com");

                mail.From = new MailAddress("Steward Cash&Carry <cg@steward.cl>");
                // mail.To.Add(cliente.Email);
                mail.Bcc.Add("aedery@gmail.com");
                mail.Bcc.Add("gmartinez@steward.cl");
                mail.Subject = "Recibo de compra online nº" + nventa + ".";

                mail.IsBodyHtml = true;
                var htmlBody = new StringBuilder();


                htmlBody.Append("Estimado(a) " + nombre + ", su pedido ha sido recibido y está siendo procesado para la entrega.<br/>");
                htmlBody.Append("Adjunto encontrará el recibo con el detalle de su compra.<br/><br/>");
                htmlBody.Append("¡Gracias por ayudarnos en el camino hacia una gastronomía de excelencia!<br/>");
                htmlBody.Append("No dude en enviar sus comentarios acerca de su experiencia de compra a info@steward.cl<br/><br/>");
                htmlBody.Append("Un saludo afectuoso,<br/><br/>");
                htmlBody.Append("Atentamente,<br/><br/>");
                htmlBody.Append("<b>Equipo de atención online<b><br/>");
                htmlBody.Append("<b>Steward Cash&Carry<b>");

                mail.Body = htmlBody.ToString();

                var attachment = new Attachment(folderPdf + @"\" + "Comprobante_" + nventa + ".pdf");
                mail.Attachments.Add(attachment);
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("cg@steward.cl", "vespucio.2015");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                envio = true;
            }
            catch (Exception ex)
            {
                envio = false;
            }
            return total;
        }
        #endregion

        #region EnviaMail
        public string EnviaMail(NotaPedidoDetalle info, EDatoCliente cliente, string region, string ciudad, string ddespacho, string nventa, string flete)
        {


            var horario = "";
            if ((region == "13" && ciudad == "113") || (region == "0" && ciudad == "0"))
                horario = "dentro de las próximas 72 horas";
            else
                horario = "entre 4 y 15 días hábiles";

            var pathmail = Properties.Settings.Default.pathEmail;
            var streamReader = new StreamReader(pathmail);
            var text = streamReader.ReadToEnd();
            streamReader.Close();
            text = text.Replace("{0}", nventa);
            text = text.Replace("{1}", DateTime.Now.ToString("dd MMMM yyyy"));
            text = text.Replace("{2}", cliente.Nombre);

            var stringinfo = new StringBuilder();

            var valor1 = 0;
            foreach (var t in info.Item)
            {
                stringinfo.Append("<tr>");
                stringinfo.Append("<td width='80'>" + t.Sku + "</td>");
                stringinfo.Append("<td class='auto-style3'>" + t.Descripcion + "</td> ");
                stringinfo.Append("<td class='auto-style4' style='text-align: center'>" + t.CantidadWeb + "</td> ");

                var ivan = Math.Round(Convert.ToDouble(t.Valor) / Convert.ToDouble("1,19"));

                stringinfo.Append("<td width='100'>$" + String.Format("{0:n0}", ((ivan) * Convert.ToDouble(t.CantidadLisa))) + "</td> ");
                stringinfo.Append("</tr>");
                valor1 = valor1 + Convert.ToInt32((ivan) * Convert.ToDouble(t.CantidadLisa));
            }
            if (flete == "")
                flete = "0";
            text = text.Replace("{5}", stringinfo.ToString());
            text = text.Replace("{3}", ddespacho);
            text = text.Replace("{4}", horario);
            text = text.Replace("{6}", String.Format("{0:n0}", Convert.ToDouble(valor1)));
            text = text.Replace("{7}", String.Format("{0:n0}", Convert.ToDouble(flete)));

            var ivax = valor1 + Convert.ToInt32(flete);
            var iva = Convert.ToDouble(ivax) * 0.19;
            var ivmostrar = Math.Round(iva, 0);
            text = text.Replace("{8}", String.Format("{0:n0}", Convert.ToDouble(ivmostrar)));
            text = text.Replace("{9}", String.Format("{0:n0}", Convert.ToDouble((ivmostrar + valor1 + Convert.ToDouble(flete)).ToString())));
            var total = String.Format("{0:n0}", Convert.ToDouble((ivmostrar + valor1 + Convert.ToDouble(flete)).ToString()));
            var envio = false;
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("pod51010.outlook.com");

                mail.From = new MailAddress("Steward <cg@steward.cl>");
                mail.To.Add("gmbeas@gmail.com");
                mail.Subject = "Comprobante Compra Web Steward";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = text;

                mail.Body = htmlBody;

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("cg@steward.cl", "vespucio.2012");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                envio = true;
            }
            catch (Exception ex)
            {
                envio = false;
            }
            return total;
        }
        #endregion

        public void _EnviaCorreos(string titulo, string cuerpo, ArrayList Emails)
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("pod51010.outlook.com");

                mail.From = new MailAddress("Steward <cg@steward.cl>");
                foreach (var email in Emails)
                {
                    mail.To.Add(email.ToString());
                }

                mail.Subject = titulo;

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = cuerpo;

                mail.Body = htmlBody;

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("cg@steward.cl", "vespucio.2015");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void _EnviaCorreo(string titulo, string cuerpo, string mailDestino)
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("pod51010.outlook.com");

                mail.From = new MailAddress("Steward <cg@steward.cl>");
                mail.To.Add(mailDestino);
                mail.Subject = titulo;

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = cuerpo;

                mail.Body = htmlBody;

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("cg@steward.cl", "vespucio.2015");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
