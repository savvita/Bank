using System;
using System.Collections.Generic;

namespace Bank
{
    internal class Client
    {
        public string Id { get; private set; }

        public string Name { get; set; }

        public List<BankCard> BankCards { get; private set; }

        private Logger _logger;

        public Client(string name, string id)
        {
            Name = name;
            Id = id;
            BankCards = new List<BankCard>();
            _logger = new Logger();
        }


        public void AddInforming(Action<string> logger)
        {
            _logger.AddLogger(logger);
        }

        public void RemoveInforming(Action<string> logger)
        {
            _logger.RemoveLogger(logger);
        }

        public void OpenCard(decimal sum = 0, CurrencyType currency = CurrencyType.UAH)
        {
            BankCard card = new BankCard(this, sum, currency);
            BankCards.Add(card);
            _logger.Log($"{DateTime.Now}. The card {card.Number} is opened\n");
        }

        public void CloseCard(BankCard card)
        {
            if (BankCards.Contains(card))
            {
                BankCards.Remove(card);
                _logger.Log($"{DateTime.Now}. The card {card.Number} is closed\n");
            }
        }

        public void CloseCard(string number)
        {
            number = number.Replace(" ", "");

            for (int i = 0; i < BankCards.Count; i++)
            {
                string str = BankCards[i].Number.Replace(" ", "");

                if (str == number)
                {
                    BankCards.Remove(BankCards[i]);
                    _logger.Log($"{DateTime.Now}. The card {BankCards[i].Number} is closed\n");
                    break;
                }
            }
        }

        public void Deposit(BankCard card, decimal sum)
        {
            Transaction transaction = new DepositTransaction(card, sum);

            Inform(transaction);
        }

        public void Withdraw(BankCard card, decimal sum)
        {
            Transaction transaction = new WithdrawTransaction(this, card, sum);

            Inform(transaction);
        }

        public void Transfer(BankCard from, BankCard to, decimal sum)
        {
            Transaction transaction = new TransferTransaction(this, from, to, sum);

            Inform(transaction);
        }

        public void ShowAllCards()
        {
            for (int i = 0; i < BankCards.Count; i++)
            {
                Console.WriteLine(BankCards[i]);
            }
        }

        private void Inform(Transaction transaction)
        {
            _logger.Log(transaction.Result);
        }
    }
}
