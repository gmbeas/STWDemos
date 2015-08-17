using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;
using CambiaDeptoMarisol.Content;
using License = Aspose.Cells.License;

namespace CambiaDeptoMarisol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var archivo = textBox2.Text;
            new License().SetLicense(LicenseHelper.License.LStream);
            var loadOptions = new LoadOptions(LoadFormat.Excel97To2003);
            var workbook = new Workbook(archivo, loadOptions);

            //Obtaining the reference of the newly added worksheet by passing its sheet index
            var worksheet = workbook.Worksheets[0];

            //var dataArray = worksheet.Cells.ExportArray(17, 1, worksheet.Cells.MaxDataRow - 16, 14);
            var dataArray = worksheet.Cells.ExportArray(2, 0, worksheet.Cells.MaxDataRow, 5);

            var info = new List<Modelo>();
            var nn = dataArray.GetLength(0);

            for (var i = 0; i < dataArray.GetLength(0) -1 ; i++)
            {

                info.Add(new Modelo
                {
                    Concepto = dataArray[i, 0].ToString(),
                    DeptoActual = dataArray[i, 1].ToString(),
                    Doc = dataArray[i, 2].ToString(),
                    NDoc = dataArray[i, 3].ToString(),
                    NCod = dataArray[i, 4].ToString()
                });

            }


            foreach (var t in info)
            {
                var xx = DbGeneral.CambiaEstado(t.NCod, t.NDoc, t.Doc);
            }

            MessageBox.Show("Proceso finalizado");
        }

        public class Modelo
        {
            public string Concepto { get; set; }
            public string DeptoActual { get; set; }
            public string Doc { get; set; }
            public string NDoc { get; set; }
            public string NCod { get; set; }
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
    }
}
