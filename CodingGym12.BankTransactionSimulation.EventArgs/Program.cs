using System;

namespace CodingGym12.BankTransactionSimulation.EventArgs_
{
    class Program
    {
        static void Main(string[] args)
        {
            /* First, make an Account object */
            Account acc = new Account();

            #region Registering the handler
            /* Register event handlers */
            acc.Transaction += OnTransactionEvent;
            acc.Transaction += OnTransactionEvent2;

            /* Register event handlers as anonymous methods. */
            // acc.Transaction += delegate(object sender, TransactionEventArgs e)
            // {
            //    Console.WriteLine(e.msg);
            // };

            /* Register event handlers using lambda expression */
            // acc.Transaction += (object sender, TransactionEventArgs e) => Console.WriteLine(e.msg);    
            #endregion            

            #region Trigger events            
            /* Make a transaction (this will trigger the events) */
            bool contd = true;

            do
            {
                Console.Write("Please select a transaction or quit [1. deposit, 2. withdrawal, 3. quit]: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Deposit amount: ");
                        int deposit = int.Parse(Console.ReadLine());                        
                        acc.Deposit(deposit);
                        break;
                    case 2:
                        Console.Write("Withdrawal amount: ");
                        int withdraw = int.Parse(Console.ReadLine());                        
                        acc.Withdrawal(withdraw);
                        break;
                    case 3:
                        contd = false;
                        break;
                    default:
                        break;
                }

                #region Unregister the OnTransactionEvent2 handler
                acc.Transaction -= OnTransactionEvent2;
                #endregion
            }
            while (contd);
            #endregion
        }

        /* This is the target for incoming events */
        public static void OnTransactionEvent(object sender, TransactionEventArgs e) => Console.WriteLine(e.msg);

        public static void OnTransactionEvent2(object sender, TransactionEventArgs e) => Console.WriteLine(e.msg.ToUpper());
    }
}
