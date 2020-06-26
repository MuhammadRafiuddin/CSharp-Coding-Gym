using System;
using System.Collections.Generic;

namespace CodingGym10.ShoppingCart.DelegateDict
{
    public enum Operations { tambah = 1, hapus, tampilkan, kosongkan, keluar }

    public class ShoppingCart
    {        
        private List<string> cart = new List<string>();
        // Delegate Dictionary Pattern
        public Dictionary<Operations, Action> actionDict = new Dictionary<Operations, Action>();
        public bool Finished { get; set; }

        public ShoppingCart()
        {
            AddAction();
        }

        private void AddAction()
        {
            actionDict.Add(Operations.tambah, AddProductToCart);
            actionDict.Add(Operations.hapus, RemoveProductFromCart);
            actionDict.Add(Operations.tampilkan, ShowAllProductInCart);
            actionDict.Add(Operations.kosongkan, ClearAllProductInCart);
            actionDict.Add(Operations.keluar, Quit);
        }

        private void AddProductToCart()
        {
            Console.Write("Enter product you want to add: ");
            string product = Console.ReadLine().ToLower();
            Console.Clear();
            cart.Add(product);
            Console.WriteLine($"{product} has been added to the cart\n");
        }

        private void RemoveProductFromCart()
        {
            ShowAllProductInCart();
            Console.Write("Enter product you want to remove: ");
            string product = Console.ReadLine().ToLower();
            Console.Clear();
            cart.Remove(product);
            Console.WriteLine($"{product} has been removed from the cart\n");
        }

        private void ShowAllProductInCart()
        {
            Console.Clear();
            if (cart.Count < 1)
            {
                Console.WriteLine("-- Your shopping cart is empty. --");
            }
            else
            {
                Console.WriteLine("Your shopping cart: ");
                foreach (string prod in cart)
                {                    
                    Console.WriteLine("- {0}", prod);
                }
                Console.WriteLine();
            }
        }

        private void ClearAllProductInCart()
        {
            Console.Clear();
            cart.Clear();
            Console.WriteLine("Your shopping cart has been cleared\n");
        }

        private void Quit()
        {            
            ShowAllProductInCart();
            Console.WriteLine("Thank you for using our application.");
            Finished = true;
        }
    }
}