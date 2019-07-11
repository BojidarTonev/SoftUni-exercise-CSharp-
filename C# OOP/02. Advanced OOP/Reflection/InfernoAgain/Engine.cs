using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    private List<Weapon> weapons;

    public Engine()
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
                SocketingWeapon(tokens);
            }
            else if (tokens[0] == "Remove")
            {
                RemoveGem(tokens);
            }
            else if (tokens[0] == "Print")
            {
                PrintWeapon(tokens);
            }
        }
    }

    private void PrintWeapon(string[] tokens)
    {
        string weaponName = tokens[1];
        Weapon weapon = weapons.FirstOrDefault(w => w.Name == weaponName);
        if (weapon != null)
        {
            Console.WriteLine(weapon);
        }
    }

    private void RemoveGem(string[] tokens)
    {
        string weaponName = tokens[1];
        int socketIndex = int.Parse(tokens[2]);
        Weapon weapon = weapons.FirstOrDefault(w => w.Name == weaponName);
        if (weapon != null)
        {
            weapon.RemoveGem(socketIndex);
        }
    }

    private void SocketingWeapon(string[] tokens)
    {
        string weaponName = tokens[1];
        int socketIndex = int.Parse(tokens[2]);
        string gemClarity = tokens[3].Split(' ')[0];
        string gemType = tokens[3].Split(' ')[1];
        GemCreator gemCreator = new GemCreator();
        Gem gem = gemCreator.CreateGem(gemClarity, gemType);
        Weapon weaponToSocket = weapons.FirstOrDefault(w => w.Name == weaponName);
        if (weaponToSocket != null)
        {
            weaponToSocket.AddGem(socketIndex, gem);
        }
    }

    private void CreateWeapon(string[] tokens)
    {
        string rarity = tokens[1].Split(' ')[0];
        string weaponType = tokens[1].Split(' ')[1];
        string name = tokens[2];
        WeaponCreater weaponCreater = new WeaponCreater();
        Weapon weapon = weaponCreater.CreateWeapon(rarity, name, weaponType);
        weapons.Add(weapon);
    }
}

