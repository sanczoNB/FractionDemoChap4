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
            _numerator = numerator;
            _denominator = denominator;
        }

        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        public double ToDouble()
        {
            return _numerator/(double) _denominator;
        }

        public void SimplifyNaiveVersion()
        {
            var greatestCommonDivisor = GreatestCommonDivisorWithEuclideanAlgorithm();
            _numerator = _numerator/greatestCommonDivisor;
            _denominator = _denominator/greatestCommonDivisor;
            
            //sign
            if (_numerator * _denominator < 0)
            {
                _numerator = - Math.Abs(_numerator);
                _denominator = Math.Abs(_denominator);
            }
            else
            {
                _numerator = Math.Abs(_numerator);
                _denominator = Math.Abs(_denominator);
            }
        }

        public int GreatestCommonDivisorWithEuclideanAlgorithm()
        {
            int a = Math.Max(_denominator, _numerator);
            int b = Math.Min(_denominator, _numerator);
            do
            {
                var c = a%b;
                a = b;
                b = c;
            } while (b != 0);

            return a;
        }

        private int GreatestCommonDivisorNaiveVersion()
        {
            var greatestCommonDivisor = Math.Min(Math.Abs(_numerator), Math.Abs(_denominator));
            while ((_numerator % greatestCommonDivisor != 0) || (_denominator % greatestCommonDivisor != 0))
            {
                greatestCommonDivisor--;
            }
            return greatestCommonDivisor;
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
