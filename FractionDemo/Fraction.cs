using System;

namespace FractionDemo
{
    public struct Fraction
    {
        private int _numerator;

        private int _denominator;

        public Fraction(int numerator, int denominator = 1)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator must not be equal zero");
            }
            _denominator = denominator;
            _numerator = numerator;
        }

        public static string Info()
        {
            return "Structer, Fraction by Piotr Piosik";
        }

        public static readonly Fraction Zero = new Fraction(0);
        public static readonly Fraction One = new Fraction(1);
        public static readonly Fraction Half = new Fraction(1,2);
        public static readonly Fraction Quater = new Fraction(1,4);
    }
}
