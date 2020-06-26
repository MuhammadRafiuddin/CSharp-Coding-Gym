using System;

namespace CodingGym04.NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Random random = new Random();
            int randNumber = random.Next(0,100);
            bool guessed = false;
            int guesses = 0;

            ConsoleColor prevColor = Console.ForegroundColor;

            while (!guessed)
            {
                Console.Write("Guess a number: ");
                int ans = Convert.ToInt32(Console.ReadLine());

                guesses += 1;
                Console.Clear();
                if (ans == randNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Congratulation! YOU WON!");
                    Console.ForegroundColor = prevColor;
                    Console.WriteLine("You need to guess {0} time(s).", guesses);
                    guessed = true;
                }
                else if (ans > randNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your guess was too low: Guess a number higher than {0}", guesses);
                    Console.ForegroundColor = prevColor;
                }
                else if (ans < randNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your guess was too high: Guess a number lower than {0}", guesses);
                    Console.ForegroundColor = prevColor;
                }
            }

            Console.Write("Game over... ");
            Console.ReadKey();
        }
    }
}
