using System;

namespace CodingGym02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool isValidChoice = false;
            string operation = default;

            while(!isValidChoice)
            {
                // Display choices
                Console.WriteLine("Please select one of the operation below: ");
                Console.WriteLine("\t1 - Addition");
                Console.WriteLine("\t2 - Substraction");
                Console.WriteLine("\t3 - Multiplication");
                Console.WriteLine("\t4 - Division");
                
                Console.Write("Your choice (1/2/3/4): ");

                // Match the user input with switch statement
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        operation = "addition";
                        isValidChoice = true;
                        break;
                    case "2":
                        operation = "substraction";
                        isValidChoice = true;
                        break;
                    case "3":
                        operation = "multiplication";
                        isValidChoice = true;
                        break;
                    case "4":
                        operation = "division";
                        isValidChoice = true;
                        break;
                    default:
                        Console.WriteLine("Your choice is not valid!!\n");
                        break;
                }
            }

            Console.WriteLine("You selected {0} operation\n", operation);

            if (operation == "substraction" || operation == "division")
            {
                Console.WriteLine("=== Caution! ===");
                Console.WriteLine("You selected {0} operation", operation);
                Console.WriteLine("Please notice that the operation result will be affected by the order of the number\n");                
            }

            bool isValidNum1 = false, isValidNum2 = false;
            double num1 = default, num2 = default;

            do
            {
                Console.Write("Enter first number: ");
                isValidNum1 = Double.TryParse(Console.ReadLine(), out num1);
                if (!isValidNum1) Console.WriteLine("You entered an invalid number!\n");
            }
            while(!isValidNum1);

            do
            {
                Console.Write("Enter second number: ");
                isValidNum2 = Double.TryParse(Console.ReadLine(), out num2);
                if (!isValidNum2) Console.WriteLine("You entered an invalid number!\n");
            }
            while(!isValidNum2);

            double result = default;

            // Challenge: Change this if-else statement with a switch statement
            if (operation == "addition")
            {
                result = num1 + num2;
                Console.WriteLine("{0} + {1} = {2}", num1, num2, result);
            }
            else if (operation == "substraction")
            {
                result = num1 - num2;
                Console.WriteLine("{0} - {1} = {2}", num1, num2, result);
            }
            else if (operation == "multiplication")
            {
                result = num1 * num2;
                Console.WriteLine("{0} * {1} = {2}", num1, num2, result);
            }
            else if (operation == "division")
            {
                if (num2 != 0)
                {
                    result = (double)num1 / (double)num2;
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, result);
                }
            }

            Console.ReadLine();
        }
    }
}
