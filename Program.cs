namespace FractionDemo
{
    static class Program
    {
        static void Test(int an, int ad, int bn, int bd)
        {
            var a = new Fraction(an, ad);
            var b = new Fraction(bn, bd);

            Console.WriteLine($"Testing {an}/{ad} and {bn}/{bd}:");
            Console.WriteLine($"  {a} * {b} => {a * b}");
            Console.WriteLine($"  {a} / {b} => {a / b}");
            Console.WriteLine($"  {a} + {b} => {a + b}");
            Console.WriteLine($"  {a} - {b} => {a - b}");
            Console.WriteLine($"  {a} == {b} => {a == b}");
            Console.WriteLine($"  {a} < {b} => {a < b}");
            Console.WriteLine();
        }

        static void Main()
        {
            Test(1, 2, 1, 2);
            Test(1, 2, 1, 3);
            Test(3, 1, 3, 8);
            Test(7, 16, 3, 8);
        }
    }
}
