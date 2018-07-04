using System;
using System.Collections.Generic;
using System.Text;


public class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction) 
        : base(name, 50, 25, 40, new Backpack(), faction)
    {
        base.RestHealMultiplier = 0.5;
    }

    public void Heal(Character character)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }

        if (character.Faction != this.Faction)
        {
            throw new InvalidOperationException("Invalid Operation: Cannot heal enemy character!");
        }

        character.TakeHeal(this.AbilityPoints);
    }
}

