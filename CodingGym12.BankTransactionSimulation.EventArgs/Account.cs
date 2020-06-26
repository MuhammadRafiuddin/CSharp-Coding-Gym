using System;

namespace CodingGym12.BankTransactionSimulation.EventArgs_
{
    public class TransactionEventArgs : EventArgs
    {
        public readonly string msg;

        public TransactionEventArgs(string msg)
        {
            this.msg = msg;
        }
    }

    public class Account
    {
        public int Balance { get; set; }

        /* no longer need to define a custom delegate type at all, so we can remove the delegate declaration */
        public event EventHandler<TransactionEventArgs> Transaction;

        public void Withdrawal(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Transaction?.Invoke(this, new TransactionEventArgs($"You withdrew Rp. {amount:N0}. Balance: Rp. {Balance:N0}"));
            }
            else
            {
                Transaction?.Invoke(this, new TransactionEventArgs($"Transaction FAILED! You are not allowed to withdraw more than : Rp. {Balance:N0}"));
            }
        }

        public void Deposit(int amount)
        {
            Balance += amount;
            Transaction?.Invoke(this, new TransactionEventArgs($"You deposited: Rp. {amount:N0}. Balance: Rp. {Balance:N0}"));
        }
    }
}