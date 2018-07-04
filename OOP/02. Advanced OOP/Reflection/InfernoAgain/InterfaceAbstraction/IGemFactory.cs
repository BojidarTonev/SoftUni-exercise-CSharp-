using System;
using System.Collections.Generic;
using System.Text;


public interface IGemFactory
{
    Gem CreateGem(string clarity, string gemType);
}
