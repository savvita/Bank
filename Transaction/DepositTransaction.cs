using System;

namespace Bank
{
    internal class DepositTransaction : Transaction
    {
        public DepositTransaction(BankCard card, decimal sum) : base($"{DateTime.Now}. Deposit {sum} to the card {card.Number}.")
        {
            Execute(card, sum);
        }

        private void Execute(BankCard card, decimal sum)
        {
            try
            {
                card.BankAccount.Deposit(sum);
                Status = "Success";
            }
            catch (Exception ex)
            {
                Status = "Rejected. Reason: " + ex.Message;
            }

            Result = Message + " Status: " + Status + "\n"; 
        }
    }
}
