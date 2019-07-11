using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElitee
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Private> allPrivates = new List<Private>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens[0] == "Private")
                {
                    ProcessRawDataForPrivate(tokens, allPrivates);
                }

                if (tokens[0] == "LeutenantGeneral")
                {
                    ProcessRawDataForLeutenantGeneral(tokens, allPrivates);
                }

                if (tokens[0] == "Engineer")
                {
                    ProcessRawDataForEnginner(tokens);
                }
                if (tokens[0] == "Commando")
                {
                    ProcessRawDataForCommando(tokens);
                }

                if (tokens[0] == "Spy")
                {
                    ProcessRawDataForSpy(tokens);
                }
            }
        }

        private static void ProcessRawDataForSpy(string[] tokens)
        {
            string id = tokens[1];
            string firstname = tokens[2];
            string lastname = tokens[3];
            string codeNumber = tokens[4];
            Spy spy = new Spy(id, firstname, lastname, codeNumber);
            Console.WriteLine(spy);
        }

        private static void ProcessRawDataForCommando(string[] tokens)
        {
            string id = tokens[1];
            string firstname = tokens[2];
            string lastname = tokens[3];
            double salary = double.Parse(tokens[4]);
            string corps = tokens[5];
            if (corps == "Marines" || corps == "Airforces")
            {
                var commando = new Commando(id, firstname, lastname, salary, corps);
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    string missionCodeName = tokens[i];
                    string missionState = tokens[i + 1];
                    if (missionState == "inProgress" || missionState == "Finished")
                    {
                        Missions mission = new Missions(missionCodeName, missionState);
                        commando.missions.Add(mission);
                    }
                }
                Console.WriteLine(commando);
            }
        }

        private static void ProcessRawDataForEnginner(string[] tokens)
        {
            string id = tokens[1];
            string firstname = tokens[2];
            string lastname = tokens[3];
            double salary = double.Parse(tokens[4]);
            string corps = tokens[5];
            if (corps == "Marines" || corps == "Airforces")
            {
                var engineer = new Engineer(id, firstname, lastname, salary, corps);
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    string repairPart = tokens[i];
                    int repairHours = int.Parse(tokens[i + 1]);
                    Repair repair = new Repair(repairPart, repairHours);
                    engineer.toolKit.Add(repair);
                }
                Console.WriteLine(engineer);
            }
        }

        private static void ProcessRawDataForLeutenantGeneral(string[] tokens, List<Private> allPrivates)
        {
            string id = tokens[1];
            string firstname = tokens[2];
            string lastname = tokens[3];
            double salary = double.Parse(tokens[4]);
            var leutenantGeneral = new LeutenantGeneral(id, firstname, lastname, salary);
            for (int i = 5; i < tokens.Length; i++)
            {
                foreach (var allPrivate in allPrivates)
                {
                    if (allPrivate.id == tokens[i])
                    {
                        leutenantGeneral.peopleUnderCommand.Add(allPrivate);
                        break;
                    }
                }
            }
            Console.WriteLine(leutenantGeneral);
        }

        private static void ProcessRawDataForPrivate(string[] tokens, List<Private> allPrivates)
        {
            string id = tokens[1];
            string firstname = tokens[2];
            string lastname = tokens[3];
            double salary = double.Parse(tokens[4]);
            Private soldier = new Private(id, firstname, lastname, salary);
            Console.WriteLine(soldier);
            allPrivates.Add(soldier);
        }
    }
}
