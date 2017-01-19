using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FractionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fractionTwo = new Fraction(2, 1);
            Fraction fractionZero = Fraction.Zero;
            Fraction fractionHalf = Fraction.Half;
            Console.WriteLine(fractionHalf.ToString());

            Fraction fraction = new Fraction(4,-2);
            fraction.SimplifyNaiveVersion();
            Console.WriteLine(fraction);

            Console.WriteLine(Fraction.Info());
            
            Console.ReadKey();
        }

            
    }
}
