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

        public void Simplify()
        {
            var greatestCommonDivisor = GreatestCommonDivisorWithEuclideanAlgorithm(Numerator, _denominator);
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

        #region operators
        public static Fraction operator +(Fraction one, Fraction two)
        {
            one.Simplify();
            two.Simplify();

            var leastCommonMultiple = LeastCommonMultiple(one.Denominator, two.Denominator);

            var multiplyOne = leastCommonMultiple / one.Denominator;
            var multiplyTwo = leastCommonMultiple / two.Denominator;

            one.Numerator = one.Numerator * multiplyOne;
            one.Denominator = one.Denominator * multiplyOne;

            two.Numerator = two.Numerator * multiplyTwo;
            two.Denominator = two.Denominator * multiplyTwo;

            var result = new Fraction()
            {
                Numerator = one.Numerator + two.Numerator,
                Denominator = one.Denominator
            };

            result.Simplify();

            return result;
        }

        public static Fraction operator -(Fraction minuend, Fraction subtrahend)
        {
            var result = new Fraction()
            {
                Numerator = minuend.Numerator * subtrahend.Denominator - subtrahend.Numerator * minuend.Denominator,
                Denominator = minuend.Denominator * subtrahend.Denominator
            };
            result.Simplify();
            return result;
        }

        public static Fraction operator *(Fraction factor1, Fraction factor2)
        {
            var result = new Fraction()
            {
                Numerator = factor1.Numerator * factor2.Numerator,
                Denominator = factor1.Denominator * factor2.Denominator
            };
            result.Simplify();
            return result;
        }

        public static Fraction operator /(Fraction dividend, Fraction divisior)
        {
            var result = new Fraction()
            {
                Numerator = dividend.Numerator * divisior.Denominator,
                Denominator = dividend.Denominator * divisior.Numerator
            };
            result.Simplify();
            return result;
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.ToDouble() == f1.ToDouble();
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        

        #endregion



        public static int LeastCommonMultiple(int n1, int n2)
        {
            int leastCommonMultiple = 1;
            int greatestCommonDivisor;

            do
            {
                greatestCommonDivisor = GreatestCommonDivisorWithEuclideanAlgorithm(n1, n2);
                n1 = n1/greatestCommonDivisor;
                n2 = n2/greatestCommonDivisor;
                leastCommonMultiple *= greatestCommonDivisor;
            } while (greatestCommonDivisor != 1);

            leastCommonMultiple *= n1;
            leastCommonMultiple *= n2;

            if (true)
            {
                
            }

            return leastCommonMultiple;
        }

        private static int GreatestCommonDivisorWithEuclideanAlgorithm(int number1, int number2)
        {
            int a = Math.Max(number1, number2);
            int b = Math.Min(number1, number2);
            do
            {
                var c = a % b;
                a = b;
                b = c;
            } while (b != 0);

            return a;
        }

        private static int GreatestCommonDivisorNaiveVersion(int number1, int number2)
        {
            var greatestCommonDivisor = Math.Min(Math.Abs(number1), Math.Abs(number2));
            while ((number1 % greatestCommonDivisor != 0) || (number2 % greatestCommonDivisor != 0))
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
