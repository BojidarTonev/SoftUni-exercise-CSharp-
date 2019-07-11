using System;
using System.Linq;

namespace GrandPrixAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceTower raceTower = new RaceTower();
            int numberOfLaps = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());
            raceTower.SetTrackInfo(numberOfLaps, trackLength);
            while (raceTower.track.currentLap < numberOfLaps)
            {
                try
                {
                    var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    switch (input[0])
                    {
                        case "RegisterDriver":
                            raceTower.RegisterDriver(input.ToList());
                            break;
                        case "Leaderboard":
                            raceTower.GetLeaderboard();
                            break;
                        case "CompleteLaps":
                            raceTower.CompleteLaps(input.Skip(1).ToList());
                            break;
                        case "Box":
                            raceTower.DriverBoxes(input.Skip(1).ToList());
                            break;
                        case "ChangeWeather":
                            raceTower.ChangeWeather(input.Skip(1).ToList());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
        }
    }
}
