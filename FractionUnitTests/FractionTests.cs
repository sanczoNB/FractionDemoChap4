using System;
using System.CodeDom;
using FluentAssertions;
using FractionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionUnitTests
{
    [TestClass]
    public class FractionTests
    {
        private readonly Random _random = new Random();

        private const int RepeatsNumber = 100;

        [TestMethod]
        public void ConstructorAndPropertyTest()
        {
            //arange
            int numerator = 1;
            int denominator = 2;

            //act
            Fraction f = new Fraction(numerator, denominator);
            
            //assert
            Assert.AreEqual(numerator, f.Numerator, "Niezgodność w liczniku");
            Assert.AreEqual(denominator, f.Denominator, "Niezgodność w mianowniku"); 
        }

        [TestMethod]
        public void PureConstructorTest()
        {
            //arange
            int denominator = 2;
            
            //act
            Fraction f = new Fraction(1, denominator);

            //Assert
            var po = new PrivateObject(f);

            int f_denominator = (int) po.GetField("_denominator");

            Assert.AreEqual(denominator, f_denominator);
        }

        [TestMethod]
        public void Constructor_throw_argument_exception_when_denominator_is_equal_zero_fluent_version()
        {
            Action act = () => new Fraction(1,0);

            act.ShouldThrow<ArgumentException>()
                .WithMessage("Denominator must not be equal zero");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_throw_argument_exception_when_denominator_is_eaqual_zero_bad_standard_version()
        {
            var f = new Fraction(8, 0);
        }

        [TestMethod]
        public void Test_of_static_field_half_fluent_version()
        {
            //arange
            var fH = Fraction.Half;

            //assert
            fH.Numerator.Should().Be(1);
            fH.Denominator.Should().Be(2);
        }

        [TestMethod]
        public void Test_of_static_field_half_standard_version()
        {
            //arange
            var fH = Fraction.Half;

            //assert
            Assert.AreEqual(1, fH.Numerator);
            Assert.AreEqual(2, fH.Denominator);
        }

        [TestMethod]
        public void TestMethodSimplify_fluent_version()
        {
            //arange
            var f = new Fraction(4, -2);

            //acta
            f.Simplify();

            //assert
            f.Numerator.Should().Be(-2);
            f.Denominator.Should().Be(1);
        }

        [TestMethod]
        public void TestMethodSimplify_standard_version()
        {
            //arange
            var f = new Fraction(4, -2);

            //acta
            f.Simplify();

            //assert
            Assert.AreEqual(-2, f.Numerator);
            Assert.AreEqual(1, f.Denominator);
        }

        [TestMethod]
        public void Operators_test_standard_version()
        {
            //assert
            var a = Fraction.Half;
            var b = Fraction.Quater;

            //act and assert
            Assert.AreEqual(new Fraction(3,4), a + b, "Niepowodzenie przy dodawaniu" );
            Assert.AreEqual(Fraction.Quater, a - b, "Niepowodzenie przy odejmowaniu");
            Assert.AreEqual(new Fraction(1, 8), a * b, "Niepowodzenie przy mnożeniu");
            Assert.AreEqual(new Fraction(2), a / b, "Niepowodzenie przy dzieleniu");
        }

        [TestMethod]
        public void Operators_test_fluent_version()
        {
            //assert
            var a = Fraction.Half;
            var b = Fraction.Quater;

            //act
            var addResult = a + b;
            var subtractionResult = a - b;
            var multiplicationResult = a * b;
            var divisionResult = a / b;

            //assert
            addResult.Should().Be(new Fraction(3, 4));
            subtractionResult.Should().Be(Fraction.Quater);
            multiplicationResult.Should().Be(new Fraction(1, 8));
            divisionResult.Should().Be(new Fraction(2));
        }

        [TestMethod]
        public void SortTest_impotent_way()
        {
            //arange
            var tab = new Fraction[100];
            for (var i = 0; i < tab.Length; i++)
            {
                tab[i] = new Fraction(DrawInteger(), DrawIntegerDiffrentThanZero());
            }

            //act
            Array.Sort(tab);

            //assert
            bool tabIsSortAscending = true;

            for (int i = 0; i < tab.Length - 1; i++)
            {
                if (tab[i] >= tab[i + 1])
                {
                    tabIsSortAscending = false;
                }
            }
            Assert.IsTrue(tabIsSortAscending);
        }

        [TestMethod]
        public void SortTest_my_way()
        {
            //arange
            var tab = new Fraction[100];
            for (var i = 0; i < tab.Length; i++)
            {
                tab[i] = new Fraction(DrawInteger(), DrawIntegerDiffrentThanZero());
            }

            //act
            Array.Sort(tab);

            //assert
            bool tabIsSortAscending = true;

            var index = 0;
            while (index < tab.Length -1 && tabIsSortAscending)
            {
                tabIsSortAscending = tab[index] <= tab[index + 1];
                index++;
            }
            
            Assert.IsTrue(tabIsSortAscending);
        }

        [TestMethod]
        public void CoonvertToDouble()
        {
            for (var i = 0; i < RepeatsNumber; i++)
            {
                //arange
                var numerator = DrawInteger();
                var denominator = DrawIntegerDiffrentThanZero();
                var fraction = new Fraction(numerator, denominator);

                //act
                var d = (double) fraction;

                //assert
                Assert.AreEqual(numerator / (double)denominator, d);
                /* Trochę bez sensu test, powtórzenie logiki testowanego modułu
                */
            }
        }

        [TestMethod]
        public void ConvertToFractionFromIntTest()
        {
            for (var i = 0; i < RepeatsNumber; i++)
            {
                //arange
                var numerator = DrawInteger();

                //act
                Fraction f = numerator;

                //assert
                f.Numerator.Should().Be(numerator);
                f.Denominator.Should().Be(1);
            }
        }

        [TestMethod]
        public void Simplify_Test()
        {
            //asert
            var fraction = new Fraction(0,-5);

            //act
            fraction.Simplify();

            //assert
            fraction.Numerator.Should().Be(0);
            fraction.Denominator.Should().Be(1);
        }

        [TestMethod]
        public void Simplify_random_fraction_test()
        {
            for (var i = 0; i < RepeatsNumber; i++)
            {
                //arange
                var f = new Fraction(DrawInteger(), DrawIntegerDiffrentThanZero());

                Fraction copy = f; // clone

                //act
                f.Simplify();

                //assert
                f.Denominator.Should().BeGreaterThan(0);
                Assert.AreEqual(copy.ToDouble(), f.ToDouble());
            }
        }

        [TestMethod]
        public void OperatorTest()
        {
            //ograniczenie maksymalniej wartości
            int limit = (int) (Math.Sqrt(int.MaxValue/2) - 1);

            //dopuszczalna różnica w wyniku
            const double precision = 1E-10;

            for (int i = 0; i < RepeatsNumber; i++)
            {
                Fraction a = new Fraction(DrawInteger(limit), DrawIntegerDiffrentThanZero(limit));
                
                Fraction b = new Fraction(DrawInteger(limit), DrawIntegerDiffrentThanZero(limit));

                double suma = (a + b).ToDouble();
                double subtraction = (a - b).ToDouble();
                double multiplication = (a*b).ToDouble();
                double divided = (a/b).ToDouble();

                //assert
                Assert.AreEqual(a.ToDouble() + b.ToDouble(), suma, precision, "Niepowodzenie przy dodawaniu");
                Assert.AreEqual(a.ToDouble() - b.ToDouble(), subtraction, precision, "Niepowodzenie przy odejmowaniu");
                Assert.AreEqual(a.ToDouble() * b.ToDouble(), multiplication, precision, "Niepowodzenie przy mnożeniu");
                Assert.AreEqual(a.ToDouble() / b.ToDouble(), divided, precision, "Niepowdzenie przy mnożeniu");
            }
        }

        #region private Methods

        private int DrawInteger(int? maxAbsolutionValue = null)
        {
            if (!maxAbsolutionValue.HasValue)
            {
                return _random.Next(int.MinValue, int.MaxValue);
            }
            else
            {
                maxAbsolutionValue = Math.Abs(maxAbsolutionValue.Value);
                return _random.Next(-maxAbsolutionValue.Value, maxAbsolutionValue.Value);
            }
        }

        private int DrawIntegerDiffrentThanZero(int? maxAbsolutionValue = null)
        {
            int value;
            do
            {
                value = DrawInteger(maxAbsolutionValue);
            } while (value == 0);
            return value;
        }

        #endregion

    }
}
