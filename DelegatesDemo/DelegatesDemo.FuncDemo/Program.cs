﻿using System;

namespace DelegatesDemo.FuncDemo
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            var firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            var secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select Calculation  Operation: add, subtract, multiply, divide");
            var operation = Console.ReadLine();

            int result = CalculatorOperation(firstNumber, secondNumber, operation);

            Console.WriteLine($"Result = {result}");
        
            Console.ReadKey();
        }

        public static int CalculatorOperation(int firstNumber, int secondNumber, string operation)
        {
            Func<int, int, int> calculation
               = operation switch
               {
                   "add" => (x, y) => x + y,
                   "subtract" => (x, y) => x - y,
                   "multiply" => (x, y) => x * y,
                   _ => (x, y) => y != 0 ? x / y : 0
               };            

            return CalculateResult(firstNumber, secondNumber, calculation);
        }

        private static int CalculateResult(int firstNumber, int secondNumber, Func<int,int,int> calculation)
        {
            var result = calculation(firstNumber, secondNumber);
            return result;

        }
    }
}
