using System;
using System.Collections.Generic;
using System.Text;


public interface IAddCollection
{
    List<string> list { get; }
    void Add(string input);
}

