using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Aspose.Cells;
using Concilia_POS.Content;

namespace Concilia_POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fechapicker.Value = DateTime.Now.AddDays(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Archivo ERCEL|*.xls";
            var nombreCompleto = String.Empty;
            var nombre = "";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                nombreCompleto = openFileDialog1.FileName;
                nombre = openFileDialog1.SafeFileName;
               
            }
            textBox1.Text = nombre;
            textBox2.Text = nombreCompleto;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var archivo = textBox2.Text;
            new License().SetLicense(LicenseHelper.License.LStream);
            var loadOptions = new LoadOptions(LoadFormat.Excel97To2003);
            var workbook = new Workbook(archivo, loadOptions);
            
            //Obtaining the reference of the newly added worksheet by passing its sheet index
            var worksheet = workbook.Worksheets[0];

            var dataArray = worksheet.Cells.ExportArray(17, 1, worksheet.Cells.MaxDataRow -16, 14);

            

            var info = new List<Modelo>();

            for (var i = 0; i < dataArray.GetLength(0); i++)
            {
                info.Add(new Modelo
                {
                    FechaVenta = dataArray[i, 0].ToString(),
                    Local = dataArray[i, 1].ToString(),
                    IdentifiacionLocal = dataArray[i, 2].ToString(),
                    TipoMovimiento = dataArray[i, 3].ToString(),
                    TipoTarjeta = dataArray[i, 4].ToString(),
                    Identificador = dataArray[i, 5].ToString(),
                    TipoCuota = dataArray[i, 6].ToString(),
                    MontoAfecto = dataArray[i, 7].ToString(),
                    MontoExento = dataArray[i, 8].ToString(),
                    CodigoAutorizacion = dataArray[i, 9].ToString(),
                    NCuotas = dataArray[i, 10].ToString(),
                    MontoCuota = dataArray[i, 11].ToString(),
                    PrimerAbono = dataArray[i, 12].ToString(),
                    NBoleta = dataArray[i, 13].ToString()
                });
               
            }




            var fecha = fechapicker.Value.ToString("dd/MM/yyyy");

            var fachaant = Convert.ToDateTime(fecha).AddDays(-1).ToString("dd/MM/yyyy");
            var fechapost = Convert.ToDateTime(fecha).AddDays(4).ToString("dd/MM/yyyy");


            var pp = DbGeneral.ConsultaConcilia(fachaant, fechapost);
            var aax = pp.Tables[0].ToList<ConciliaModel>();

            var infonew = new List<ConciliaModel>();
            foreach (var t in aax)
            {
                var iiu = DbGeneral.ConsultaCodAut(t.NroDoc);
                var nro1 = "";
                var nro2 = "";

                if (iiu.Tables.Count > 0)
                {
                    var dr = iiu.Tables[0].Rows[0];
                    nro1 = dr["NroOperacion"].ToString();
                    nro2 = dr["NroAutorizacion"].ToString();
                }
                
                infonew.Add(new ConciliaModel
                {
                    Fecha = t.Fecha,
                    Caja = t.Caja,
                    TipoDoc = t.TipoDoc,
                    NroDoc = t.NroDoc,
                    MedioPago = t.MedioPago,
                    Nulo = t.Nulo,
                    NroDocPago = t.NroDocPago,
                    Monto =  t.Monto,
                    CodCliente = t.CodCliente,
                    MontoDoc = t.MontoDoc,
                    NroOperacion = nro1,
                    NroAutorizacion = nro2

                });
            }



            Workbook wb = new Workbook();

            //Note when you create a new workbook, a default worksheet
            //"Sheet1" is added (by default) to the workbook.
            //Access the first worksheet "Sheet1" in the book.
            Worksheet sheet = wb.Worksheets[0];

            sheet.Cells[0, 0].PutValue("Fecha Venta");
            sheet.Cells[0, 1].PutValue("Local");
            sheet.Cells[0, 2].PutValue("Identificación Local");
            sheet.Cells[0, 3].PutValue("Tipo Movimiento");
            sheet.Cells[0, 4].PutValue("Tipo Tarjeta");
            sheet.Cells[0, 5].PutValue("Identificador");
            sheet.Cells[0, 6].PutValue("Tipo Cuota");
            sheet.Cells[0, 7].PutValue("Monto Afecto");
            sheet.Cells[0, 8].PutValue("Monto Exento");
            sheet.Cells[0, 9].PutValue("Código Autorización");
            sheet.Cells[0, 10].PutValue("N° Cuotas");
            sheet.Cells[0, 11].PutValue("Monto Cuota");
            sheet.Cells[0, 12].PutValue("Primer Abono");
            sheet.Cells[0, 13].PutValue("N° Boleta");
            sheet.Cells[0, 14].PutValue("Coincide");
            sheet.Cells[0, 15].PutValue("Folio");
            sheet.Cells[0, 16].PutValue("CAJA");



            var fila = 1;
            foreach (var t in info)
            {
                var estado = false;
                var folio = "";
                var caja = "";
                foreach (var x in infonew)
                {
                    var compara = x.NroAutorizacion == "" ? 0 : int.Parse(x.NroAutorizacion);

                    if (int.Parse(t.CodigoAutorizacion) == compara)
                    {
                        estado = true;
                        folio = x.NroDoc;
                        caja = x.Caja;
                    }
                }

                if (estado == false)
                {
                    var dsx = DbGeneral.ConsultaLisaDocu(t.Identificador, int.Parse(t.MontoAfecto));
                    if (dsx.Tables[0].Rows.Count > 0)
                    {
                        var dr = dsx.Tables[0].Rows[0];
                        estado = true;
                        folio = dr["CzPlaFol"].ToString();
                        caja = dr["CzPlaPtaPf"].ToString();
                    }
                    else
                    {
                        var dsx2 = DbGeneral.ConsultaLisaDocuSegundo(int.Parse(t.CodigoAutorizacion),
                            int.Parse(t.MontoAfecto));
                        if (dsx2.Tables[0].Rows.Count > 0)
                        {
                            var dr = dsx2.Tables[0].Rows[0];
                            estado = true;
                            folio = dr["CzPlaFol"].ToString();
                            caja = dr["CzPlaPtaPf"].ToString();
                        }
                        else
                        {
                            var dsx3 = DbGeneral.ConsultaLisaDocuTercero(int.Parse(t.CodigoAutorizacion), int.Parse(t.MontoAfecto));
                            if (dsx3.Tables[0].Rows.Count > 0)
                            {
                                var dr = dsx3.Tables[0].Rows[0];
                                estado = true;
                                folio = dr["teodifol"].ToString();
                                //caja = dr["CzPlaPtaPf"].ToString();
                            }
                        }

                    }
                }

                sheet.Cells[fila, 0].PutValue(t.FechaVenta);
                sheet.Cells[fila, 1].PutValue(t.Local);
                sheet.Cells[fila, 2].PutValue(t.IdentifiacionLocal);
                sheet.Cells[fila, 3].PutValue(t.TipoMovimiento);
                sheet.Cells[fila, 4].PutValue(t.TipoTarjeta);
                sheet.Cells[fila, 5].PutValue(t.Identificador);
                sheet.Cells[fila, 6].PutValue(t.TipoCuota);
                sheet.Cells[fila, 7].PutValue(t.MontoAfecto);
                sheet.Cells[fila, 8].PutValue(t.MontoExento);
                sheet.Cells[fila, 9].PutValue(t.CodigoAutorizacion);
                sheet.Cells[fila, 10].PutValue(t.NCuotas);
                sheet.Cells[fila, 11].PutValue(t.MontoCuota);
                sheet.Cells[fila, 12].PutValue(t.PrimerAbono);
                sheet.Cells[fila, 13].PutValue(t.NBoleta);
                sheet.Cells[fila, 14].PutValue(estado);
                sheet.Cells[fila, 15].PutValue(folio);
                sheet.Cells[fila, 16].PutValue(caja);

                fila++;
            }

            //Save the Excel file.
            

            //MessageBox.Show(@"Proceso terminado", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            string dummyFileName = "Concilia Docu TBK " + DateTime.Now.ToString("dd-MM-yyyy") + ".xls";

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;
            sf.Filter = @"Archivo ERCEL|*.xls";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                string savePath = Path.GetDirectoryName(sf.FileName);

                wb.Save(sf.FileName , SaveFormat.Excel97To2003);
                MessageBox.Show(@"Proceso terminado con exito");
                // Do whatever
            }

        }


        public class ConciliaModel
        {
            public string Fecha { get; set; }
            public string Caja { get; set; }
            public string TipoDoc { get; set; }
            public string NroDoc { get; set; }
            public string MedioPago { get; set; }
            public string Nulo { get; set; }
            public string NroDocPago { get; set; }
            public string Monto { get; set; }
            public string CodCliente { get; set; }
            public string MontoDoc { get; set; }
            public string NroOperacion { get; set; }
            public string NroAutorizacion { get; set; }
        }

        public class Modelo
        {
            public string FechaVenta { get; set; }
            public string Local { get; set; }
            public string IdentifiacionLocal { get; set; }
            public string TipoMovimiento { get; set; }
            public string TipoTarjeta { get; set; }
            public string Identificador { get; set; }
            public string TipoCuota { get; set; }
            public string MontoAfecto { get; set; }
            public string MontoExento { get; set; }
            public string CodigoAutorizacion { get; set; }
            public string NCuotas { get; set; }
            public string MontoCuota { get; set; }
            public string PrimerAbono { get; set; }
            public string NBoleta { get; set; }
            
        }
    }
}
