using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeedFW
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = new CarManager();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Cops Are Here")
                {
                    break;
                }

                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                Command(tokens, manager);
            }
        }

        public static void Command(string[] tokens, CarManager manager)
        {
            if (tokens[0].ToLower() == "register")
            {
                int id = int.Parse(tokens[1]);
                string type = tokens[2];
                string brand = tokens[3];
                string model = tokens[4];
                int year = int.Parse(tokens[5]);
                int hp = int.Parse(tokens[6]);
                int acceleration = int.Parse(tokens[7]);
                int suspension = int.Parse(tokens[8]);
                int durability = int.Parse(tokens[9]);
                manager.Register(id, type, brand, model, year, hp, acceleration, suspension, durability);
            }
            else if (tokens[0].ToLower() == "open")
            {
                int id = int.Parse(tokens[1]);
                string type = tokens[2];
                int length = int.Parse(tokens[3]);
                string route = tokens[4];
                int prizePool = int.Parse(tokens[5]);
                manager.Open(id, type, length, route, prizePool);
            }
            else if (tokens[0].ToLower() == "participate")
            {
                int carId = int.Parse(tokens[1]);
                int raceId = int.Parse(tokens[2]);
                manager.Participate(carId, raceId);
            }
            else if (tokens[0].ToLower() == "check")
            {
                int id = int.Parse(tokens[1]);
                Console.WriteLine(manager.Check(id));               
            }
            else if (tokens[0].ToLower() == "start")
            {
                int raceId = int.Parse(tokens[1]);
                Console.WriteLine(manager.Start(raceId));               
            }
            else if (tokens[0].ToLower() == "tune")
            {
                int tuneIndex = int.Parse(tokens[1]);
                string tuneAddon = tokens[2];
                manager.Tune(tuneIndex, tuneAddon);
            }
            else if (tokens[0].ToLower() == "park")
            {
                int carId = int.Parse(tokens[1]);
                manager.Park(carId);
            }
            else if (tokens[0].ToLower() == "unpark")
            {
                int carid = int.Parse(tokens[1]);
                manager.Unpark(carid);
            }
        }
    }
}

