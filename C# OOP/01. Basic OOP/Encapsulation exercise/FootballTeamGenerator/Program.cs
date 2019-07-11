using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FootBallStuffAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team>teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[]tokens = input.Split(';');


                if (tokens[0] == "Team")
                {
                    CreatingTeam(tokens, teams);
                }

                if (tokens[0] == "Add")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    int endurance = int.Parse(tokens[3]);
                    int sprint = int.Parse(tokens[4]);
                    int dribble = int.Parse(tokens[5]);
                    int passing = int.Parse(tokens[6]);
                    int shooting = int.Parse(tokens[7]);
                    try
                    {
                        Player player = new Player(shooting, passing, dribble, sprint, endurance, playerName);
                        if (teams.Any(x=>x.Name.Equals(teamName)))
                        {
                            teams.Find(x=>x.Name == teamName).AddPlayer(player);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }                   
                }

                if (tokens[0] == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    try
                    {
                        if (teams.Any(x=>x.Name.Equals(teamName)))
                        {
                            teams.Find(x=>x.Name == teamName).RemovePlayer(playerName, teamName);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (tokens[0] == "Rating")
                {
                    string teamName = tokens[1];
                    try
                    {
                        if (teams.Any(x=>x.Name == teamName))
                        {
                            Console.WriteLine($"{teamName} - {teams.Find(x => x.Name.Equals(teamName)).GetAverageRating}");
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

        }

        private static void CreatingTeam(string[] tokens, List<Team>teams)
        {
            string teamName = tokens[1];
            try
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
