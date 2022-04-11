using System;

namespace Bank
{
    internal class TransferTransaction : Transaction
    {
        public TransferTransaction(Client client, BankCard cardFrom, BankCard cardTo, decimal sum) : 
            base($"{DateTime.Now}. Transfer {sum} {cardFrom.Currency} from the card {cardFrom.Number} to {cardTo.Number}.")
        {
            Execute(client, cardFrom, cardTo, sum);
        }

        private void Execute(Client client, BankCard cardFrom, BankCard cardTo, decimal sum)
        {
            try
            {
                if (client.Id != cardFrom.Owner.Id)
                    throw new Exception("The card is not own to the client");

                cardFrom.BankAccount.Transfer(cardTo.BankAccount, sum);
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
