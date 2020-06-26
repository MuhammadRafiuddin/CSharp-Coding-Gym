using System;

namespace CodingGym03.HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create words list
            string[] wordsList = { "tree", "basket", "chair", "paper", "computer", "mahirkoding" };
            // Randomly pick one word
            Random random = new Random();
            int indexPos = random.Next(0, wordsList.Length);
            string misteryWord = wordsList[indexPos];

            // Define a variable to end the game
            const int lives = 7;
            int remainingLives = lives;
            bool gameOver = false;

            // Declare an array to store incorrect guesses
            char[] incorrectGuesses = new char[lives];
            // Declare an array to store correct guesses
            char[] correctGuesses = new char[misteryWord.Length];

            // Assign each correctGuesses array element with underscore character (_)
            for (int i = 0; i < misteryWord.Length; i++)
            {
                correctGuesses[i] += '_';
            }

            string word;

            ConsoleColor prevColor = Console.ForegroundColor;

            while (!gameOver)
            {
                Console.ForegroundColor = prevColor;
                // Join each correctGuesses array element as a word
                word = String.Join("", correctGuesses);

                if (misteryWord == word)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulation! You guessed the mistery word correctly!");
                    Console.ForegroundColor = prevColor;
                    gameOver = true;                    
                }

                Console.WriteLine("\nMistery word: {0}", String.Join(" ", correctGuesses));
                Console.WriteLine("\nincorect guesses list: [{0}]", String.Join(" ", incorrectGuesses));
                Console.WriteLine("Remaining lives: {0}", remainingLives);
                
                Console.Write("\n\nType 'quit' or guess a character: ");
                string guess = Console.ReadLine().ToLower();
                Console.Clear();                

                // Check whether the incorrectly guessed word has been guessed before or not
                bool wasIncorrectlyGuessed = false;
                foreach (char c in incorrectGuesses)
                {
                    if (guess == c.ToString())
                    {
                        wasIncorrectlyGuessed = true;
                        break;
                    }
                }

                if (guess == "quit")
                {                    
                    Console.ForegroundColor = prevColor;
                    Console.WriteLine("Thanks for playing Hangman!");
                    gameOver = true;
                }
                else if (misteryWord.Contains(guess) && !wasIncorrectlyGuessed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You guessed correctly!");
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (misteryWord[i] == guess[0])
                        {
                            correctGuesses[i] = guess[0];
                        }
                    }
                }
                else if (wasIncorrectlyGuessed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You've already guessed \"{0}\"! Please try another character.", guess);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong guess! You lost 1 live.");
                    if (remainingLives > 0)
                    {
                        incorrectGuesses[lives - remainingLives] = guess[0];
                        remainingLives -= 1;
                    }
                    else
                    {
                        Console.WriteLine("You have lost all your lives!");
                        gameOver = true;
                    }
                }           
            }
        }
    }
}
