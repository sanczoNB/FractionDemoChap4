using System;

namespace FractionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction[] tab = new Fraction[10];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = new Fraction(1, i + 1);
            }

            Console.WriteLine("Przed sortowaniem: ");
            foreach (var f in tab)
            {
                Console.WriteLine(f + " = " + f.ToDouble());
            }

            try
            {
                Array.Sort(tab);
            }
            catch (Exception exc)
            {

                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exc.Message);
                Console.ForegroundColor = currentColor;
            }

            Console.WriteLine("\nPo sortowaniu: ");
            foreach (var f in tab)
            {
                Console.WriteLine("{0} = {1}", f, f.ToDouble());
            }
            Console.ReadKey();
        }

            
    }
}
