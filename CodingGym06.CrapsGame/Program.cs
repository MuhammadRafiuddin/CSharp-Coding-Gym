using System;

namespace CodingGym06.CrapsGame
{
    class Program
    {
        public enum Status { Continue, Win, Lose }

        public enum DiceName
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            YoLeven = 11,
            BoxCars = 12
        }

        static void Main(string[] args)
        {
            Execute();

            Console.ReadLine();
        }

        static int RollTheDice()
        {
            Random randNumber = new Random();
            int dice1 = randNumber.Next(1,6);
            int dice2 = randNumber.Next(1,6);

            int sum = dice1 + dice2;

            Console.WriteLine("Rolling the dices {0} + {1} = {2}", dice1, dice2, sum);
            return sum;
        }

        static void Execute()
        {
            Status gameStatus = Status.Continue;
            int point = 0;
            int sumOfDiceNumber = RollTheDice();

            switch ((DiceName)sumOfDiceNumber)
            {
                case DiceName.Seven:
                case DiceName.YoLeven:
                    gameStatus = Status.Win;
                    break;
                case DiceName.SnakeEyes:
                case DiceName.Trey:
                case DiceName.BoxCars:
                    gameStatus = Status.Lose;
                    break;
                default:
                    gameStatus = Status.Continue;
                    point = sumOfDiceNumber;
                    Console.WriteLine($"Your point is {point}");
                    break;
            }

            while (gameStatus == Status.Continue)
            {
                sumOfDiceNumber = RollTheDice();

                if (sumOfDiceNumber == point)
                {
                    gameStatus = Status.Win;
                }
                else
                {
                    if (sumOfDiceNumber == (int) DiceName.Seven)
                    {
                        gameStatus = Status.Lose;
                    }
                }
            }

            if(gameStatus == Status.Win)
            {
                Console.WriteLine("YOU WON!");
            }
            else
            {
                Console.WriteLine("YOU LOST!");
            }
        }        
    }
}
