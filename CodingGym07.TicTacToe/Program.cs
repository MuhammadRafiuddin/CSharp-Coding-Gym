using System;

namespace CodingGym07.TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameplay tictactoe = new Gameplay();
            tictactoe.Execute();
            Console.ReadKey();
        }
    }
}
