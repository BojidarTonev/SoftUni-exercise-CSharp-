using System;
using System.Collections.Generic;
using System.Text;


public class GemCreator : IGemFactory
{
    public Gem CreateGem(string Clarity, string GemType)
    {
        GemEnums clarity = (GemEnums)Enum.Parse(typeof(GemEnums), Clarity);

        Type gemType = Type.GetType(GemType);

        Gem instance = (Gem)Activator.CreateInstance(gemType, new object[] { clarity });

        return instance;
    }
}

