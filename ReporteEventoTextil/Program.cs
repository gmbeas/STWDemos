using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace ReporteEventoTextil
{
    class Program
    {
        static void Main(string[] args)
        {
            new Aspose.Cells.License().SetLicense(License.LStream);
            var eventoID = new List<int> {100};

            foreach (var x in eventoID)
            {
                var ds = DBGeneral.GetDatosEvento(x);
                var info = (from DataRow dr in ds.Tables[0].Rows
                            select new DatosUsuario
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString()
                            }).ToList();


                foreach (var t in info)
                {
                    var dsx = DBGeneral.WPL_PromocionesMkt("MLLIS", "1", "6", "", "", "0", "", t.Nombre, t.Email,
                        t.Telefono, "", "", "0");
                }



                //Instantiate a new Workbook
                Workbook wb = new Workbook();

                //Get the first (default) worksheet
                Worksheet _worksheet = wb.Worksheets[0];
                _worksheet.Cells[0, 0].Value = "Nº";
                _worksheet.Cells[0, 1].Value = "Nombre";
                _worksheet.Cells[0, 2].Value = "Email";
                _worksheet.Cells[0, 3].Value = "Telefono";

                var cont = 1;

                foreach (var t in info)
                {
                    _worksheet.Cells[cont, 0].Value = cont;
                    _worksheet.Cells[cont, 1].Value = t.Nombre;
                    _worksheet.Cells[cont, 2].Value = t.Email;
                    _worksheet.Cells[cont, 3].Value = t.Telefono;

                    cont++;
                }
                _worksheet.AutoFitColumns();
                var tipoarchivo = "";
                if (x == 50)
                {
                    tipoarchivo = "Listado_Textil_al_";
                }
                else if (x == 60)
                {
                    tipoarchivo = "Listado_DiaMadres_al_";
                }
                else if (x == 70)
                {
                    tipoarchivo = "Listado_Toldos_al_";
                }
                else if (x == 100)
                {
                    tipoarchivo = "Listado_CopaAmerica_al_";
                }
                var archivo = tipoarchivo + DateTime.Now.ToShortDateString().Replace("/", "-");
                wb.Save(@"E:\Evento Textil\" + archivo + ".xlsx", SaveFormat.Xlsx);


                try
                {
                    var mail = new MailMessage();
                    //var smtpServer = new SmtpClient("pod51010.outlook.com");
                    var smtpServer = new SmtpClient("smtp.office365.com");

                    mail.From = new MailAddress("Steward Cash&Carry <cg@steward.cl>");

                    if (x == 50)
                    {
                        // mail.To.Add(cliente.Email);
                        mail.Bcc.Add("gmartinez@steward.cl");
                        mail.Bcc.Add("gpainen@steward.cl");
                        mail.Bcc.Add("aedery@gmail.com");
                        mail.Bcc.Add("rrojas@steward.cl");
                        mail.Bcc.Add("ventas.textil@steward.cl");
                        mail.Bcc.Add("jafigueroa@steward.cl");
                        mail.Subject = "Listado Registro Liquidación Textil";
                    }
                    else if(x == 60)
                    {
                        // mail.To.Add(cliente.Email);
                        mail.Bcc.Add("gmartinez@steward.cl");
                        mail.Bcc.Add("rrojas@steward.cl ");
                        mail.Bcc.Add("aedery@gmail.com");
                        mail.Bcc.Add("paola@steward.cl");
                        mail.Subject = "Listado Registro Dia de la Madre";
                    }
                    else if (x == 70)
                    {
                        // mail.To.Add(cliente.Email);
                        mail.Bcc.Add("gmartinez@steward.cl");
                        mail.Bcc.Add("rrojas@steward.cl ");
                        mail.Bcc.Add("aedery@gmail.com");
                        mail.Bcc.Add("paola@steward.cl");
                        mail.Subject = "Listado Registro Toldos";
                    }
                    else if (x == 100)
                    {
                        // mail.To.Add(cliente.Email);
                        mail.Bcc.Add("gmartinez@steward.cl");
                        mail.Bcc.Add("rrojas@steward.cl ");
                        mail.Bcc.Add("aedery@gmail.com");
                        mail.Bcc.Add("paola@steward.cl");
                        mail.Subject = "Listado Copa America";
                    }
                  



                   

                    mail.IsBodyHtml = true;
                    var htmlBody = new StringBuilder();


                    htmlBody.Append("Estimados " +
                                    ", adjunto listado al " + DateTime.Now.ToShortDateString());

                    htmlBody.Append("<br/><b>Steward Cash&Carry<b>");

                    mail.Body = htmlBody.ToString();

                    var attachment = new Attachment(@"E:\Evento Textil\" + archivo + ".xlsx");
                    mail.Attachments.Add(attachment);
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


        public class DatosUsuario
        {
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
        }
    }
}
