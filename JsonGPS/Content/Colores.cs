using System.Drawing;

namespace JsonGPS.Content
{
    public static class Colores
    {
        public static Color GetColor(int scrColor)
        {
            var newColor = new Color();
            switch (scrColor)
            {
                case 1:
                    newColor = Color.Red;
                    break;
                case 2:
                    newColor = Color.Black;
                    break;
                case 3:
                    newColor = Color.Blue;
                    break;
                case 4:
                    newColor = Color.Yellow;
                    break;
                case 5:
                    newColor = Color.Green;
                    break;
                case 6:
                    newColor = Color.White;
                    break;
                case 7:
                    newColor = Color.Silver;
                    break;
                case 8:
                    newColor = Color.Orange;
                    break;
                case 9:
                    newColor = Color.BlueViolet;
                    break;
                case 10:
                    newColor = Color.DarkBlue;
                    break;
                case 11:
                    newColor = Color.DodgerBlue;
                    break;
                case 12:
                    newColor = Color.DarkRed;
                    break;
                case 13:
                    newColor = Color.MediumVioletRed;
                    break;
                case 14:
                    newColor = Color.PaleVioletRed;
                    break;
                case 15:
                    newColor = Color.YellowGreen;
                    break;
                case 16:
                    newColor = Color.Wheat;
                    break;
                case 17:
                    newColor = Color.Chocolate;
                    break;
                case 18:
                    newColor = Color.Lime;
                    break;
                case 19:
                    newColor = Color.Purple;
                    break;
                case 20:
                    newColor = Color.Teal;
                    break;
                case 21:
                    newColor = Color.SlateGray;
                    break;
                case 22:
                    newColor = Color.SeaGreen;
                    break;
                case 23:
                    newColor = Color.Sienna;
                    break;
                case 24:
                    newColor = Color.MidnightBlue;
                    break;
                case 25:
                    newColor = Color.Navy;
                    break;
                case 26:
                    newColor = Color.Olive;
                    break;
                case 27:
                    newColor = Color.Peru;
                    break;
                case 28:
                    newColor = Color.Pink;
                    break;
                case 29:
                    newColor = Color.DeepPink;
                    break;
                case 30:
                    newColor = Color.DeepSkyBlue;
                    break;
            }

            return newColor;
        }

    }
}
