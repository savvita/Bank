using System;

namespace Bank
{
    internal static class GetAdditionalInfo
    {
        public static CurrencyType GetCurrency()
        {
            Console.WriteLine("Currency:");

            foreach (var item in Enum.GetNames(typeof(CurrencyType)))
            {
                Console.WriteLine(item);
            }

            if (Int32.TryParse(Console.ReadLine(), out int ch))
            {
                var currencies = Enum.GetValues(typeof(CurrencyType));

                ch--;

                if (ch >= (int)currencies.GetValue(0) && ch <= (int)currencies.GetValue(currencies.Length - 1))
                {
                    return (CurrencyType)ch;
                }
            }

            return CurrencyType.UAH;

        }

        public static decimal GetSum()
        {
            Console.WriteLine("Sum:");

            if (Decimal.TryParse(Console.ReadLine(), out decimal ch))
            {
                return ((ch > 0) ? ch : 0m);
            }

            return 0m;
        }

        public static string GetCardNumber()
        {
            Console.Write("Card #: ");

            return Console.ReadLine();
        }
    }
}
