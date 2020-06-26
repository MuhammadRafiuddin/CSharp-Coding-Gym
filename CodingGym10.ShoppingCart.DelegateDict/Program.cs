using System;

namespace CodingGym10.ShoppingCart.DelegateDict
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart shopping = new ShoppingCart();
            string ans;

            while (!shopping.Finished)
            {                
                int num = 0;
                foreach (string op in Enum.GetNames(typeof(Operations)))
                {
                    num++;
                    Console.WriteLine($"{num}.{op}");
                }
                
                Console.Write("Select an operation: ");
                ans = Console.ReadLine();

                if (Enum.TryParse(ans, true, out Operations ops))
                {
                    if (Enum.IsDefined(typeof(Operations), ops))
                        shopping.actionDict[ops]();
                    else
                    {                        
                        Console.WriteLine("{0} is not in the option. Please select again!", ans);
                    }
                    
                    if (shopping.Finished) break;
                }
                else
                {
                    Console.WriteLine("{0} is not in the option. Please select again!", ans);
                }
            }

            Console.ReadLine();
        }
    }
}
