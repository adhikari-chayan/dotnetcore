using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            var firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            var secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select one: add, subtract, multiply");
            var operation = Console.ReadLine();

            switch(operation)
            {
                case "add":
                    Add(firstNumber, secondNumber);
                    break;

                case "subtract":
                    Subtract(firstNumber, secondNumber);
                    break;

                case "multiply":
                    Multiply(firstNumber, secondNumber);

            }
        }
    }
}
