using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfernoCrazyShit.Factories;
using InfernoCrazyShit.Interface;
using InfernoCrazyShit.Weapons;

namespace InfernoCrazyShit
{
    public class WeaponManager
    {
        private List<Weapon> weapons;

        public WeaponManager()
        {
            this.weapons = new List<Weapon>();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split(';').ToArray();
                if (tokens[0] == "Create")
                {
                    CreateWeapon(tokens);
                }

                else if (tokens[0] == "Add")
                {
                    string weaponName = tokens[1];
                    int socketIndex = int.Parse(tokens[2]);
                    string gemType = tokens[3];

                    

                }
                else if (tokens[0] == "Remove")
                {
                    string weaponName = tokens[1];
                    int socketIndex = int.Parse(tokens[2]);
                }
                else if (tokens[0] == "Print")
                {
                    string weaponName = tokens[1];
                    
                }
            }
        }

        private void CreateWeapon(string[] tokens)
        {
            string rareType = tokens[1].Split(' ')[0];
            string weaponType = tokens[1].Split(' ')[1];
            string weaponName = tokens[2];
            WeaponFactory factory = new WeaponFactory();
            Weapon weapon = factory.CreateWeapon(rareType, weaponType, weaponName);
            weapons.Add(weapon);
        }
    }
}
