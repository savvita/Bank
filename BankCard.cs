using System;
using System.Text;

namespace Bank
{
    internal class BankCard
    {
        public Account BankAccount { get; private set; }
        public string Number { get; private set; }

        public int CVV { get; private set; }

        public DateTime OpenedDate { get; private set; }

        public CurrencyType Currency { get; private set; }

        public Client Owner { get; private set; }

        public BankCard(Client owner, decimal sum = 0, CurrencyType currency = CurrencyType.UAH)
        {
            BankAccount = new Account(sum, currency);
            Number = GetNumber();
            CVV = GetCVV();
            OpenedDate = DateTime.Now;
            Currency = currency;
            Owner = owner;
        }

        public BankCard(string number)
        {
            BankAccount = new Account(0, CurrencyType.UAH);
            Number = number;
            Currency = CurrencyType.UAH;
            Owner = null;
        }

        public override string ToString()
        {
            return String.Format("Number: {0}. Balance: {1}. Currency: {2}. Opened: {3}", Number, BankAccount.Balance, Currency.ToString(), OpenedDate.ToShortDateString());
        }

        private static int GetCVV()
        {
            Random random = new Random();

            return random.Next(100, 999);
        }
        private static string GetNumber()
        {
            StringBuilder sb = new StringBuilder();

            Random random = new Random();

            sb.Append((char)('4' + random.Next(0, 1)));

            for (int i = 1; i < 15; i++)
            {
                if(i % 4 == 0)
                    sb.Append(' ');

                sb.Append((char)('0' + random.Next(0, 8)));
            }

            sb.Append(Luhn(sb.ToString()));

            return sb.ToString();
        }

        private static int Luhn (string number)
        {
	        int check_digit = 0;
            bool odd = false;

            for(int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] != ' ')
                {
                    int digit = number[i] - '0';

                    if ((odd = !odd))
                    {
                        digit *= 2;

                        if (digit > 9)
                        {
                            digit -= 9;
                        }
                    }

                    check_digit += digit;
                }
	        }

            return (check_digit * 9) % 10;
        }
        
    }
}
