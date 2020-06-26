using System;
using System.Linq;

namespace CodingGym01.PrintingReceipt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            // Variables declaration
            string companyName = "MahirKoding.id";
            string address = "Banguntapan 55198";
            string city = "Bantul";
            int phoneNum = 1234567890;
            
            string p1Name = "Book", p2Name = "Computer", p3Name = "Monitor";
            int p1Price = 150_000, p2Price = 8_000_000, p3Price = 1_500_000;            

            string msg = "Thank you for shopping with us";
            int cursorPosLeft = 0, cursorPosRight = 49;

            // Enumerable is a member of System.Linq
            Console.WriteLine("+" + String.Join("", Enumerable.Repeat("-", 48)) + "+");            

            // Header
            Console.WriteLine("\t\t{0}", companyName);
            Console.WriteLine("\t\t{0}", address);
            Console.WriteLine("\t\t{0}", city);
            Console.WriteLine(String.Format("\t\t{0:(###) ###-####}", phoneNum));

            Console.WriteLine("+" + String.Join("", Enumerable.Repeat("-", 48)) + "+");

            // Purchase detail
            Console.WriteLine("\n\tProduct Name\t\tPrice");

            Console.WriteLine("\t{0}\t\t\tRp. {1:N0}", p1Name, p1Price);
            Console.WriteLine("\t{0}\t\tRp. {1:N0}", p2Name, p2Price);
            Console.WriteLine("\t{0}\t\t\tRp. {1:N0}\n", p3Name, p3Price);

            Console.WriteLine("+" + String.Join("", Enumerable.Repeat("-", 48)) + "+");

            // Total price
            int total = p1Price + p2Price + p3Price;
            Console.WriteLine("\n\tTotal\t\t\tRp. {0:N0}\n", total);

            Console.WriteLine("+" + String.Join("", Enumerable.Repeat("-", 48)) + "+");

            // Footer
            Console.WriteLine("\n\t{0}\n", msg);

            Console.WriteLine("+" + String.Join("", Enumerable.Repeat("-", 48)) + "+");

            // Print Border
            for(int rowPos = 1; rowPos < 20; rowPos++)
            {
                Console.SetCursorPosition(cursorPosLeft,rowPos);
                Console.Write("|");
                Console.SetCursorPosition(cursorPosRight,rowPos);
                Console.WriteLine("|");
            }

            Console.ReadLine();
        }
    }
}
