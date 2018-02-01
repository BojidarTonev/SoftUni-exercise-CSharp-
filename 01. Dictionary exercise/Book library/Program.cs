using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer>customers = new List<Customer>();
            Dictionary<string, decimal>shop = new Dictionary<string, decimal>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('-').ToArray();
                if (!shop.ContainsKey(tokens[0]))
                {
                    shop.Add(tokens[0], decimal.Parse(tokens[1]));
                }
                else
                {
                    shop[tokens[0]] = decimal.Parse(tokens[1]);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of clients")
                {
                    break;
                }
                string[] tokens = input.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (shop.ContainsKey(tokens[1]))
                {
                    //proverka za sushestvuvasht chovek da napravq
                    var primerno = new KeyValuePair<string, int>(tokens[1], int.Parse(tokens[2]));
                    Customer customer = new Customer(){Name = tokens[0], ShopList = primerno};
                    foreach (var item in shop)
                    {
                        if (item.Key.Equals(tokens[1]))
                        {
                            customer.Bill = item.Value * decimal.Parse(tokens[2]);
                            break;
                        }
                    }
                    customers.Add(customer);
                }
            }
            decimal totalBill = 0;
            foreach (var customer in customers.OrderBy(x=>x.Name))
            {
                totalBill += customer.Bill;
                Console.WriteLine(customer.Name);
                Console.WriteLine($"-- {customer.ShopList.Key} - {customer.ShopList.Value}");
                Console.WriteLine($"Bill: {customer.Bill:f2}");              
            }
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
    public class Customer
    {
        public KeyValuePair<string, int> ShopList { get; set; }
        public decimal Bill { get; set; }
        public string Name { get; set; }
    }
}
