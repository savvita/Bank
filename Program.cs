using System;
using System.IO;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("John", "12");
            client.AddInforming(Console.WriteLine);
            client.AddInforming((message) => File.AppendAllText("log.txt", message));

            Menu menu = new Menu(client);

            do
            {
                Console.Clear();
                menu.Show();

            } while(Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
