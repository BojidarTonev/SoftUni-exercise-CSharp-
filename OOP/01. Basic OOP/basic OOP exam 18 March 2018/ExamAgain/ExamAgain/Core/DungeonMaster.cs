using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public class DungeonMaster
{
    private int lastSurvivorRounds;
    public List<Character> characters;
    private List<Item> itemPool;

    public DungeonMaster()
    {
        this.lastSurvivorRounds = 0;
        this.characters = new List<Character>();
        this.itemPool = new List<Item>();
    }

    public string JoinParty(string[] args)
    {
        string faction = args[0];
        string characterType = args[1];
        string name = args[2];

        Factory factory = new Factory();

        characters.Add(factory.CreateCharacter(faction, characterType, name));

        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        string itemName = args[0];

        Factory factory = new Factory();

        itemPool.Add(factory.Createitem(itemName));

        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        string characterName = args[0];

        if (characters.FirstOrDefault(c => c.Name == characterName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {characterName} not found!");
        }

        if (itemPool.Count == 0)
        {
            throw new InvalidOperationException($"Invalid Operation: No items left in pool!");
        }

        Character character = characters.First(c => c.Name == characterName);
        Item item = itemPool.Last();

        character.ReceiveItem(item);
        itemPool.Remove(item);

        return $"{characterName} picked up {item.GetType().Name}!";

    }

    public string UseItem(string[] args)
    {
        string characterName = args[0];
        string itemName = args[1];

        if (characters.FirstOrDefault(c => c.Name == characterName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {characterName} not found!");
        }

        Character character = characters.First(c => c.Name == characterName);
        Item item = character.Bag.GetItem(itemName);

        character.UseItem(item);

        return $"{character.Name} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string reeiverName = args[1];
        string itemName = args[2];

        if (characters.FirstOrDefault(c => c.Name == giverName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {giverName} not found!");
        }

        if (characters.FirstOrDefault(c => c.Name == reeiverName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {reeiverName} not found!");
        }

        Character giverChar = characters.First(c => c.Name == giverName);
        Character receiverChar = characters.First(c => c.Name == reeiverName);

        Item item = giverChar.Bag.GetItem(itemName);

        receiverChar.UseItem(item);

        return $"{giverName} used {itemName} on {reeiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string reeiverName = args[1];
        string itemName = args[2];

        if (characters.FirstOrDefault(c => c.Name == giverName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {giverName} not found!");
        }

        if (characters.FirstOrDefault(c => c.Name == reeiverName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {reeiverName} not found!");
        }

        Character giverChar = characters.First(c => c.Name == giverName);
        Character receiverChar = characters.First(c => c.Name == reeiverName);

        Item item = giverChar.Bag.GetItem(itemName);

        receiverChar.ReceiveItem(item);

        return $"{giverName} gave {reeiverName} {item.GetType().Name}.";
    }

    public string GetStats()
    {
        var sb = new StringBuilder();
        List<Character> newCharacters =
            this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health).ToList();

        foreach (var character in newCharacters)
        {
            sb.AppendLine(character.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    public string Attack(string[] args)
    {
        var sb = new StringBuilder();

        string attackerName = args[0];
        string receiverName = args[1];

        if (characters.FirstOrDefault(c => c.Name == attackerName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {attackerName} not found!");
        }

        if (characters.FirstOrDefault(c => c.Name == receiverName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {receiverName} not found!");
        }

        Character attacker = characters.First(c => c.Name == attackerName);
        Character receiver = characters.First(c => c.Name == receiverName);

        if (attacker.GetType().Name == "Cleric")
        {
            throw new ArgumentException($"Parameter Error: {attackerName} cannot attack!");
        }

        Warrior attackerr = (Warrior) attacker;
        attackerr.Attack(receiver);

        sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

        if (!receiver.IsAlive)
        {
            sb.AppendLine($"{receiverName} is dead!");
        }

        return sb.ToString().TrimEnd();
    }

    public string Heal(string[] args)
    {
        var sb = new StringBuilder();

        string healerName = args[0];
        string healingReceiverName = args[1];

        if (characters.FirstOrDefault(c => c.Name == healerName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {healerName} not found!");
        }

        if (characters.FirstOrDefault(c => c.Name == healingReceiverName) == null)
        {
            throw new ArgumentException($"Parameter Error: Character {healingReceiverName} not found!");
        }

        Character healer = characters.First(c => c.Name == healerName);
        Character receiver = characters.First(c => c.Name == healingReceiverName);

        if (healer.GetType().Name == "Warrior")
        {
            throw new ArgumentException($"Parameter Error: {healerName} cannot heal!");
        }

        Cleric healerr = (Cleric)healer;
        healerr.Heal(receiver);

        sb.AppendLine(
            $"{healerName} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {receiver.Health} health now!");

        return sb.ToString().TrimEnd();
    }

    public string EndTurn(string[] args)
    {
        var sb = new StringBuilder();

        List<Character> survivors = characters.Where(c => c.IsAlive).ToList();
        if (survivors.Count <= 1)
        {
            this.lastSurvivorRounds++;
        }
        foreach (var character in survivors)
        {
            double b4health = character.Health;
            character.Rest();
            sb.AppendLine($"{character.Name} rests ({b4health} => {character.Health})");
        }

        return sb.ToString().TrimEnd();
    }

    public bool IsGameOver()
    {
        if (this.lastSurvivorRounds >= 2)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Final stats:");
            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x=>x.Health))
            {
                sb.AppendLine(character.ToString());
            }

            Console.WriteLine(sb.ToString().TrimEnd());
            return true;
        }

        return false;
    }

}

