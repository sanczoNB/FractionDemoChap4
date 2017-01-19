using System;

namespace FractionDemo
{
    public struct Fraction
    {

        private int _denominator;

        #region Property

        public int Numerator { get; set; }

        public int Denominator
        {
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator must not be equal zero");
                }
                _denominator = value;
            }
            get { return _denominator; }
        }

        #endregion

        public Fraction(int numerator, int denominator = 1) : this()
        {
         
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{_denominator}";
        }

        public double ToDouble()
        {
            return Numerator/(double) _denominator;
        }

        public void SimplifyNaiveVersion()
        {
            var greatestCommonDivisor = GreatestCommonDivisorWithEuclideanAlgorithm();
            Numerator = Numerator/greatestCommonDivisor;
            _denominator = _denominator/greatestCommonDivisor;
            
            //sign
            if (Numerator * _denominator < 0)
            {
                Numerator = - Math.Abs(Numerator);
                _denominator = Math.Abs(_denominator);
            }
            else
            {
                Numerator = Math.Abs(Numerator);
                _denominator = Math.Abs(_denominator);
            }
        }

        public int GreatestCommonDivisorWithEuclideanAlgorithm()
        {
            int a = Math.Max(_denominator, Numerator);
            int b = Math.Min(_denominator, Numerator);
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
            var greatestCommonDivisor = Math.Min(Math.Abs(Numerator), Math.Abs(_denominator));
            while ((Numerator % greatestCommonDivisor != 0) || (_denominator % greatestCommonDivisor != 0))
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
