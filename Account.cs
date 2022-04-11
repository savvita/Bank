using System;

namespace Bank
{
    internal class Account
    {
        private static int counter = 0;
        private decimal _balance;
        public int ID { get; private set; }

        public static readonly decimal Rate = 29.9m;

        public decimal Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                _balance = (value > 0) ? value : 0;
            }
        }

        public CurrencyType Currency { get; private set; }

        public Account(decimal balance, CurrencyType currency)
        {
            ID = ++counter;
            Balance = balance;
            Currency = currency;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Amount cannot be less than zero");

            Balance += amount;
        }

        public void Withdraw (decimal amount)
        {
            if (amount < 0)
                throw new Exception("Amount cannot be less than zero");

            if (Balance < amount)
                throw new Exception("Insufficient funds on account");

            Balance -= amount;
        }

        public void Transfer(Account account, decimal amount)
        {
            if (amount < 0)
                throw new Exception("Amount cannot be less than zero");

            if (Balance < amount)
                throw new Exception("Insufficient funds on account");

            Balance -= amount;

            decimal sumToTransfer = amount;

            if (Currency != account.Currency)
            {
                if (Currency == CurrencyType.UAH)
                {
                    sumToTransfer /= Rate;
                }
                else
                {
                    sumToTransfer *= Rate;
                }
            }

            account.Deposit(sumToTransfer);
        }

    }
}

enum CurrencyType
{
    UAH,
    USD
}
