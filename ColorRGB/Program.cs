using RGB.Entities;

namespace RGB
{
    class Program
    {
        static void Main() 
        {
            Color c1 = new Color(33, 135, 171);

            var color = c1.Lighten(0.1);
            Console.WriteLine(color);


            //Color w = Color.StrToColor("#2596BE");
            //Console.WriteLine("R: " + w.Red);
            //Console.WriteLine("G: " + w.Green);
            //Console.WriteLine("B: " + w.Blue);
            //Color x = Color.ColorRed;
            //Color y = new Color(2, 150, 190);
            //string cor = Color.ConvertDecToHex(y);
            //Console.WriteLine(cor);
            //string teste = new Color().Darken("#2596BE",0.1);
            //Console.WriteLine(teste);
        }
    }
}