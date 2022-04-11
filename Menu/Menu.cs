using System;
using System.Collections.Generic;

namespace Bank
{
    internal class Menu
    {
        readonly Client _client;
        List<ActionType> actions;

        public Menu(Client client)
        {
            _client = client;
            actions = new List<ActionType>();

            actions.Add(new ActionType("Open a card", OpenCard));
            actions.Add(new ActionType("Close a card", CloseCard));
            actions.Add(new ActionType("Show all cards", () => _client.ShowAllCards()));
            actions.Add(new ActionType("Withdraw", Withdraw));
            actions.Add(new ActionType("Deposit", Deposit));
            actions.Add(new ActionType("Transfer", Transfer));
        }

        public void Show()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actions[i].Name}");
            }


            if (Int32.TryParse(Console.ReadLine(), out int ch))
            {
                if (ch >= 1 && ch <= actions.Count)
                {
                    actions[ch - 1].ActionToDo();
                }
            }
        }

        private void OpenCard()
        {
            CurrencyType currency = GetAdditionalInfo.GetCurrency();
            decimal sum = GetAdditionalInfo.GetSum();
            _client.OpenCard(sum, currency);
        }

        private void CloseCard()
        {
            _client.ShowAllCards();
            string number = GetAdditionalInfo.GetCardNumber();
            _client.CloseCard(number);
        }

        private void Withdraw()
        {
            _client.ShowAllCards();
            string number = GetAdditionalInfo.GetCardNumber();

            BankCard card = GetCardByNumber(number);

            if (card != null)
            {
                decimal sum = GetAdditionalInfo.GetSum();
                _client.Withdraw(card, sum);
            }
        }

        private void Deposit()
        {
            _client.ShowAllCards();
            string number = GetAdditionalInfo.GetCardNumber();

            BankCard card = GetCardByNumber(number);

            if (card != null)
            {
                decimal sum = GetAdditionalInfo.GetSum();
                _client.Deposit(card, sum);
            }
        }

        private void Transfer()
        {
            _client.ShowAllCards();
            string number = GetAdditionalInfo.GetCardNumber();

            BankCard card = GetCardByNumber(number);

            if (card != null)
            {
                string numberTo = GetAdditionalInfo.GetCardNumber();
                decimal sum = GetAdditionalInfo.GetSum();

                BankCard cardTo = GetCardByNumber(numberTo);

                if(cardTo != null)
                    _client.Transfer(card, cardTo, sum);
                else
                    _client.Transfer(card, new BankCard(numberTo), sum);
            }
        }

        private BankCard GetCardByNumber(string number)
        {
            number = number.Replace(" ", "");
            for (int i = 0; i < _client.BankCards.Count; i++)
            {
                string str = _client.BankCards[i].Number.Replace(" ", "");

                if (str == number)
                {
                    return _client.BankCards[i];
                }
            }

            return null;
        }
    }
}
