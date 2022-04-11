using System;

namespace Bank
{
    internal class WithdrawTransaction : Transaction
    {
        public WithdrawTransaction(Client client, BankCard card, decimal sum) : base($"{DateTime.Now}. Withdraw {sum} from the card {card.Number}.")
        {
            Execute(client, card, sum);
        }

        private void Execute(Client client, BankCard card, decimal sum)
        {
            try
            {
                if (client.Id != card.Owner.Id)
                    throw new Exception("The card is not own to the client");

                card.BankAccount.Withdraw(sum);
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
