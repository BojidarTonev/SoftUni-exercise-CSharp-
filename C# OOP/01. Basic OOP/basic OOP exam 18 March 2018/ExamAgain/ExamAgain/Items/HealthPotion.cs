using System;
using System.Collections.Generic;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public class HealthPotion : Item
{
    public HealthPotion() 
        : base(5)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }
        character.UseHealthPotion();
    }
}

