using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordered_banking_system
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, decimal>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string bank = tokens[0];
                string account = tokens[1];
                decimal balance = decimal.Parse(tokens[2]);
                if (!result.ContainsKey(bank))
                {
                    result.Add(bank, new Dictionary<string, decimal>());
                    result[bank].Add(account, balance);
                }
                else
                {
                    if (result[bank].ContainsKey(account))
                    {
                        result[bank][account]+=balance;
                    }
                    else
                    {
                        result[bank].Add(account, balance);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var bank in result.OrderByDescending(x => x.Value.Values.Sum()).ThenByDescending(x=>x.Value.Values.Max()))
            {
                foreach (var account in bank.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{account.Key} -> {account.Value} ({bank.Key})");
                }
            }
        }
    }
}