namespace CodingGym11.BankTransactionSimulation.Event
{
    public delegate void TransactionEventHandler(string msg);

    public class Account
    {
        public int Balance { get; set; }

        public event TransactionEventHandler Transaction;

        public void Withdrawal(int amount)
        {
            if ((amount <= Balance) && (Transaction != null))
            {
                Balance -= amount;
                Transaction($"You withdrew Rp. {amount:N0}. Balance: Rp. {Balance:N0}");
            }
            else
            {
                Transaction($"Transaction FAILED! You are not allowed to withdraw more than : Rp. {Balance:N0}");
            }
        }

        public void Deposit(int amount)
        {
            Balance += amount;
            if (Transaction != null)
            {
                Transaction($"You deposited: Rp. {amount:N0}. Balance: Rp. {Balance:N0}");
            }
        }
    }
}