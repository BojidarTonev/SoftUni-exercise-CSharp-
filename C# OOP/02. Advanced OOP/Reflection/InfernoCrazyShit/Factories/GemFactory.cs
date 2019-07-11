using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Gems;
using InfernoCrazyShit.Interface;

namespace InfernoCrazyShit.Factories
{
    public class GemFactory : IGemFactory
    {
        public Gem CreateGem(string clarity, string gemType)
        {
            GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);

            Type classType = Type.GetType(gemType);

            Gem instance = (Gem)Activator.CreateInstance(classType, new object[] { gemClarity });

            return instance;
        }
    }
}
