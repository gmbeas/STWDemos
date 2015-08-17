using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JsonGPS.Content
{
    public static class Helper
    {
        private static Bitmap ChangeColor(Bitmap scrBitmap, Color scrcolor)
        {
            var newColor = scrcolor;
            var newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (var i = 0; i < scrBitmap.Width; i++)
            {
                for (var j = 0; j < scrBitmap.Height; j++)
                {
                    var actualColor = scrBitmap.GetPixel(i, j);
                    newBitmap.SetPixel(i, j, actualColor.A > 150 ? newColor : actualColor);
                }
            }
            return newBitmap;
        }

        private static Bitmap ResizeBitmap(Bitmap scrBitmap, int alto, int ancho)
        {
            return new Bitmap(scrBitmap, new Size(alto, ancho));
        }


        public static Stream ModificaImagen(string tipo, string color, string alto, string ancho)
        {
            Bitmap bmp = null;
            var imagen = "";
            switch (int.Parse(tipo))
            {
                case 1:
                    imagen = @"c:\IconosGps\gps_1.png";
                    break;
                case 2:
                    imagen = @"c:\IconosGps\gps_2.png";
                    break;
                case 3:
                    imagen = @"c:\IconosGps\gps_auto1.png";
                    break;
                case 4:
                    imagen = @"c:\IconosGps\gps_camion1.png";
                    break;
                case 5:
                    imagen = @"c:\IconosGps\gps_stop.png";
                    break;
                case 6:
                    imagen = @"c:\IconosGps\gps_sinsenal1.png";
                    break;
                case 7:
                    imagen = @"c:\IconosGps\gps_sinsenal2.png";
                    break;
            }
           

            bmp = (Bitmap) Image.FromFile(imagen);
            bmp = ChangeColor(bmp, Colores.GetColor(int.Parse(color)));
            bmp = ResizeBitmap(bmp, int.Parse(alto), int.Parse(ancho));

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            return ms;
        }

        public static string GetColor(Color srColor)
        {
            return "#" + srColor.R.ToString("X2") + srColor.G.ToString("X2") + srColor.B.ToString("X2");
        }

        #region Extras
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            return (from object row in table.Rows select CreateItemFromRow<T>((DataRow)row, properties)).ToList();
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            var item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(DayOfWeek))
                {
                    var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    var nomType = property.PropertyType.Name;
                    var valItem = row[property.Name].ToString();
                    if (nomType.Equals("String"))
                        property.SetValue(item, row[property.Name].ToString().Trim(), null);
                    else if (nomType.Equals("Int32"))
                        property.SetValue(item, valItem == "" ? 0 : int.Parse(row[property.Name].ToString().Trim()), null);
                    else if (nomType.Equals("Double"))
                        property.SetValue(item, valItem == "" ? 0.0 : double.Parse(row[property.Name].ToString().Trim()), null);
                    else if (nomType.Equals("DateTime"))
                        property.SetValue(item, valItem == "" ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(row[property.Name].ToString().Trim()), null);
                }
            }
            return item;
        }
        #endregion
    }
}
