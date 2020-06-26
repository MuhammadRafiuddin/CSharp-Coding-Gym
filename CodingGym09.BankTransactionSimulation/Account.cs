namespace CodingGym09.BankTransactionSimulation
{
    /* [1]. Define a delegate type */
    public delegate void TransactionEventHandler(string msg);

    public class Account
    {
        public int Balance { get; set; }

        /* [2]. Define a member variable of the delegate */
        private TransactionEventHandler listOfHandlers;

        /* [3]. Add registration function for the caller */
        public void RegisterWithTransaction(TransactionEventHandler methodToCall)
        {
            // listOfHandlers = methodToCall;
            /* enabling multicast delegate */
            listOfHandlers += methodToCall;
        }

        public void UnRegisterWithTransaction(TransactionEventHandler methodToCall)
        {
            /* removing targets from a delagate's invocation list */
            listOfHandlers -= methodToCall;
        }

        public void Withdrawal(int amount)
        {
            /* [4] Invoke the delegate's invocation list under the correct circumtances */
            if ((amount <= Balance) && (listOfHandlers != null))
            {
                Balance -= amount;
                listOfHandlers($"You withdrew Rp. {amount:N0}. Balance: Rp. {Balance:N0}");
            }
            else
            {
                listOfHandlers($"Transaction FAILED! You are not allowed to withdraw more than : Rp. {Balance:N0}");
            }
        }

        public void Deposit(int amount)
        {
            Balance += amount;
            /* [4] Invoke the delegate's invocation list under the correct circumtances */
            if (listOfHandlers != null)
            {
                listOfHandlers($"You deposited: Rp. {amount:N0}. Balance: Rp. {Balance:N0}");
            }
        }
    }
}