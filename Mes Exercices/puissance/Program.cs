namespace Puissance
{
    internal class Program
    {
        public static double Power(double baseNumber, int exponent)
        {
            if (exponent == 1)
            {
                return baseNumber;
            }
            return baseNumber * Power(baseNumber, exponent-1);

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Power(5,2));
        }
    }
}
