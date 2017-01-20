using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FractionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = Fraction.Half;
            Fraction b = Fraction.Quater;

            Console.WriteLine(a+b);
            Console.WriteLine(a-b);
            Console.WriteLine(a*b);
            Console.WriteLine(a/b);
                       
            Console.ReadKey();
        }

            
    }
}
