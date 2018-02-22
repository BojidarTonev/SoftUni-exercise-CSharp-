using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> participants = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (participants.Any(x => x.Name.Equals(trainerName)))
                {
                    foreach (var participant in participants)
                    {
                        if (participant.Name.Equals(trainerName))
                        {
                            participant.Pokemons.Add(pokemon);
                        }
                    }
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    participants.Add(trainer);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input == "Fire")
                {
                    CheckingThePokemons(participants, input);
                }
                if (input == "Electricity")
                {
                    CheckingThePokemons(participants, input);
                }
                if (input == "Water")
                {
                    CheckingThePokemons(participants, input);
                }
            }

            foreach (var trainer in participants.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        public static void CheckingThePokemons(List<Trainer> participants, string input)
        {
            foreach (var participant in participants)
            {
                if (participant.Pokemons.Exists(x => x.Element.Equals(input)))
                {
                    participant.NumberOfBadges++;
                }
                else
                {
                    for (int i = 0; i < participant.Pokemons.Count; i++)
                    {
                        participant.Pokemons[i].Health -= 10;
                        if (participant.Pokemons[i].Health <= 0)
                        {
                            participant.Pokemons.Remove(participant.Pokemons[i]);
                        }
                    }
                }
            }
        }
    }
}
