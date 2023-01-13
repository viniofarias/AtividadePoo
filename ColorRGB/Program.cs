using RGB.Entities;

namespace RGB
{
    class Program
    {
        static void Main() 
        {
            Color w = Color.StrToColor("#2596BE");
            Console.WriteLine("R: " + w.Red);
            Console.WriteLine("G: " + w.Green);
            Console.WriteLine("B: " + w.Blue);
            Color x = new Color().ColorRed;
            Color y = new Color(2, 150, 190);
            string cor = Color.ConvertDecToHex(y);
            Console.WriteLine(cor);
            string teste = new Color().Darken("#2596BE",0.1);
            Console.WriteLine(teste);
        }
    }
}