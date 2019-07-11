using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    DungeonMaster dungeonMaster = new DungeonMaster();

    public void Run()
    {
        while (!dungeonMaster.IsGameOver())
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Final stats:");
                foreach (var character in dungeonMaster.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
                {
                    sb.AppendLine(character.ToString());
                }

                Console.WriteLine(sb.ToString().TrimEnd());
                break;
            }

            var tokens = input.Split(' ').ToArray();
            try
            {
                switch (tokens[0])
                {
                    case "JoinParty":
                        Console.WriteLine(dungeonMaster.JoinParty(tokens.Skip(1).ToArray()));
                        break;
                    case "AddItemToPool":
                        Console.WriteLine(dungeonMaster.AddItemToPool(tokens.Skip(1).ToArray()));
                        break;
                    case "PickUpItem":
                        Console.WriteLine(dungeonMaster.PickUpItem(tokens.Skip(1).ToArray()));
                        break;
                    case "UseItem":
                        Console.WriteLine(dungeonMaster.UseItem(tokens.Skip(1).ToArray()));
                        break;
                    case "UseItemOn":
                        Console.WriteLine(dungeonMaster.UseItemOn(tokens.Skip(1).ToArray()));
                        break;
                    case "GiveCharacterItem":
                        Console.WriteLine(dungeonMaster.GiveCharacterItem(tokens.Skip(1).ToArray()));
                        break;
                    case "GetStats":
                        Console.WriteLine(dungeonMaster.GetStats());
                        break;
                    case "Attack":
                        Console.WriteLine(dungeonMaster.Attack(tokens.Skip(1).ToArray()));
                        break;
                    case "Heal":
                        Console.WriteLine(dungeonMaster.Heal(tokens.Skip(1).ToArray()));
                        break;
                    case "EndTurn":
                        Console.WriteLine(dungeonMaster.EndTurn(tokens.Skip(1).ToArray()));
                        break;
                    case "IsGameOver":
                        Console.WriteLine(dungeonMaster.IsGameOver());
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

