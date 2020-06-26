using System;
using System.Collections.Generic;

namespace CodingGym08.HangmanGame.List
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create words list
            string[] wordsList = { "tree", "basket", "chair", "paper", "computer", "mahirkoding" };
            // Pick word randomly
            Random random = new Random();
            int indexPos = random.Next(0, wordsList.Length);
            string misteryWord = wordsList[indexPos];

            // Define variables to end the game
            const int lives = 7;
            int remainingLives = lives;
            bool gameOver = false;

            // Declare a List of char to dynamically store incorrect guesses
            List<char> incorrectGuess = new List<char>();
            // Declare a List of char to dynamically store correct guesses
            List<char> correctGuess = new List<char>();

            // Assign each correctGuess List with underscore character (_)
            for (int i = 0; i < misteryWord.Length; i++)
            {
                correctGuess.Add('_');
            }

            string word;

            ConsoleColor prevColor = Console.ForegroundColor;

            while (!gameOver)
            {
                Console.ForegroundColor = prevColor;
                // Join each correctGuess List element into one word
                word = String.Join("", correctGuess);

                if (misteryWord == word)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulation! You guessed the mistery word correctly!");
                    Console.ForegroundColor = prevColor;
                    gameOver = true;                    
                }

                Console.WriteLine("\nMistery word: {0}", String.Join(" ", correctGuess));
                Console.WriteLine("\nincorect guesses list: [{0}]", String.Join(" ", incorrectGuess));
                Console.WriteLine("Remaining lives: {0}", remainingLives);
                
                Console.Write("\n\nType 'quit' or guess a character: ");
                string guess = Console.ReadLine().ToLower();
                Console.Clear();               

                if (guess == "quit")
                {                    
                    Console.ForegroundColor = prevColor;
                    Console.WriteLine("Thanks for playing Hangman!");
                    gameOver = true;
                }
                // Check whether the mistery word contains the guessed character or not
                // Check whether the incorrect guessed has been guessed before or not
                else if (misteryWord.Contains(guess) && !incorrectGuess.Contains(guess[0]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You guessed correctly!");
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (misteryWord[i] == guess[0])
                        {
                            correctGuess[i] = guess[0];
                        }
                    }
                }
                else if (incorrectGuess.Contains(guess[0]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You've already guessed \"{0}\"! Please try another character.", guess);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    remainingLives -= 1;

                    if (remainingLives <= 0)
                    {
                        Console.WriteLine("You have lost all your lives!");
                        gameOver = true;
                    }

                    Console.WriteLine("Wrong guess! You lost 1 live.");
                    incorrectGuess.Add(guess[0]);
                }           
            }

            Console.ReadLine();
        }
    }
}
