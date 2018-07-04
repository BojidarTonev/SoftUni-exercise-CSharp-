using System;
using System.Collections.Generic;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public class ArmorRepairKit : Item
{
    public ArmorRepairKit()
        : base(10)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException(ExceptionMesseges.MustBeAliveToPerferomAction);
        }
        
        character.UseRepairkit();
    }
}

