using System;

namespace CodingGym07.TicTacToe
{
    public struct Board
    {
        public char[] position;

        public Board(char[] pos)
        {
            position = pos;
        }

        public void Display()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", position[0], position[1], position[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", position[3], position[4], position[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", position[6], position[7], position[8]);
            Console.WriteLine("     |     |      ");
        }
    }
}