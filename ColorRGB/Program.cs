using RGB.Entities;

namespace RGB
{
    class Program
    {
        static void Main() 
        {
            object x = new Color().ColorBlue;
            string teste = new Color().Darken("#2596BE",0.1);
            Console.WriteLine(teste);
        }
    }
}