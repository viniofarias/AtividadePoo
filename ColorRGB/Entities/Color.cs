using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGB.Entities
{
    public class Color
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }
        public int Luminosity { get; private set; }
        public static Color Black
        {
            get { return new Color(0, 0, 0); }
        }
        public static Color White
        {
            get { return new Color(255, 255, 255); }
        }
        public static Color ColorRed
        {
            get { return new Color(255, 0, 0); }
        }
        public static Color ColorGreen
        {
            get { return new Color(0, 255, 0); }
        }
        public static Color ColorBlue
        {
            get { return new Color(0, 0, 255); }
        }

        /*public Color(int identic)
        {
            Red = identic;
            Green = identic;
            Blue = identic;
        }*/
        public Color(Color color)
        {
            Red = color.Red;
            Green = color.Green;
            Blue = color.Blue;
        }
        public Color() 
        {
        }
        public Color(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public void SetLuminosity()
        {
            double lum = (Red * 0.3 + Green * 0.59 + Blue * 0.11);
            Luminosity = (int)Math.Ceiling(lum);
        }
        public static int SetLuminosity(int red, int green, int blue)
        {
            double lum = (red * 0.3 + green * 0.59 + blue * 0.11);
            return (int)Math.Ceiling(lum);
        }
        public static bool CompareColor(Color x, Color y)
        {
            //if (x.Red == y.Red && x.Green == y.Green && x.Blue == y.Blue) return true;
            //else return false;


            return (x.Red == y.Red && x.Green == y.Green && x.Blue == y.Blue);
        }
        public static string EquivalentGray(string color)
        {
            int redDecimal = Convert.ToInt32(color.Substring(1, 2), 16);
            int greenDecimal = Convert.ToInt32(color.Substring(3, 2), 16);
            int blueDecimal = Convert.ToInt32(color.Substring(5, 2), 16);
            int equivalent = SetLuminosity(redDecimal, greenDecimal, blueDecimal);

            return ConvertDecToHex(new Color(equivalent, equivalent, equivalent));

            /*string redToGray = Convert.ToString(equivalent, 16);
            string greenToGray = Convert.ToString(equivalent, 16);
            string blueToGray = Convert.ToString(equivalent, 16);
            return "#" + redToGray + greenToGray + blueToGray;*/
    
        }
        public static Color EquivalentGray(Color color)
        {
            string colorHex = ConvertDecToHex(color);
            int redDecimal = Convert.ToInt32(colorHex.Substring(1, 2), 16);
            int greenDecimal = Convert.ToInt32(colorHex.Substring(3, 2), 16);
            int blueDecimal = Convert.ToInt32(colorHex.Substring(5, 2), 16);
            int equivalent = SetLuminosity(redDecimal, greenDecimal, blueDecimal);

            return new Color(equivalent, equivalent, equivalent);
        }
        public static string ConvertDecToHex(Color color)
        {
            string redToHex = (color.Red <= 9) ? "0" + Convert.ToString(color.Red, 16) : Convert.ToString(color.Red, 16);
            string greenToHex = (color.Green <= 9) ? "0" + Convert.ToString(color.Green, 16) : Convert.ToString(color.Green, 16);
            string blueToHex = (color.Blue <= 9) ? "0" + Convert.ToString(color.Blue, 16) : Convert.ToString(color.Blue, 16);

            return "#" + redToHex.ToUpper() + greenToHex.ToUpper() + blueToHex.ToUpper();
        }
        public string Lighten(double p)
        {

            this.Red += (int)Math.Ceiling(this.Red * p);
            this.Green += (int)Math.Ceiling(this.Green * p);
            this.Blue += (int)Math.Ceiling(this.Blue * p);

            return ConvertDecToHex(new Color(this));
        }
        public string Darken(double p)
        {
            this.Red -= (int) Math.Ceiling(this.Red * p);
            this.Green -= (int) Math.Ceiling(this.Green * p);
            this.Blue -= (int)Math.Ceiling(this.Blue * p);
            return ConvertDecToHex(new Color(this));
        }
        public static Color StrToColor(string color)
        {
            int redDecimal = Convert.ToInt32(color.Substring(1, 2), 16);
            int greenDecimal = Convert.ToInt32(color.Substring(3, 2), 16);
            int blueDecimal = Convert.ToInt32(color.Substring(5, 2), 16);
            return new Color(redDecimal, greenDecimal, blueDecimal);
        }


    }
}
