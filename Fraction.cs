using System.Diagnostics.CodeAnalysis;

namespace FractionDemo
{
    /// <summary>
    /// Represents a fraction in simplist form, meaning:
    ///  - Denominator > 0
    ///  - Simplest form
    ///  - Zero is represented as 0/1
    /// </summary>
    struct Fraction : IComparable<Fraction>
    {
        public Fraction()
        {
            // Default constructor initializes to zero in standard form.
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            // Ensure Denominator > 0.
            if (denominator > 0)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            else if (denominator < 0)
            {
                Numerator = -numerator;
                Denominator = -denominator;
            }
            else
            {
                throw new DivideByZeroException();
            }

            // Ensure the fraction is in its simplest form.
            if (Numerator != 0)
            {
                // Ensure no common factors between Numerator and Denominator.
                int factor = GreatestCommonFactor(int.Abs(Numerator), Denominator);
                Numerator /= factor;
                Denominator /= factor;
            }
            else
            {
                // Ensure zero is represented as 0/1.
                Denominator = 1;
            }
        }

        public int Numerator
        {
            get;
        }

        public int Denominator
        {
            get;
        }

        public override string ToString() => (Denominator != 1) ?
            $"{Numerator}/{Denominator}" :
            Numerator.ToString();

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is Fraction && Equals((Fraction)obj);
        }

        public bool Equals(Fraction other)
        {
            return other.Numerator == Numerator && other.Denominator == Denominator;
        }

        public override int GetHashCode()
        {
            return (Numerator * 1000003) + Denominator;
        }

        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(
            a.Numerator * b.Numerator,
            a.Denominator * b.Denominator
            );

        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(
            a.Numerator * b.Denominator,
            a.Denominator * b.Numerator
            );

        public static Fraction operator +(Fraction a, Fraction b) => Add(
            a.Numerator, a.Denominator,
            b.Numerator, b.Denominator
            );

        public static Fraction operator -(Fraction a, Fraction b) => Add(
            a.Numerator, a.Denominator,
            -b.Numerator, b.Denominator
            );

        private static Fraction Add(int n1, int d1, int n2, int d2)
        {
            int d = LeastCommonMultiple(d1, d2);
            n1 *= d / d1;
            n2 *= d / d2;
            return new Fraction(n1 + n2, d);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !a.Equals(b);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }

        public int CompareTo(Fraction other)
        {
            int d = LeastCommonMultiple(Denominator, other.Denominator);
            int n1 = Numerator * d / Denominator;
            int n2 = other.Numerator * d / other.Denominator;
            return n1 - n2;
        }

        private static int LeastCommonMultiple(int a, int b)
        {
            int factor = GreatestCommonFactor(a, b);
            return (a / factor) * b;
        }

        private static int GreatestCommonFactor(int a, int b)
        {
            int result = 1;

            // Check if 2 is a common factor of a and b.
            while (((a | b) & 1) == 0)
            {
                a >>= 1;
                b >>= 1;
                result <<= 1;
            }

            // Check if odd numbers >= 3 are common factors.
            for (int factor = 3; factor * factor <= int.Min(a, b); factor += 2)
            {
                while (a % factor == 0 && b % factor == 0)
                {
                    a /= factor;
                    b /= factor;
                    result *= factor;
                }
            }

            // Is one number is a multiple of the other?
            int min = int.Min(a, b);
            int max = int.Max(a, b);
            if (max % min == 0)
            {
                result *= min;
            }

            return result;
        }
    }
}
