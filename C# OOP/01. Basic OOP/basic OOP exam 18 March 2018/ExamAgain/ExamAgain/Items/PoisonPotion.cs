using System;
using System.Collections.Generic;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public class PoisonPotion : Item
{
    public PoisonPotion() 
        : base(5)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }
        character.UsePoisonPotion();
    }
}

