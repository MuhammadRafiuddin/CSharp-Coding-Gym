using System;

namespace CodingGym05.ShoppingCart
{
    class Program
    {
        static string[] shoppingCart;

        static void Main(string[] args)
        {
            // Initialize shopping cart with 10 elements
            shoppingCart = new string[10];
            // Declare a variabel of type boolean to determine whether the program should end or not
            bool finished = false;
            string ans, product;

            // Main loop
            while (!finished)
            {
                // Recieve user input. Store in ans variable
                Console.Write("quit/add/remove/display/clear: ");
                ans = Console.ReadLine().ToLower();

                // Process user input
                switch (ans)
                {
                    case "quit":
                        Console.WriteLine("Thank you for using our application.");
                        ShowAllProductInCart();
                        finished = true;
                        break;
                    case "add":
                        Console.Write("Enter product you want to add: ");
                        product = Console.ReadLine().ToLower();
                        AddProductToCart(product);
                        break;
                    case "remove":
                        ShowAllProductInCart();
                        Console.Write("Enter product you want to remove: ");
                        product = Console.ReadLine().ToLower();
                        RemoveProductFromCart(product);
                        break;
                    case "display":
                        ShowAllProductInCart();
                        break;
                    case "clear":
                        ClearAllProductInCart();
                        Console.WriteLine("Your cart is empty.");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("{0} is not in the option. Please select again!", ans);
                        break;
                }
            }
        }
        #region Methods        
        static void AddProductToCart(string product)
        {
            Console.Clear();
            // Cari elemen array yang kosong (null)
            for (int i = 0; i < shoppingCart.Length; i++)
            {
                if (shoppingCart[i] == null)
                {
                    // jika ada yang kosong, isi dengan barang
                    shoppingCart[i] = product;
                    break;
                }
            }
        }

        static void RemoveProductFromCart(string product)
        {
            Console.Clear();            
            // Find array element that match the product name
            for (int i = 0; i < shoppingCart.Length; i++)
            {
                if (shoppingCart[i] == product)
                {
                    shoppingCart[i] = null;
                    break;
                }
            }
        }

        static void ShowAllProductInCart()
        {
            Console.Clear();
            // All is an extension method for IEnumerable type defined in System.Linq
            // https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netframework-4.8
            if (shoppingCart.All(product => product == null))
            {
                Console.WriteLine("-- Your shopping cart is empty. --");
            }
            else
            {
                foreach (string prod in shoppingCart)
                {
                    if (prod != null)
                    {
                        Console.WriteLine("- {0}", prod);
                    }
                }
            }
        }

        static void ClearAllProductInCart()
        {
            // Clear all elements in shopping cart
            for (int i = 0; i < shoppingCart.Length; i++)
            {
                shoppingCart[i] = null;
            }
        }
        #endregion        
    }
}
