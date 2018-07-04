using System;
using System.Collections.Generic;
using System.Text;
using InfernoCrazyShit.Gems;

namespace InfernoCrazyShit.Interface
{
    public interface IGemFactory
    {
        Gem CreateGem(string clarity, string gemType);
    }
}
