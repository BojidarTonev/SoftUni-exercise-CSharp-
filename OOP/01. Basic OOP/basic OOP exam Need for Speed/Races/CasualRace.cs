using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public string Type => "Casual";

    public override string ToString()
    {
        this.Participants = this.Participants.OrderByDescending(x => x.CasualPerformance).ToList();
        var sb = new StringBuilder();
        if (this.Participants.Count < 3)
        {
            int counter = this.Participants.Count;
            sb.AppendLine($"{this.Route} - {this.Length}");
            for (int i = 0; i < counter; i++)
            {
                if (i == 0)
                {
                    sb.AppendLine(
                        $"{i + 1}. {Participants[i].Brand} {Participants[i].Model} {Participants[i].CasualPerformance}PP - ${PrizePool / 2}");
                }

                if (i == 1)
                {
                    sb.AppendLine(
                        $"{i + 1}. {Participants[i].Brand} {Participants[i].Model} {Participants[i].CasualPerformance}PP - ${PrizePool * 0.3}");
                }

                if (i == 2)
                {
                    sb.AppendLine(
                        $"{i + 1}. {Participants[i].Brand} {Participants[i].Model} {Participants[i].CasualPerformance}PP - ${PrizePool * 0.2}");
                }
            }
        }
        else
        {
            int counter = 1;
            sb.AppendLine($"{this.Route} - {this.Length}");
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    sb.AppendLine(
                        $"{i + 1}. {Participants[i].Brand} {Participants[i].Model} {Participants[i].CasualPerformance}PP - ${PrizePool / 2}");
                }

                if (i == 1)
                {
                    sb.AppendLine(
                        $"{i + 1}. {Participants[i].Brand} {Participants[i].Model} {Participants[i].CasualPerformance}PP - ${PrizePool * 0.3}");
                }

                if (i == 2)
                {
                    sb.AppendLine(
                        $"{i + 1}. {Participants[i].Brand} {Participants[i].Model} {Participants[i].CasualPerformance}PP - ${PrizePool * 0.2}");
                }

                counter++;
            }
        }

        return sb.ToString().TrimEnd();
    }
}

