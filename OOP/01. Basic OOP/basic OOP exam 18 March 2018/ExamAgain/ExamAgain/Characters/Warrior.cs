using System;
using System.Collections.Generic;
using System.Text;


public class Warrior : Character, IAttackable
{
    public Warrior(string name, Faction faction) 
        : base(name, 100, 50, 40, new Satchel(), faction)
    {
    }

    public void Attack(Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        if (character.Name == this.Name)
        {
            throw new InvalidOperationException(ExceptionMesseges.CannotAttackSelf);
        }

        if (character.Faction == this.Faction)
        {
            throw new ArgumentException($"Parameter Error: Friendly fire! Both characters are from {this.Faction} faction!");
        }

        character.TakeDamage(this.AbilityPoints);
    }
}

