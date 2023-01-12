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
        public Color Black
        {
            get { return new Color(0, 0, 0); }
        }
        public Color White
        {
            get { return new Color(255, 255, 255); }
        }
        public Color ColorRed
        {
            get { return new Color(255, 0, 0); }
        }
        public Color ColorGreen
        {
            get { return new Color(0, 255, 0); }
        }
        public Color ColorBlue
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
            Luminosity = (int)lum;
        }
        public static int SetLuminosity(int red, int green, int blue)
        {
            double lum = (red * 0.3 + green * 0.59 + blue * 0.11);
            return (int)lum;
        }
        public static bool CompareColor(Color x, Color y)
        {
            if (x.Red == y.Red && x.Green == y.Green && x.Blue == y.Blue) return true;
            else return false;
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
        public static string ConvertDecToHex(Color color)
        {
            string redToHex = Convert.ToString(color.Red, 16);
            string greenToHex = Convert.ToString(color.Green, 16);
            string blueToHex = Convert.ToString(color.Blue, 16);
            return "#" + redToHex + greenToHex + blueToHex;
        }
        public string Lighten(string color, double p)
        {
            int redDecimal = Convert.ToInt32(color.Substring(1, 2), 16);
            int greenDecimal = Convert.ToInt32(color.Substring(3, 2), 16);
            int blueDecimal = Convert.ToInt32(color.Substring(5, 2), 16);
            redDecimal += (int)(redDecimal * p);
            greenDecimal += (int)(greenDecimal * p);
            blueDecimal += (int)(blueDecimal * p);
            return ConvertDecToHex(new Color(redDecimal, greenDecimal, blueDecimal));
        }
        public string Darken(string color, double p)
        {
            int redDecimal = Convert.ToInt32(color.Substring(1, 2), 16);
            int greenDecimal = Convert.ToInt32(color.Substring(3, 2), 16);
            int blueDecimal = Convert.ToInt32(color.Substring(5, 2), 16);
            redDecimal -= (int)(redDecimal * p);
            greenDecimal -= (int)(greenDecimal * p);
            blueDecimal -= (int)(blueDecimal * p);
            return ConvertDecToHex(new Color(redDecimal, greenDecimal, blueDecimal));
        }


    }
}
