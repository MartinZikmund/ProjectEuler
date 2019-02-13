using System;
using System.Numerics;

namespace Problem57
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;
            var currentFraction = new Fraction(1,1);
            for (int i = 0; i < 1000; i++)
            {
                currentFraction = Iterate(currentFraction);
                if (currentFraction.Numerator.ToString().Length > currentFraction.Denominator.ToString().Length)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        public static Fraction Iterate(Fraction previousFraction)
        {
            return 1 + (1 + previousFraction).Flip();
        }

        public class Fraction
        {
            public Fraction(BigInteger numerator, BigInteger denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }

            public BigInteger Numerator { get; }

            public BigInteger Denominator { get; }

            public Fraction Flip() => new Fraction(Denominator, Numerator);

            public static Fraction operator +(int number, Fraction fraction)
            {
                return fraction + new Fraction(number * fraction.Denominator, number * fraction.Denominator);
            }

            public static Fraction operator +(Fraction fraction1, Fraction fraction2)
            {
                if (fraction1.Denominator == fraction2.Denominator)
                {
                    return new Fraction(fraction1.Numerator + fraction2.Numerator, fraction1.Denominator);
                }
                throw new NotImplementedException("Can add only fractions with the same base in this problem");
            }
        }
    }
}
