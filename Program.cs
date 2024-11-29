namespace FractionDemo
{
    static class Program
    {
        static void Test(Fraction a, Fraction b)
        {
            Console.WriteLine($"{a} * {b} => {a * b}");
            Console.WriteLine($"{a} / {b} => {a / b}");
            Console.WriteLine($"{a} + {b} => {a + b}");
            Console.WriteLine($"{a} - {b} => {a - b}");
            Console.WriteLine($"{a} == {b} => {a == b}");
            Console.WriteLine($"{a} < {b} => {a < b}");
            Console.WriteLine();
        }


        static void Main()
        {
            Test(new Fraction(1, 2), new Fraction(1, 2));
            Test(new Fraction(1, 2), new Fraction(1, 3));
            Test(new Fraction(3, 12), new Fraction(3, 8));
            Test(new Fraction(7, 16), new Fraction(3, 8));
        }
    }
}
