using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


class Team
{
    private string name;
    private List<Player> playersInTheTeamList = new List<Player>();


    private List<Player> PlayersInTheTeam
    {
        get { return playersInTheTeamList; }
        set { playersInTheTeamList = value; }
    }
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    private double CalculateRating()
    {
        if (playersInTheTeamList.Count == 0)
        {
            return 0;
        }
        else
        {
            return Math.Round(playersInTheTeamList.Select(x => x.AverageSkill()).Average(), MidpointRounding.AwayFromZero);
        }

    }

    public double GetAverageRating
    {
        get
        {
            return this.CalculateRating();
        }
    }

    public void AddPlayer(Player player)
    {
        playersInTheTeamList.Add(player); 
    }

    public void RemovePlayer(string playerName, string teamName)
    {
        if (playersInTheTeamList.Any(x=>x.Name == playerName))
        {
            foreach (var player in playersInTheTeamList)
            {
                if (player.Name == playerName)
                {
                    playersInTheTeamList.Remove(player);
                    break;
                }
            }
        }
        else
        {
            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
        }
    }

    public Team(string name)
    {
        this.Name = name;
    }
}

