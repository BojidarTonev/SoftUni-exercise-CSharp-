using System;
using System.Collections.Generic;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public class Factory
{
    public Character CreateCharacter(string faction, string characterType, string name)
    {
        Enum.TryParse(typeof(Faction), faction, out object result);

        if (result == null)
        {
            throw new ArgumentException($"Parameter Error: Invalid faction \"{faction}\"!");
        }

        if (characterType != "Warrior" && characterType != "Cleric")
        {
            throw new ArgumentException($"Parameter Error: Invalid character type {characterType}!");
        }

        Type typeChar = Type.GetType(characterType);

        Character instance = (Character)Activator.CreateInstance(typeChar, new object[]{name, result});

        return instance;
    }

    public Item Createitem(string itemName)
    {

        if (itemName != typeof(ArmorRepairKit).Name && itemName != typeof(HealthPotion).Name && itemName != typeof(PoisonPotion).Name)
        {
            throw new ArgumentException($"Parameter Error: Invalid item \"{itemName}\"!");
        }

        var classType = Type.GetType(itemName);

        var instance = (Item)Activator.CreateInstance(classType);

        return instance;
    }
}


