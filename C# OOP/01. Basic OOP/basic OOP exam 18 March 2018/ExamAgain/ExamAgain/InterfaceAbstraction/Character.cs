using System;
using System.Collections.Generic;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public abstract class Character
{
    private string name;
    private double baseHealth;
    private double health;
    private double baseArmor;
    private double armor;
    private double abilityPoints;
    private Bag bag;
    private Faction faction;
    private bool isAlive = true;
    private double restHealMultiplier = 0.2;

    public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.BaseArmor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.Health = health;
        this.Armor = armor;
    }
    public double RestHealMultiplier
    {
        get { return restHealMultiplier = 0.2; }
        protected set { restHealMultiplier = value; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        protected set { isAlive = value; }
    }

    public Faction Faction
    {
        get { return faction; }
        protected set { faction = value; }
    }

    public Bag Bag
    {
        get { return bag; }
        protected set { bag = value; }
    }

    public double AbilityPoints
    {
        get { return abilityPoints; }
        protected set { abilityPoints = value; }
    }

    public double Armor
    {
        get { return armor; }
        protected set
        {
            armor = value;
            if (armor < 0)
            {
                armor = 0;
            }

            if (armor > this.BaseArmor)
            {
                armor = this.BaseArmor;
            }
        }
    }

    public double BaseArmor
    {
        get { return baseArmor; }
        protected set { baseArmor = value; }
    }

    public double Health
    {
        get { return health; }
        protected set
        {
            health = value;
            if (health < 0)
            {
                health = 0;
            }

            if (health > this.BaseHealth)
            {
                health = this.BaseHealth;
            }
        }
    }

    public double BaseHealth
    {
        get { return baseHealth; }
        protected set { baseHealth = value; }
    }

    public string Name
    {
        get { return name; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Parameter Error: Name cannot be null or whitespace!");
            }
            name = value;
        }
    }

    public void TakeDamage(double hitPoints)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }
        if (hitPoints > this.Armor)
        {
            double attackLeft = hitPoints - this.Armor;
            this.Armor = 0;
            this.Health -= attackLeft;
            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }
        else
        {
            this.Armor -= hitPoints;
        }
    }

    public void Rest()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        this.Health += this.BaseHealth * this.restHealMultiplier;
    }

    public void UseItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item itemm, Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        Item item = this.Bag.GetItem(itemm.GetType().Name);

        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        this.Bag.AddItem(item);
    }

    public void TakeHeal(double healPoints)
    {
        this.Health += healPoints;
    }

    public void UseRepairkit()
    {
        this.Armor = this.BaseArmor;
    }

    public void UseHealthPotion()
    {
        this.Health += 20;
        if (this.Health > this.BaseHealth)
        {
            this.Health = this.BaseHealth;
        }
    }

    public void UsePoisonPotion()
    {
        this.Health -= 20;
        if (this.Health < 0)
        {
            this.Health = 0;
            this.IsAlive = false;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: ");
        if (this.Health > 0)
        {
            sb.AppendLine("Alive");
        }
        else
        {
            sb.AppendLine("Dead");
        }

        return sb.ToString().TrimEnd();
    }
}

