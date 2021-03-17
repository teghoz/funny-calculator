using System;

namespace FunnyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Check out this funny calculator!");
            Console.WriteLine("Please Supply your funny string");
            var funnyString = Console.ReadLine();
            Calculator calculator = new Calculator();
            var result = calculator.Add(funnyString);
            if(result != null)
            Console.WriteLine($@"Your answer is: {result}");
            Console.ReadLine();
        }
    }
}
