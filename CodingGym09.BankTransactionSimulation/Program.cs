using System;

namespace CodingGym09.BankTransactionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /* First, make an Account object */
            Account acc = new Account();

            #region Register First handler
            /* Now tell the account which method to call when it wants to send us messages */
            acc.RegisterWithTransaction(new TransactionEventHandler(OnTransactionEvent));

            /********************************************************************************
            # method group conversion
            # no need delegate object
            # directly register the callie method to the delegate's invocation list
            ********************************************************************************/
            // acc.RegisterWithTransaction(OnTransactionEvent);
            #endregion

            #region Register Second Handler
            /* register event handlers using a reference to delegate object */
            /* hold delegate object, so we can unregister later */
            TransactionEventHandler handler = new TransactionEventHandler(OnTransactionEvent2);
            acc.RegisterWithTransaction(handler);

            /* register event handlers using method group conversion */
            //acc.RegisterWithTransaction(OnTransactionEvent2); 
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
                /* register using the delegate object */
                acc.UnRegisterWithTransaction(handler);

                /* unregister using method group conversion */
                //acc.UnRegisterWithTransaction(OnTransactionEvent2);
                #endregion
            }
            while (contd);
            #endregion
        }

        /* This is the target for incoming events */
        public static void OnTransactionEvent(string msg) => Console.WriteLine(msg);

        public static void OnTransactionEvent2(string msg) => Console.WriteLine(msg.ToUpper());
    }
}
