using System;

namespace CodingGym07.TicTacToe
{
    public class Gameplay
    {
        private int choice;
        private int turn = 1;
        private int flag;
        private Board board = new Board(new char[]{ '1', '2', '3', '4', '5', '6', '7', '8', '9' });

        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Pemain 1: X and Pemain 2: O");
                Console.WriteLine("\n");

                if (turn % 2 == 0)
                {
                    Console.WriteLine("Giliran Pemain 2");
                }
                else
                {
                    Console.WriteLine("Giliran Pemain 1");
                }

                Console.WriteLine("\n");
                board.Display();
                Console.WriteLine("\n");

                Console.Write("Masukkan nomer kotak: ");
                choice = int.Parse(Console.ReadLine()) - 1;

                if (board.position[choice] != 'X' && board.position[choice] != 'O')
                {
                    if (turn % 2 == 0)
                    {
                        board.position[choice] = 'O';
                        turn++;
                    }
                    else
                    {
                        board.position[choice] = 'X';
                        turn++;
                    }
                }

                Console.WriteLine("\n");
                flag = CheckWinner();

            } while (flag != 1 && flag != -1);

            Console.Clear();
            board.Display();

            if (flag == 1)
            {
                Console.WriteLine("Pemain {0} memenangkan permainan", (turn % 1) + 1);
            }
            else
            {
                Console.WriteLine("Permainan berakhir imbang!");
            }
        }

        private int CheckWinner()
        {
            #region Horisontal
            //Baris pertama
            if (board.position[0] == board.position[1] && board.position[1] == board.position[2])
            {
                return 1;
            }
            //Baris kedua
            else if (board.position[3] == board.position[4] && board.position[4] == board.position[5])
            {
                return 1;
            }
            //Baris ketiga
            else if (board.position[6] == board.position[7] && board.position[7] == board.position[8])
            {
                return 1;
            }
            #endregion

            #region Vertikal
            //Kolom pertama
            else if (board.position[0] == board.position[3] && board.position[3] == board.position[6])
            {
                return 1;
            }
            //Kolom kedua
            else if (board.position[1] == board.position[4] && board.position[4] == board.position[7])
            {
                return 1;
            }
            //Kolom ketiga
            else if (board.position[2] == board.position[5] && board.position[5] == board.position[8])
            {
                return 1;
            }
            #endregion

            #region Diagonal
            else if (board.position[0] == board.position[4] && board.position[4] == board.position[8])
            {
                return 1;
            }
            else if (board.position[2] == board.position[4] && board.position[4] == board.position[6])
            {
                return 1;
            }
            #endregion 

            #region Imbang (Tidak ada pemenang)
            // Jika semua kotak telah terisi dengan X dan O maka tidak ada pememnang
            else if (board.position[0] != '1' && board.position[1] != '2' && board.position[2] != '3' && 
                    board.position[3] != '4' && board.position[4] != '5' && board.position[5] != '6' && 
                    board.position[6] != '7' && board.position[7] != '8' && board.position[8] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}